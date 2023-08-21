using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models.Identity
{
    public class JwtSettings
    {
        //key de token
        public string Key { get; set; } = string.Empty;
        //quien envia el token a la audiencia
        public string Issuer { get; set; } = string.Empty;
        // declaramos la audiencia
        public string Audience { get; set; } = string.Empty;
        //tiempo de vida de token
        public double DurationInMinutes { get; set; }
    }
}
