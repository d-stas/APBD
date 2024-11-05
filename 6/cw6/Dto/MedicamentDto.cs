namespace WebApplication6.Dto;

public class MedicamentDto
{
    public class Get
    {
        public int IdMedicament { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Type { get; set; }
        
        public int? Dose { get; set; }
        
        public string Details { get; set; }
    }
}