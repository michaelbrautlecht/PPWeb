using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPWebApplication.Models
{
    [Table("Publications")]
    public class PublicationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }

        [Required]
        [MaxLength(80)]
        public string PubName { get; set; } = string.Empty;

        public int PubYear { get; set; }

        public int PubMonth { get; set; }
    }
}
