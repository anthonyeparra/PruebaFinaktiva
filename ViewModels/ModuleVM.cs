using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.ViewModel
{
    public partial class ModuleVM
    {

        public int Id { get; set; }
        public string NameModule { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreationDate { get; set; }


    }
}
