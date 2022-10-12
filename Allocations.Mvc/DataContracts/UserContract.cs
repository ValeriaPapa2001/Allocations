using Allocations.Core.Entities;

namespace Allocations.Mvc.DataContracts
{
    public class UserContract
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public Roll roll   { get; set; }

    }

    public enum Roll
    {
        Admin,
        Developer
    }
}
