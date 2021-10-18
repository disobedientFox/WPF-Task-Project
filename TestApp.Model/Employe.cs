using System.ComponentModel.DataAnnotations;

namespace TestApp.Model
{
    public class Employe
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Number { get; set; }
    }
}
