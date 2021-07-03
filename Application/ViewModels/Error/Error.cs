using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class Error
    {
        protected int num { get; set; }
        public string Message { get; set; }
        public virtual void Show() {
            Message = "Error";             
        }
    }
}
