﻿using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class Teacher : BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string Subjets { get; set; }
        public int Celephone { get; set; }
        public string Email { get; set; } 
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } 
    }
}
