using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ValidationCode { get; set; }
        public bool EmailHasValidated { get; set; }
        void MakeValidationCode()
        {
            ValidationCode = new Random().Next().ToString();
        }
    }
}
