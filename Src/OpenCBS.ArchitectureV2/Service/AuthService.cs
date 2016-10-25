using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class AuthService : IAuthService
    {
        public User Login(string username, string password)
        {
            var userService = ServicesProvider.GetInstance().GetUserServices();
            User user=null;
            if (userService.IsNeedOldAuthentification())
            user = userService.IsValidPasswordUser(username, password);

            if (user == null) return null;
            return (User.CurrentUser = user);
        }

        public bool LoggedIn
        {
            get { return User.CurrentUser != null && User.CurrentUser.Id > 0; }
        }
    }
}
