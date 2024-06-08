using System.ComponentModel.DataAnnotations;


namespace Entities.Entites
{
    public class User
    {
        [Key]
        public int? IdUser { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Fone { get; set; }
    }
}