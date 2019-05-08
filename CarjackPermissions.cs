using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Game4Freak.CarjackPermissions
{
    public class CarjackPermissions : RocketPlugin<CarjackPermissionsConfiguration>
    {
        public static CarjackPermissions Instance;
        public const string VERSION = "0.1.0.0";

        protected override void Load()
        {
            Instance = this;
            Logger.Log("CarjackPermissions v" + VERSION);

            VehicleManager.onVehicleCarjacked += onVehicleCarjack;
        }

        protected override void Unload()
        {
            VehicleManager.onVehicleCarjacked -= onVehicleCarjack;
        }

        private void onVehicleCarjack(InteractableVehicle vehicle, Player instigatingPlayer, ref bool allow, ref Vector3 force, ref Vector3 torque)
        {
            if (!vehicle.isLocked) return;
            if (UnturnedPlayer.FromPlayer(instigatingPlayer).HasPermission(Configuration.Instance.ignorePermission)) return;
            if (vehicle.lockedOwner == UnturnedPlayer.FromPlayer(instigatingPlayer).CSteamID ||
                (Configuration.Instance.allowGroupCarjack && vehicle.lockedGroup == UnturnedPlayer.FromPlayer(instigatingPlayer).SteamGroupID)) return;
            allow = false;
        }
    }
}