namespace ExternalAPI.Client.Models
{
    public class LoginResponse
    {
        public string LastName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public int Course { get; set; }
        public string Group { get; set; } = default!;
    }
}
