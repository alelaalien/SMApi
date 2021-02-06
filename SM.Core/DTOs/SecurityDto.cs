using SM.Core.Enumerations;

namespace SM.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public RoleType Role { get; set; }
    }
}
