using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using PlayFab.ProfilesModels;
using Rift.Classes;
using Rift.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using WebSocketSharp;

namespace Rift.Mods
{
    internal class Configuration
    {
        public static void ChangePlayerSpeed()
        {
            Variables.speedChanger++;
            if (Variables.speedChanger == 0)
            {
                Variables.playerSpeed = 6.5f;
                Variables.playerMult = 1.1f;
            }
            else if (Variables.speedChanger == 1)
            {
                Variables.playerSpeed = 8f;
                Variables.playerMult = 1.35f;
            }
            else if (Variables.speedChanger == 2)
            {
                Variables.playerSpeed = 10f;
                Variables.playerMult = 1.585f;
            }
            else if (Variables.speedChanger == 3)
            {
                Variables.playerSpeed = 12f;
                Variables.playerMult = 1.75f;
                Variables.speedChanger = -1;
            }
            Main.RecreateMenu();
        }

        public static void ChangeSlideControl()
        {
            Variables.slidecontrolChanger++;
            if (Variables.slidecontrolChanger == 0)
            {
                Variables.slideControl = 850f;
            }
            else if (Variables.slidecontrolChanger == 1)
            {
                Variables.slideControl = 525f;
            }
            else if (Variables.slidecontrolChanger == 2)
            {
                Variables.slideControl = 250f;
            }
            else if (Variables.slidecontrolChanger == 3)
            {
                Variables.slideControl = 125f;
            }
            else if (Variables.slidecontrolChanger == 4)
            {
                Variables.slideControl = 25f;
                Variables.slidecontrolChanger = -1;
            }
            Main.RecreateMenu();
        }

        public static void ChangeFlySpeed()
        {
            Variables.flyChanger++;
            if (Variables.flyChanger == 0)
            {
                Variables.flySpeed = 8.5f;
            }
            else if (Variables.flyChanger == 1)
            {
                Variables.flySpeed = 10f;
            }
            else if (Variables.flyChanger == 2)
            {
                Variables.flySpeed = 15f;
            }
            else if (Variables.flyChanger == 3)
            {
                Variables.flySpeed = 20f;
                Variables.flyChanger = -1;
            }
            Main.RecreateMenu();
        }

        public static void ChangeArmSize()
        {
            Variables.armsizeChanger++;
            if (Variables.armsizeChanger == 0)
            {
                Variables.armSize = 1f;
            }
            else if (Variables.armsizeChanger == 1)
            {
                Variables.armSize = 1.2f;
            }
            else if (Variables.armsizeChanger == 2)
            {
                Variables.armSize = 1.4f;
            }
            else if (Variables.armsizeChanger == 3)
            {
                Variables.armSize = 1.6f;
            }
            else if (Variables.armsizeChanger == 4)
            {
                Variables.armSize = 1.8f;
            }
            else if (Variables.armsizeChanger == 5)
            {
                Variables.armSize = 2f;
                Variables.armsizeChanger = -1;
            }
            Main.RecreateMenu();
        }

        public static void FirstPersonCamera()
        {
            if (Variables.Camera1 != null)
            {
                Variables.Camera1.transform.position = GorillaTagger.Instance.headCollider.transform.position;
                Variables.Camera1.transform.GetComponent<Camera>().fieldOfView = 107.5f;
                Variables.Camera1.transform.GetComponent<Camera>().focusDistance = 100f;
                Variables.Camera2 = null;
            }
            if (Variables.Camera2 != null)
            {
                Variables.Camera2.transform.position = GorillaTagger.Instance.headCollider.transform.position;
                Variables.Camera2.transform.GetComponent<Camera>().fieldOfView = 107.5f;
                Variables.Camera2.transform.GetComponent<Camera>().focusDistance = 100f;
                Variables.Camera1 = null;
            }
        }

        public static void FirstPersonCameraFix()
        {
            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed && Mouse.current.rightButton.isPressed)
            {
                Variables.leftclick = true;
                Variables.rightclick = true;
            }

            if (Variables.leftclick && Variables.rightclick)
            {
                Variables.EnableFirstPersonCamera = true;
                if (GameObject.Find("Third Person Camera") != null)
                {
                    Variables.CameraObjective = GameObject.Find("Third Person Camera");
                    Variables.CameraObjective.SetActive(false);
                }
                if (GameObject.Find("CameraTablet(Clone)") != null)
                {
                    Variables.CameraObjective = GameObject.Find("CameraTablet(Clone)");
                    Variables.CameraObjective.SetActive(false);
                }
            }
            else
            {
                Variables.EnableFirstPersonCamera = false;
                if (Variables.CameraObjective != null)
                {
                    Variables.CameraObjective.SetActive(true);
                    Variables.CameraObjective = null;
                }
            }

            if (!Variables.leftclick && !Variables.rightclick)
            {
                Variables.EnableFirstPersonCamera = false;
                if (Variables.CameraObjective != null)
                {
                    Variables.CameraObjective.SetActive(true);
                    Variables.CameraObjective = null;
                }
            }

            if (!Mouse.current.leftButton.isPressed && Mouse.current.rightButton.isPressed)
            {
                Variables.leftclick = false;
                Variables.rightclick = false;
                Variables.EnableFirstPersonCamera = false;
                if (Variables.CameraObjective != null)
                {
                    Variables.CameraObjective.SetActive(true);
                    Variables.CameraObjective = null;
                }
            }
        }

        public static void DisableFPC()
        {
            Variables.EnableFirstPersonCamera = false;
            if (Variables.CameraObjective != null)
            {
                Variables.CameraObjective.SetActive(true);
                Variables.CameraObjective = null;
            }
            Variables.leftclick = false;
            Variables.rightclick = false;
        }
        public static int CurrentTheme = 0;
        public static void ChangeMenuThemeV2()
        {
            CurrentTheme++;
            if (CurrentTheme == 0) // DEFAULT
            {
                Settings.MenuColor = Color.black;
                Variables.ButtonDisabled = new Color32(50, 50, 50, 255);
                Variables.ButtonEnabled = new Color32(20, 20, 20, 255);
                Settings.SideButtonsColor = Color.black;
                Settings.OutlineColor = new Color32(50, 50, 50, 255);
            }
            else if (CurrentTheme == 1) // PURPLE PINK
            {
                Settings.MenuColor = new Color32(159, 90, 253, 1);
                Variables.ButtonDisabled = new Color32(102, 51, 153, 1);
                Variables.ButtonEnabled = new Color32(132, 81, 183, 1);
                Settings.SideButtonsColor = new Color32(159, 90, 253, 1);
                Settings.OutlineColor = new Color32(102, 51, 153, 1);
            }
            else if (CurrentTheme == 2) //BLUE GREY
            {
                Settings.MenuColor = new Color32(50, 50, 50, 1);
                Variables.ButtonDisabled = new Color32(40, 67, 135, 1);
                Variables.ButtonEnabled = new Color32(14, 24, 115, 1);
                Settings.SideButtonsColor = new Color32(50, 50, 50, 1);
                Settings.OutlineColor = new Color32(40, 67, 135, 1);
            }
            else if (CurrentTheme == 3) // PINK
            {
                Settings.MenuColor = new Color32(250, 207, 236, 1);
                Variables.ButtonDisabled = new Color32(228, 173, 255, 1);
                Variables.ButtonEnabled = new Color32(221, 153, 255, 1);
                Settings.SideButtonsColor = new Color32(250, 207, 236, 1);
                Settings.OutlineColor = new Color32(228, 173, 255, 1);
            }
            else if (CurrentTheme == 4) // MINTY
            {
                Settings.MenuColor = new Color32(194, 255, 241, 1);
                Variables.ButtonDisabled = new Color32(0, 186, 143, 1);
                Variables.ButtonEnabled = new Color32(194, 255, 241, 1);
                Settings.SideButtonsColor = new Color32(194, 255, 241, 1);
                Settings.OutlineColor = new Color32(0, 186, 143, 1);
            }
            else if (CurrentTheme == 5) // MAGENTA
            {
                Settings.MenuColor = new Color32(0, 0, 0, 1);
                Variables.ButtonDisabled = new Color32(255, 115, 220, 1);
                Variables.ButtonEnabled = new Color32(201, 22, 156, 1);
                Settings.SideButtonsColor = new Color32(0, 0, 0, 1);
                Settings.OutlineColor = new Color32(255, 0, 191, 1);
            }
            else if (CurrentTheme == 6) // ORANGE
            {
                Settings.MenuColor = new Color32(255, 89, 0, 1);
                Variables.ButtonDisabled = new Color32(255, 126, 56, 1);
                Variables.ButtonEnabled = new Color32(201, 22, 156, 1);
                Settings.SideButtonsColor = new Color32(255, 89, 0, 1);
                Settings.OutlineColor = new Color32(255, 126, 56, 1);
                CurrentTheme = -1;
            }
            Main.RecreateMenu();
        }
        /*public static void ChangeMenuTheme()
        {
            Variables.themePage++;
            if (Variables.themePage > 25)
            {
                Variables.themePage = 1;
            }
            if (Variables.themePage == 1)
            {
                Variables.ButtonDisabled = new Color32(50, 50, 50, 255);
                Variables.DisconnectButton = new Color32(50, 50, 50, 255);
                Variables.LeftPageButton = new Color32(50, 50, 50, 255);
                Variables.RightPageButton = new Color32(50, 50, 50, 255);
            }
            if (Variables.themePage == 2)
            {
                Variables.ButtonDisabled = new Color32(100, 100, 75, 255);
                Variables.DisconnectButton = new Color32(100, 100, 75, 255);
                Variables.LeftPageButton = new Color32(100, 100, 75, 255);
                Variables.RightPageButton = new Color32(100, 100, 75, 255);
            }
            if (Variables.themePage == 3)
            {
                Variables.ButtonDisabled = new Color32(255, 0, 0, 30);
                Variables.DisconnectButton = new Color32(255, 0, 0, 30);
                Variables.LeftPageButton = new Color32(255, 0, 0, 30);
                Variables.RightPageButton = new Color32(255, 0, 0, 30);
            }
            if (Variables.themePage == 4)
            {
                Variables.ButtonDisabled = new Color32(235, 116, 52, 255);
                Variables.DisconnectButton = new Color32(235, 116, 52, 255);
                Variables.LeftPageButton = new Color32(235, 116, 52, 255);
                Variables.RightPageButton = new Color32(235, 116, 52, 255);
            }
            if (Variables.themePage == 5)
            {
                Variables.ButtonDisabled = new Color32(235, 229, 52, 255);
                Variables.DisconnectButton = new Color32(235, 229, 52, 255);
                Variables.LeftPageButton = new Color32(235, 229, 52, 255);
                Variables.RightPageButton = new Color32(235, 229, 52, 255);
            }
            if (Variables.themePage == 5)
            {
                Variables.ButtonDisabled = new Color32(74, 101, 237, 255);
                Variables.DisconnectButton = new Color32(74, 101, 237, 255);
                Variables.LeftPageButton = new Color32(74, 101, 237, 255);
                Variables.RightPageButton = new Color32(74, 101, 237, 255);
            }
            if (Variables.themePage == 6)
            {
                Variables.ButtonDisabled = new Color32(196, 74, 237, 255);
                Variables.DisconnectButton = new Color32(196, 74, 237, 255);
                Variables.LeftPageButton = new Color32(196, 74, 237, 255);
                Variables.RightPageButton = new Color32(196, 74, 237, 255);
            }
            if (Variables.themePage == 7)
            {
                Variables.ButtonDisabled = new Color32(237, 74, 180, 255);
                Variables.DisconnectButton = new Color32(237, 74, 180, 255);
                Variables.LeftPageButton = new Color32(237, 74, 180, 255);
                Variables.RightPageButton = new Color32(237, 74, 180, 255);
            }
            if (Variables.themePage == 8)
            {
                Variables.ButtonDisabled = new Color32(99, 14, 37, 255);
                Variables.DisconnectButton = new Color32(99, 14, 37, 255);
                Variables.LeftPageButton = new Color32(99, 14, 37, 255);
                Variables.RightPageButton = new Color32(99, 14, 37, 255);
            }
            if (Variables.themePage == 9)
            {
                Variables.ButtonDisabled = new Color32(171, 169, 170, 255);
                Variables.DisconnectButton = new Color32(171, 169, 170, 255);
                Variables.LeftPageButton = new Color32(171, 169, 170, 255);
                Variables.RightPageButton = new Color32(171, 169, 170, 255);
            }
            if (Variables.themePage == 10)
            {
                Variables.ButtonDisabled = new Color32(61, 235, 226, 10);
                Variables.DisconnectButton = new Color32(61, 235, 226, 10);
                Variables.LeftPageButton = new Color32(61, 235, 226, 10);
                Variables.RightPageButton = new Color32(61, 235, 226, 10);
            }
            if (Variables.themePage == 11)
            {
                Variables.ButtonDisabled = new Color32(0, 255, 17, 255);
                Variables.DisconnectButton = new Color32(0, 255, 17, 255);
                Variables.LeftPageButton = new Color32(0, 255, 17, 255);
                Variables.RightPageButton = new Color32(0, 255, 17, 255);
            }
            if (Variables.themePage == 12)
            {
                Variables.ButtonDisabled = new Color32(255, 255, 0, 255);
                Variables.DisconnectButton = new Color32(255, 255, 0, 255);
                Variables.LeftPageButton = new Color32(255, 255, 0, 255);
                Variables.RightPageButton = new Color32(255, 255, 0, 255);
            }
            if (Variables.themePage == 13)
            {
                Variables.ButtonDisabled = new Color32(0, 26, 255, 255);
                Variables.DisconnectButton = new Color32(0, 26, 255, 255);
                Variables.LeftPageButton = new Color32(0, 26, 255, 255);
                Variables.RightPageButton = new Color32(0, 26, 255, 255);
            }
            if (Variables.themePage == 14)
            {
                Variables.ButtonDisabled = new Color32(255, 0, 204, 255);
                Variables.DisconnectButton = new Color32(255, 0, 204, 255);
                Variables.LeftPageButton = new Color32(255, 0, 204, 255);
                Variables.RightPageButton = new Color32(255, 0, 204, 255);
            }
            if (Variables.themePage == 15)
            {
                Variables.ButtonDisabled = new Color32(255, 133, 186, 255);
                Variables.DisconnectButton = new Color32(255, 133, 186, 255);
                Variables.LeftPageButton = new Color32(255, 133, 186, 255);
                Variables.RightPageButton = new Color32(255, 133, 186, 255);
            }
            if (Variables.themePage == 16)
            {
                Variables.ButtonDisabled = new Color32(156, 179, 255, 255);
                Variables.DisconnectButton = new Color32(156, 179, 255, 255);
                Variables.LeftPageButton = new Color32(156, 179, 255, 255);
                Variables.RightPageButton = new Color32(156, 179, 255, 255);
            }
            if (Variables.themePage == 17)
            {
                Variables.ButtonDisabled = new Color32(156, 255, 204, 255);
                Variables.DisconnectButton = new Color32(156, 255, 204, 255);
                Variables.LeftPageButton = new Color32(156, 255, 204, 255);
                Variables.RightPageButton = new Color32(156, 255, 204, 255);
            }
            if (Variables.themePage == 18)
            {
                Variables.ButtonDisabled = new Color32(181, 255, 156, 255);
                Variables.DisconnectButton = new Color32(181, 255, 156, 255);
                Variables.LeftPageButton = new Color32(181, 255, 156, 255);
                Variables.RightPageButton = new Color32(181, 255, 156, 255);
            }
            if (Variables.themePage == 19)
            {
                Variables.ButtonDisabled = new Color32(255, 232, 156, 255);
                Variables.DisconnectButton = new Color32(255, 232, 156, 255);
                Variables.LeftPageButton = new Color32(255, 232, 156, 255);
                Variables.RightPageButton = new Color32(255, 232, 156, 255);
            }
            if (Variables.themePage == 20)
            {
                Variables.ButtonDisabled = new Color32(255, 179, 156, 255);
                Variables.DisconnectButton = new Color32(255, 179, 156, 255);
                Variables.LeftPageButton = new Color32(255, 179, 156, 255);
                Variables.RightPageButton = new Color32(255, 179, 156, 255);
            }
            if (Variables.themePage == 21)
            {
                Variables.ButtonDisabled = new Color32(0, 0, 0, 255);
                Variables.DisconnectButton = new Color32(0, 0, 0, 255);
                Variables.LeftPageButton = new Color32(0, 0, 0, 255);
                Variables.RightPageButton = new Color32(0, 0, 0, 255);
            }
            if (Variables.themePage == 22)
            {
                Variables.ButtonDisabled = new Color32(193, 214, 163, 255);
                Variables.DisconnectButton = new Color32(193, 214, 163, 255);
                Variables.LeftPageButton = new Color32(193, 214, 163, 255);
                Variables.RightPageButton = new Color32(193, 214, 163, 255);
            }
            if (Variables.themePage == 23)
            {
                Variables.ButtonDisabled = new Color32(87, 74, 20, 255);
                Variables.DisconnectButton = new Color32(87, 74, 20, 255);
                Variables.LeftPageButton = new Color32(87, 74, 20, 255);
                Variables.RightPageButton = new Color32(87, 74, 20, 255);
            }
            if (Variables.themePage == 24)
            {
                Variables.ButtonDisabled = new Color32(60, 18, 74, 255);
                Variables.DisconnectButton = new Color32(60, 18, 74, 255);
                Variables.LeftPageButton = new Color32(60, 18, 74, 255);
                Variables.RightPageButton = new Color32(60, 18, 74, 255);
            }
            if (Variables.themePage == 25)
            {
                Variables.ButtonDisabled = new Color32(255, 99, 219, 255);
                Variables.DisconnectButton = new Color32(255, 99, 219, 255);
                Variables.LeftPageButton = new Color32(255, 99, 219, 255);
                Variables.RightPageButton = new Color32(255, 99, 219, 255);
            }
            Main.RecreateMenu();
        }*/

        public static void EnableMenuOutline()
        {
            Variables.isOutline = true;
            Main.RecreateMenu();
        }

        public static void DisableMenuOutline()
        {
            Variables.isOutline = false;
            if (!Variables.isOutline)
            {
                UnityEngine.Object.Destroy(Variables.background);
                UnityEngine.Object.Destroy(Variables.background.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(Variables.background.GetComponent<BoxCollider>());
            }
        }

        public static void EnableMenuOutline1()
        {
            Variables.isOutline1 = true;
            Main.RecreateMenu();
        }

        public static void DisableMenuOutline1()
        {
            Variables.isOutline1 = false;
            if (!Variables.isOutline1)
            {
                UnityEngine.Object.Destroy(Variables.background);
                UnityEngine.Object.Destroy(Variables.background.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(Variables.background.GetComponent<BoxCollider>());
            }
        }

        public static void LessLaggyServers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                PhotonNetwork.Disconnect();
                if (!PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                {
                    PhotonNetwork.ConnectToBestCloudServer();
                }
            }
            else
            {
                PhotonNetwork.ConnectToBestCloudServer();
            }
        }

        public static void DisableAfkKick()
        {
            PhotonNetworkController.Instance.disableAFKKick = true;
        }

        public static void EnableAfkKick()
        {
            PhotonNetworkController.Instance.disableAFKKick = false;
        }

        public static void DisableAntiCheatCrash()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(false);
        }

        public static void FixAntiCheatCrashing()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(true);
        }

        public static void DisableQuitBox()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/QuitBox").SetActive(false);
        }

        public static void EnableQuitBox()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/QuitBox").SetActive(true);
        }

        public static void USRegion()
        {
            Variables.na = true;
            PhotonNetwork.ConnectToRegion("us");
        }

        public static void USWestRegion()
        {
            Variables.naw = true;
            PhotonNetwork.ConnectToRegion("usw");
        }

        public static void EURegion()
        {
            Variables.eu = true;
            PhotonNetwork.ConnectToRegion("eu");
        }

        public static void ConnectToUSRegion()
        {
            if (Variables.na)
            {
                if (!PhotonNetwork.InRoom)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/City").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                }
                else
                {
                    PhotonNetwork.Disconnect();
                    ConnectToUSRegion();
                }
            }
            else
            {
                PhotonNetwork.Disconnect();
                Variables.na = false;
            }
            USRegion();
        }

        public static void ConnectToUSWestRegion()
        {
            if (Variables.naw)
            {
                if (!PhotonNetwork.InRoom)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/City").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                }
                else
                {
                    PhotonNetwork.Disconnect();
                    ConnectToUSWestRegion();
                }
            }
            else
            {
                PhotonNetwork.Disconnect();
                Variables.naw = false;
            }
            USWestRegion();
        }

        public static void ConnectToEURegion()
        {
            if (Variables.eu)
            {
                if (!PhotonNetwork.InRoom)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/City").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon").activeSelf == true)
                    {
                        GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    }
                }
                else
                {
                    PhotonNetwork.Disconnect();
                    ConnectToEURegion();
                }
            }
            else
            {
                PhotonNetwork.Disconnect();
                Variables.eu = false;
            }
            EURegion();
        }

        public static void ChangeMenuPCPosition()
        {
            Variables.menuPCposChanger++;
            if (Variables.menuPCposChanger > 5)
            {
                Variables.menuPCposChanger = 1;
            }
            if (Variables.menuPCposChanger == 1)
            {
                Variables.isPCNormal = true;
                Variables.isPCFace = false;
                Variables.isPCSky = false;
                Variables.isPCReportCam = false;
                Variables.isPCCity = false;
            }
            if (Variables.menuPCposChanger == 2)
            {
                Variables.isPCSky = true;
                Variables.isPCNormal = false;
                Variables.isPCFace = false;
                Variables.isPCReportCam = false;
                Variables.isPCCity = false;
            }
            if (Variables.menuPCposChanger == 3)
            {
                Variables.isPCFace = true;
                Variables.isPCNormal = false;
                Variables.isPCSky = false;
                Variables.isPCReportCam = false;
                Variables.isPCCity = false;
            }
            if (Variables.menuPCposChanger == 4)
            {
                Variables.isPCReportCam = true;
                Variables.isPCFace = false;
                Variables.isPCNormal = false;
                Variables.isPCSky = false;
                Variables.isPCCity = false;
            }
            if (Variables.menuPCposChanger == 5)
            {
                Variables.isPCReportCam = false;
                Variables.isPCFace = false;
                Variables.isPCNormal = false;
                Variables.isPCSky = false;
                Variables.isPCCity = true;
            }
            Main.RecreateMenu();
        }

        public static void ChangeArrowType()
        {
            Variables.arrowtypeChanger++;
            if (Variables.arrowtypeChanger == 6)
            {
                Variables.arrowtypeChanger = 1;
            }
            if (Variables.arrowtypeChanger == 1)
            {
                Variables.TextConfiguration1 = ">";
                Variables.TextConfiguration = "<";
            }
            if (Variables.arrowtypeChanger == 2)
            {
                Variables.TextConfiguration1 = "→";
                Variables.TextConfiguration = "←";
            }
            if (Variables.arrowtypeChanger == 3)
            {
                Variables.TextConfiguration1 = "►";
                Variables.TextConfiguration = "◄";
            }
            if (Variables.arrowtypeChanger == 4)
            {
                Variables.TextConfiguration1 = "▶";
                Variables.TextConfiguration = "◀";
            }
            if (Variables.arrowtypeChanger == 5)
            {
                Variables.TextConfiguration1 = "+";
                Variables.TextConfiguration = "-";
            }
            if (Variables.arrowtypeChanger == 6)
            {
                Variables.TextConfiguration1 = "»";
                Variables.TextConfiguration = "«";
            }
        }

        public static void ChangeButtonSoundType()
        {
            Variables.buttonSoundChanger++;
            if (Variables.buttonSoundChanger > 12)
            {
                Variables.buttonSoundChanger = 1;
            }
            if (Variables.buttonSoundChanger == 1)
            {
                Variables.buttonIndex = 100;
            }
            if (Variables.buttonSoundChanger == 2)
            {
                Variables.buttonIndex = 66;
            }
            if (Variables.buttonSoundChanger == 3)
            {
                Variables.buttonIndex = 135;
            }
            if (Variables.buttonSoundChanger == 4)
            {
                Variables.buttonIndex = 3;
            }
            if (Variables.buttonSoundChanger == 5)
            {
                Variables.buttonIndex = 45;
            }
            if (Variables.buttonSoundChanger == 6)
            {
                Variables.buttonIndex = 67;
            }
            if (Variables.buttonSoundChanger == 7)
            {
                Variables.buttonIndex = 71;
            }
            if (Variables.buttonSoundChanger == 8)
            {
                Variables.buttonIndex = 84;
            }
            if (Variables.buttonSoundChanger == 9)
            {
                Variables.buttonIndex = 51;
            }
            if (Variables.buttonSoundChanger == 10)
            {
                Variables.buttonIndex = 37;
            }
            if (Variables.buttonSoundChanger == 11)
            {
                Variables.buttonIndex = 43;
            }
            if (Variables.buttonSoundChanger == 12)
            {
                Variables.buttonIndex = 4;
            }
            Main.RecreateMenu();
        }

        public static void ChangeSlideControlControl()
        {
            Variables.slideSpeed++;
            if (Variables.slideSpeed > 3)
            {
                Variables.slideSpeed = 1;
            }
            if (Variables.slideSpeed == 1)
            {
                Variables.slideControl = float.MaxValue;
            }
            if (Variables.slideSpeed == 2)
            {
                Variables.slideControl = 75;
            }
            if (Variables.slideSpeed == 3)
            {
                Variables.slideControl = 50f;
            }
        }
    }
}
