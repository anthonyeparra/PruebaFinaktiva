using System;
using System.Collections.Generic;

namespace PruebaFinaktiva.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
