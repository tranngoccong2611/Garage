public class BillingData
{
    public int BillNum { get; set; } // IDENTITY column, sẽ được tự động tạo trong Supabase
    public string CarNum { get; set; }
    public string BDate { get; set; }
    public int MechFees { get; set; }
    public int PartFees { get; set; }
    public int TotFees { get; set; }
}