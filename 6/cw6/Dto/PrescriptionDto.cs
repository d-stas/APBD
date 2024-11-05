namespace WebApplication6.Dto;

public class PrescriptionDto
{
    public class Get
    {
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }
        
        public DoctorDto.Get Doctor { get; set; }
        
        public PatientDto.Get Patient { get; set; }
        
        public ICollection<MedicamentDto.Get> Medicaments { get; set; }
    }
}