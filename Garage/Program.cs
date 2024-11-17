using Garage.Common.Utils.Security;
using Garage.Data;
using Garage.Forms.MainForm;
using Garage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Garage.Forms;
using Garage.Forms.MainForm.Dictionary;
using GaraOto.Common.Utilities.Helper;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        var configuration = LoadConfiguration();
        ConfigureServices(services, configuration);

        // Build ServiceProvider and store it as a static property
        ServiceProvider = services.BuildServiceProvider();

        using (var scope = ServiceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<GaraOtoDbContext>();

            // Update password hashes if necessary
            var passwordUpdater = scope.ServiceProvider.GetRequiredService<PasswordHashUpdater>();
            passwordUpdater.UpdatePasswordHashes();

            // Set this before any forms are created
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var _context = new GaraOtoDbContext();
            // Resolve DashBoard from the service provider so it gets all dependencies
            var dashboard = scope.ServiceProvider.GetRequiredService<DashBoard>();
            var login =scope.ServiceProvider.GetRequiredService<Login>();
            // cái này tạo form tên là yournameform
            //Application.Run(yourNameFOrm());
            Application.Run(login);
        }
    }


    private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<GaraOtoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

        // Register Forms
        services.AddTransient<Login>();
        services.AddTransient<DashBoard>();
        services.AddTransient<AddNhanVien>();

        // Register other services
        services.AddScoped<PasswordHashUpdater>();
        services.AddScoped<TransactionInventory>();
        services.AddScoped<RevenueCalculator>(); // Register RevenueCalculator as well
        services.AddScoped<ListBooking>();
        services.AddScoped<GetCustomer>();
        services.AddScoped<GetStaff>();
        services.AddScoped<RepairTrackerUtils>();
        services.AddScoped<ServiceCustomer>();
        //services.AddScoped<ExcelHelper>();
    }

    private static IConfiguration LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        return builder.Build();
    }
}
