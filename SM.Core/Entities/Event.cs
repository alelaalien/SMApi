﻿using System;

namespace SM.Core.Entities
{
    public partial class Event: BaseEntity
    {
 
        public int IdSubjet { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int Priority { get; set; }
        public int Active { get; set; }
        public virtual User IdUserNavigation { get; set; }

        public virtual TypeOf IdTypeOfNavigation { get; set; }
        public virtual Subjet IdSubjetNavigation { get; set; }


    }
}
