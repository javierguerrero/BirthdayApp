namespace Application.DTOs
{
    public class ContactDto
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}