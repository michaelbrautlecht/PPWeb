using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PPData.Models
{
    internal class Publication
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Description { get; set; }
        
        public int PubYear { get; set; }
        public int PubMonth { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
