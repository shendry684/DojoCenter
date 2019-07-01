using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCenter.Models
{
    public class User
    {
        // private bool isAttending1;

        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length!")]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(8, ErrorMessage = "Email must be 8 characters or longer!")]
        [Display(Name="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")]
            
        public string Password { get; set; }
        //add number and special character validation
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        public List<Participant> Planner { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
    }
}