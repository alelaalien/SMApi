using SM.Core.Enumerations;

namespace SM.Core.Entities
{
    public class Security: BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public RoleType Role { get; set; }

    }
}
