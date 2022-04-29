using PASVE.Models;

namespace PASVE
{
    public static class GlobalVariables
    {
        public static User UserInfo { get; set; }
        public static Guid Installment { get; set; } = Guid.Empty;
    }
}
