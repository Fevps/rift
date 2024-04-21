using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using GorillaNetworking;
using Photon.Pun.UtilityScripts;
using Rift.Menu;

namespace Rift.Mods
{
    internal class Miscellaneous
    {
        public static void GetInfo()
        {
            if (!Directory.Exists("Rift"))
            {
                Directory.CreateDirectory("Rift");
            }
            if (!File.Exists("Rift\\ids.txt"))
            {
                File.Create("Rift\\ids.txt");
            }
            try
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                {
                    foreach (Player i in PhotonNetwork.PlayerListOthers)
                    {

                        string id = " Name:" + i.NickName + ", ID:" + i.UserId + ", Is-Master:" + i.IsMasterClient + ", Version:" + GorillaComputer.instance.version + ", Fake-Port:" + Variables.RandomNumberGenerator(4) + "." + Variables.RandomNumberGenerator(4);
                        IEnumerable<string> ids = id.Split();
                        if (!File.ReadLines("Rift\\ids.txt").Contains(id))
                        {
                            File.AppendAllLines("Rift\\ids.txt", ids);
                        }
                    }
                }
                Process.Start("Rift\\ids.txt");
            }
            catch
            {
                GetInfo();
            }
        }
    }
}
