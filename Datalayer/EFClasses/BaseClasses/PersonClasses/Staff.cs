namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Staff : Employee
    {
        public string StaffId { get; set; }

        public JobClass JobClassLink { get; set; }
        public string? JobClassId { get; set; }
    }
}
