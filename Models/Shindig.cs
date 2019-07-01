using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoCenter.Models
{
    public class Shindig
    {
        [Key]
        public int ShindigId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Shindig Title must be at least 5 characters in length!")]
        public string Title{ get; set; }
        
        [Required]
        
        public string ShindigDate { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Shindig time must be at least 5 characters in length!")]
                
        public string ShindigTime { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Shindig time must be at least 20 minutes!")]
        public int Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DurationSegment { get; set; }
        public User Planner { get; set; }
        public int PlannerId { get; set; }
        
        public List<Participant> Shindigname { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        

    
    }
}