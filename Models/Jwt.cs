using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jwt
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Subjet { get; set; }
        public int CodigoUsuario { get; set; }

        public string? NombreUsuario { get; set; }
    }
}
