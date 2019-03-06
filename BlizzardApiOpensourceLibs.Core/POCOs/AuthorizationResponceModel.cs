using System;
using System.Collections.Generic;
using System.Text;

namespace BlizzardApiOpensourceLibs.Core.POCOs
{
    public class AuthorizationResponceModel
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string ExpiresIn { get; set; }
    }
}
