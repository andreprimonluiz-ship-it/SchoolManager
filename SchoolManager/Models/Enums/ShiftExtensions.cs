namespace SchoolManager.Models.Enums
{
    public static class ShiftExtensions
    {
        public static string GetBadgeClass(this Shift shift)
        {
            return shift switch
            {
                Shift.Morning => "bg-primary",
                Shift.Afternoon => "bg-warning text-dark",
                Shift.Night => "bg-dark",
                _ => "bg-secondary"
            };
        }
    }
}
