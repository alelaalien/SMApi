using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Subjet = new HashSet<Subjet>();
            Teacher = new HashSet<Teacher>();
            Event = new HashSet<Event>();
            TypeOf = new HashSet<TypeOf>();
        }


        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Subjet> Subjet { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<TypeOf> TypeOf { get; set; }
    }
}
