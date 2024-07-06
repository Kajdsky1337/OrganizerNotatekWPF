using ProjektOrganizerNotatek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOrganizerNotatek.Service
{
    public class SessionManager
    {
        private static readonly Lazy<SessionManager> _instance = new Lazy<SessionManager>(() => new SessionManager());
        public static SessionManager Instance => _instance.Value;

        public UserEntity LoggedUser { get; private set; }

        private SessionManager() { }  

        public void Login(UserEntity user)
        {
            LoggedUser = user;
        }

        public void Logout()
        {
            LoggedUser = null;
        }
    }

}
