using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaFinaktiva.Models.ViewModels.ResponseVM;
using UsersAPruebaFinaktivaPI.Models.ViewModels.ResponseVM;

namespace PruebaFinaktiva.Helpers
{
    public class ResponseHelper
    {
        //CONSTRUYE UNA RESPUESTA PARA CONTROL DE EXCEPCIONES
        public static BasicResponseVM buildExceptionMessage(Exception ex) {
            string message = "Error: ";
            if (!string.IsNullOrEmpty(ex.Message) && ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                message += $"{ex.Message} ({ex.InnerException.Message})";
            }
            else {
                if (!string.IsNullOrEmpty(ex.Message)) message += ex.Message;
                else if (!string.IsNullOrEmpty(ex.InnerException.Message)) message += ex.InnerException.Message;
                else message += "A ocurrido un error inesperado.";
            }

            return new BasicResponseVM(400, message);
        }

        //OBTIENE LOS ERRORES DE LA VALIDACIÓN DE MODELOS
        public static string buildModelStateErrorResponse(ModelStateDictionary modelState) {

            var errors = (from m in modelState
                          where m.Value.Errors.Count > 0
                          select new 
                          {
                               m.Value.Errors[0].ErrorMessage
                          }).ToList();

            
            return errors[0].ErrorMessage;
        }
    }
}
