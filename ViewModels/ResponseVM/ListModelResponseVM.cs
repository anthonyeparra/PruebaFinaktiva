using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PruebaFinaktiva.Models.ViewModels.ResponseVM
{
    public class ListModelResponseVM<T>
    {
        public ListModelResponseVM(int code, string message, List<T> data = null){
            Code = code;
            Message = message;
            Data = data != null ? data : new List<T>();
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
        
    }
}
