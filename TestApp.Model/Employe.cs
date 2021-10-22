using System.ComponentModel.DataAnnotations;

namespace TestApp.Model
{
    public class Employe
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15)]
        public string Number { get; set; }
    }
}
