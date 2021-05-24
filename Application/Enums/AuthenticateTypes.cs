using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enums
{
    public class AuthenticateTypes
    {
        public AuthenticateTypes(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public static AuthenticateTypes Basic { get { return new AuthenticateTypes("basic"); } }
        public static AuthenticateTypes External { get { return new AuthenticateTypes("external"); } }
    }
}
