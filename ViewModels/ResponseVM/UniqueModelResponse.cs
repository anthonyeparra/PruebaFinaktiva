using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFinaktiva.Models.ViewModels.ResponseVM
{
    public class UniqueModelResponse<T>
    {
        public UniqueModelResponse(int code, string message, T data) {
            Code = code;
            Message = message;
            Data = data;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
