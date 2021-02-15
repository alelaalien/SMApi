using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class Subjet : BaseEntity
    {
        public Subjet()
        {
            Event = new HashSet<Event>();
        }

 
        public string Name { get; set; }
        public int Active { get; set; }
        public int IdUser { get; set; }
        public string Class { get; set; }
  

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
