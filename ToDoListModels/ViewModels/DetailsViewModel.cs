using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListModels.ViewModels
{
    public class DetailsViewModel
    {

       public Detail Details { get; set; }
       [ValidateNever]
       public IEnumerable<SelectListItem> SubjectList { get; set; }
          
    }
}
