using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkParallelForConsole.Model
{
    public class Organisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string OrganisationId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Website { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        public int? Founded { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Industry { get; set; }

        [Column(TypeName = "int")]
        public int? NumberOfEmployees { get; set; }
    }
}