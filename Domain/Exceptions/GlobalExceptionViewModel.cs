using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class GlobalExceptionViewModel
    {

        //public bool IsValidation { get; set; }
        //public List<ExceptionViewModel> Errors { get; set; } = new List<ExceptionViewModel>();

        public Dictionary<string, List<string>> Messages { get; set; }

    }
}
