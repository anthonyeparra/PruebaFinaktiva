using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.Models
{
    public partial class Permission
    {
        public Permission()
        {
            ModuleRolePermission = new HashSet<ModuleRolePermission>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte Status { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ModuleRolePermission> ModuleRolePermission { get; set; }
    }
}
