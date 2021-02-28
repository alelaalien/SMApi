using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class TypeOf : BaseEntity
    {
        public TypeOf()
        {
            Event = new HashSet<Event>();

        }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }

    }
}
