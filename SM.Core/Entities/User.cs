using System.Collections.Generic;

namespace SM.Core.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Subjet = new HashSet<Subjet>();
        }


        public string Nick { get; set; }
        public string Email { get; set; }
        public string Img { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Subjet> Subjet { get; set; }
    }
}
