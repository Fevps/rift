using static Rift.Menu.Main;
using static Rift.Settings;

namespace Rift.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            SavePage = pageNumber;
            buttonsType = 1;
            pageNumber = 0;
        }

        public static void RoomSettings()
        {
            SavePage = pageNumber;
            buttonsType = 2;
            pageNumber = 0;
        }

        public static void MenuSettings()
        {
            SavePage = pageNumber;
            buttonsType = 3;
            pageNumber = 0;
        }

        public static void MovementSettings()
        {
            SavePage = pageNumber;
            buttonsType = 4;
            pageNumber = 0;
        }

        public static void ProjectileSettings()
        {
            SavePage = pageNumber;
            buttonsType = 5;
            pageNumber = 0;
        }

        public static void PlayerSettings()
        {
            SavePage = pageNumber;
            buttonsType = 8;
            pageNumber = 0;
        }

        public static void MiscellaneousSettings()
        {
            SavePage = pageNumber;
            buttonsType = 3;
            pageNumber = 0;
        }

        public static void EntitySettings()
        {
            SavePage = pageNumber;
            buttonsType = 9;
            pageNumber = 0;
        }

        public static void OtherPlayerSettings()
        {
            SavePage = pageNumber;
            buttonsType = 10;
            pageNumber = 0;
        }

        public static void VisualSettings()
        {
            SavePage = pageNumber;
            buttonsType = 6;
            pageNumber = 0;
        }

        public static void AntiReportSettings()
        {
            SavePage = pageNumber;
            buttonsType = 11;
            pageNumber = 0;
        }

        public static void GameModeMods()
        {
            SavePage = pageNumber;
            buttonsType = 12;
            pageNumber = 0;
        }

        public static void SafetySettings()
        {
            SavePage = pageNumber;
            buttonsType = 7;
            pageNumber = 0;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }
    }
}
