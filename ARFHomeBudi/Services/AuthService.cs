using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    public class AuthService
    {
        public const string AuthStateKey = "AuthState";
        
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(1000);
            return false;
        }

        //LOG USER IN
        public void Login()
        {
            Preferences.Default.Get<bool>(AuthStateKey, true);
        }

        //LOG USER OUT
        public void Logout()
        {
            Preferences.Default.Get<bool>(AuthStateKey, false);
        }
    }
}
