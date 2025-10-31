namespace Api29._10._25.CQRS.DTO
{
    public class UserDTO
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; }

        public int Id { get; set; }

        public string Info { get; set; } = null!;
    }
}
