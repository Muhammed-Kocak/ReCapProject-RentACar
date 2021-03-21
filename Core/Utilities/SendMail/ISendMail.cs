using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.SendMail
{
    public interface ISendMail
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
