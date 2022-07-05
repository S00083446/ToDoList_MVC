using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public string CourseOfStudy { get; set; }
        public DateTime? Graduation { get; set; }
        //public string? [] interests { get; set; }
        public string? location { get; set; }
        public string Email { get; set; }

    }
}
