using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListModels
{
    public class Detail
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "Days until the event")]
        [Required]
        public byte DaysUntilEvent { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        
        [Display(Name = "End Time")]
        [Required]
        public DateTime EndTime { get; set; }
        
        [Required]
        public string Location { get; set; }

        [Display(Name = "Room Name")]
        [Required]
        public string RoomName { get; set; }
        
        public string Notes { get; set; }

        public double Cost { get; set; }

        [Display(Name = "% of total marks")]
        public byte PercentageOfTotalMarks { get; set; }
        
        [Display(Name = "Number of Participants")]
        public int NumberOfParticpants { get; set; }
        
        [ValidateNever]


        [Display(Name = "Image Upload")]

        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "To do Category")]
        public int SubjectsId { get; set; }
        [ForeignKey("SubjectsId")]
        [ValidateNever]
        
        public Subjects? Subjects { get; set; }
    }
}
