using Rocket.API;
using System.Collections.Generic;

namespace Game4Freak.CarjackPermissions
{
    public class CarjackPermissionsConfiguration : IRocketPluginConfiguration
    {
        public bool allowGroupCarjack;

        public string ignorePermission;

        public void LoadDefaults()
        {
            allowGroupCarjack = true;
            ignorePermission = "carjack.all";
        }
    }
}
