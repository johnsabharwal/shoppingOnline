using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public class EmailVerification
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
