using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.ViewModel
{
    public partial class PermissionVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte Status { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
