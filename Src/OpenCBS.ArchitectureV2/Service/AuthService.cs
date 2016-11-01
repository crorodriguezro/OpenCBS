using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.Manager;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class AuthService : IAuthService
    {
        public User Login(string username, string password)
        {

            var user = ServicesProvider.GetInstance().GetUserServices().FindByName(username);

            if (user != null && PasswordEncoder.Match(user, password))
            {
                return (User.CurrentUser = user);
            }


            return null;
        }

        public bool LoggedIn
        {
            get { return User.CurrentUser != null && User.CurrentUser.Id > 0; }
        }
        

    }
}
