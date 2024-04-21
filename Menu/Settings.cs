using Steamworks;
using Rift.Classes;
using Rift.Menu;
using System.Net;
using UnityEngine;
using static Rift.Menu.Main;

namespace Rift
{
    internal class Settings
    {
        public static Color MenuColor = Color.black;
        public static Color SideButtonsColor = Color.black;
        public static ExtGradient backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.black) };
        public static ExtGradient isRainbowMenu = new ExtGradient { isRainbow = true };
        public static Color[] textColors = new Color[]
        {
            Variables.ButtonText, // Disabled 0
            Variables.ButtonText // Enabled 1
        };
        public static Color OutlineColor = new Color32(50, 50, 50, 255);
        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        public static Font Gothic = (Resources.GetBuiltinResource(typeof(Font), "MS Gothic") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static int SavePage;
        public static bool ResetToDefault = false;

        public static KeyCode keyboardButton = KeyCode.R;

        public static Vector3 menuSize = new Vector3(0.1f, 0.88f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 8;
    }
}
