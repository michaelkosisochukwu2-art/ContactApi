namespace ContactApi.Model
{
    public class Mycontact
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int PhoneNumber { get; set; } 
        public string EmailAddress { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;


    }
}
