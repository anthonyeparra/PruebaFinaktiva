using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPruebaFinaktivaPI.Models.ViewModels.ResponseVM
{
    public class BasicResponseVM
    {
        public BasicResponseVM(int code, string message) {
            Code = code;
            Message = message;
        }
        // Contiene el código del error
        public int Code { get; set; }

        // Contiene el mensaje de respuesta
        public string Message { get; set; }
    }
}
