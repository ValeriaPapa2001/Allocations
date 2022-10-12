namespace Allocations.Mvc.Models
{
    public class DetailsEmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public decimal HourCost { get; set; }

        public string Role { get; set; }
    }
}
