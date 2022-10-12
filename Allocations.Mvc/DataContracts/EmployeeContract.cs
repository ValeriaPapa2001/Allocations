namespace Allocations.Mvc.DataContracts
{
    public class EmployeeContract
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public decimal HourCost { get; set; }


        public int IdRole { get; set; }
        public RoleContract Role { get; set; }

        
    }
}
