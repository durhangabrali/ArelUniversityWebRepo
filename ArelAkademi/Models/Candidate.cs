using System.ComponentModel.DataAnnotations;

namespace ArelAkademi.Models
{
    public class Candidate
    {
       [Required(ErrorMessage="Email boş geçilemez!")]
       public string? Email { get; set; } = String.Empty;

       [Required(ErrorMessage="Ad boş geçilemez!")]
       public string? FirstName { get; set; } = String.Empty;

       [Required(ErrorMessage="Soyad boş geçilemez!")]
       public string? LastName { get; set; } = String.Empty;
       public string? FullName => $"{FirstName} {LastName?.ToUpper()}";
       public int Age { get; set; }
       public string? SelectedCourse  { get; set; } = String.Empty;
       public DateTime ApplyAt { get; set; }
       public Candidate()
       {
         ApplyAt = DateTime.Now;
       }    
    }
}