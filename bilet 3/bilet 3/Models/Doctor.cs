using System.ComponentModel.DataAnnotations.Schema;

namespace bilet_3.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]

        public IFormFile ImageFile { get; set; }
    }
}
