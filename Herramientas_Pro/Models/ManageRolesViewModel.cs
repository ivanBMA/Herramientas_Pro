﻿using System.Collections.Generic;

namespace Herramientas_Pro.Models
{
    public class ManageRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
