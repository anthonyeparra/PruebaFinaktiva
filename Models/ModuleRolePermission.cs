using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.Models
{
    public partial class ModuleRolePermission
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdModule { get; set; }
        public int IdPermission { get; set; }

        public virtual Module IdModuleNavigation { get; set; }
        public virtual Permission IdPermissionNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; }
    }
}
