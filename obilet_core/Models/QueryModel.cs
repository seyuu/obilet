using System;
using System.ComponentModel.DataAnnotations;

namespace obilet_core.Models
{
    public class QueryModel
    {
        [Required]
        public int OriginId { get; set; }
        [Required]
        public int DestinationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
