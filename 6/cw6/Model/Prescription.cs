using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Model;

[Table("Prescription")]
public class Prescription
{
    [Key] 
    public int IdPrescription { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int IdDoctor { get; set; }

    public int IdPatient { get; set; }

    [ForeignKey(nameof(IdDoctor))] 
    public virtual Doctor Doctor { get; set; }
    [ForeignKey(nameof(IdPatient))] 
    public virtual Patient Patient { get; set; }
}