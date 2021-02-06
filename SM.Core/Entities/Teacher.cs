using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class Teacher : BaseEntity
    {
        public Teacher()
        {
            Event = new HashSet<Event>();
        }

 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string Subjets { get; set; }
        public int Celephone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
