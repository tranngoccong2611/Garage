using Garage.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Common.Enum
{
    public enum StatusMaintaince
    {
        DONE=0, TODO=1, FAILED=2,
    }
    public enum StatusCarMaintaince
    {
        Pending=0, Approved=1, Reject=2,
    }
}


public static class StatusMaintainceExtensions
{
    public static string ToFriendlyString(this StatusMaintaince status)
    {
        switch (status)
        {
            case StatusMaintaince.DONE:
                return "Done";
            case StatusMaintaince.TODO:
                return "To Do";
            case StatusMaintaince.FAILED:
                return "Failed";
            default:
                return "Unknown";
        }
    }
}
public static class StatusCarMaintainceExtensions
{
    private static readonly Dictionary<StatusCarMaintaince, string> statusNames = new Dictionary<StatusCarMaintaince, string>
    {
        { StatusCarMaintaince.Pending, "Pending" },
        { StatusCarMaintaince.Approved, "Approved" },
        { StatusCarMaintaince.Reject, "Reject" }
    };

    public static string GetStatusName(this StatusCarMaintaince status)
    {
        return statusNames[status];
    }
  

}