using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidateException : Exception
    {
        //public ValidateException()
        //{


        //}

        //public ValidateException(string message) : base(message)
        //{
        //    //Todo Your Message
        //    //What happen if has field Name & Message
        //    //Multiple field and Multiple Error -> Group it
        //    // { "fieldName" : ["Erorr 1","Error 2"]  }
        //}

        public override string Message => string.Join(", ", Messages.Select(s => s.Message));
        public List<ExceptionViewModel> Messages { get; set; } = [];
        public bool IsThrow { get; set; }

        public ValidateException()
        {

        }

        public ValidateException(string message)
        {
            Messages.Add(new ExceptionViewModel { Message = message });
        }

        public ValidateException(string elementId, string message)
        {
            Messages.Add(new ExceptionViewModel { ElementId = elementId, Message = message });
        }

        public void Add(string message)
        {
            Messages.Add(new ExceptionViewModel { Message = message });
        }

        public void Add(string elementId, string message)
        {
            Messages.Add(new ExceptionViewModel { ElementId = elementId, Message = message });
        }

        public void Throw()
        {
            if (Messages.Count == 0)
                return;
            else
            {
                IsThrow = true;
                throw this;
            }
        }

        public void Dispose()
        {
            bool throwFromInside = Marshal.GetExceptionPointers() != IntPtr.Zero;

            if (Messages.Count == 0 || IsThrow || throwFromInside)
                return;

            throw this;
        }
    }

    public class ExceptionViewModel
    {
        public string ElementId { get; set; }
        public string Message { get; set; }
    }




}

