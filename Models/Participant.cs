using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoCenter.Models
{
    public class Participant
    {

        [Key]
        public int ParticipantId { set; get; }

        public int ShindigId { set; get; }
        [Required]
        
        [MinLength(5, ErrorMessage="Shindig name must be 5 characters or longer!")]
        public Shindig Shindig { get; set; }
        public int UserId { set; get; }
    
        public User User { get; set; }
        
    }


}