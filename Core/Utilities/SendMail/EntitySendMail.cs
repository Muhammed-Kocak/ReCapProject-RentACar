using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.SendMail
{
    public class EntitySendMail : ISendMail
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
