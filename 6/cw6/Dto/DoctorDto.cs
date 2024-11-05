namespace WebApplication6.Dto;

public class DoctorDto
{
    public class Get
    {
        public int IdDoctor { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
    }

    public class Create
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
    }

    public class Update
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
    }
}