using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.Models
{
    public partial class Role
    {
        public Role()
        {
            ModuleRolePermission = new HashSet<ModuleRolePermission>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string NameRole { get; set; }
        public byte Status { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ModuleRolePermission> ModuleRolePermission { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
