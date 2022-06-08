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
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public byte DaysUntilEvent { get; set; }
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? RoomName { get; set; }
        public string? Notes { get; set; }
        public double Cost { get; set; } // cut
        public byte PercentageOfTotalMarks { get; set; }
        public int NumberOfParticpants { get; set; } // cut
        public string? ImageUrl { get; set; } // cut
        [Required]
        public int SubjectsId { get; set; }
        [ForeignKey("SubjectsId")]
        public Subjects? Subjects { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType? CoverType { get; set; }
    }
}
