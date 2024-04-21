using BepInEx;
using Photon.Pun;
using Photon.Voice.PUN.UtilityScripts;
using Steamworks;
using Rift.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Net;
using System.IO;
using System.Reflection;
using System.Collections;
using UnityEngine.Networking;

namespace Rift.Menu
{
    internal class Variables
    {
        public static float flySpeed = 8.5f;
        public static float playerSpeed = 7.5f;
        public static float playerMult = 1.2f;
        public static float armSize = 1.2f;
        public static float headSpeed = 10f;
        public static float slideControl = 250f;
        public static float timeDelay = 0f;
        public static float stringFloatHelper;
        public static float stringFloatHelper1;
        public static float fontSize = 0.6f;
        public static float playerScale;
        public static float speed = 0;
        public static float scale1 = 1f;

        public static float LeftTriggerIndex = ControllerInputPoller.instance.leftControllerIndexFloat;
        public static float LeftGripIndex = ControllerInputPoller.instance.leftControllerGripFloat;
        public static float RightTriggerIndex = ControllerInputPoller.instance.rightControllerIndexFloat;
        public static float RightGripIndex = ControllerInputPoller.instance.rightControllerGripFloat;

        public static bool casual = false;
        public static bool fected = false;
        public static bool ifDisabled = true;
        public static bool SpinnerX = false;
        public static bool SpinnerY = false;
        public static bool SpinnerZ = false;
        public static bool SpinnerS = false;
        public static bool inRoom = false;
        public static bool ifTime = false;
        public static bool isNoClip = false;
        public static bool isHolding = false;
        public static bool isGhost = false;
        public static bool isInvis = false;

        public static bool isPCSky = false;
        public static bool isPCFace = false;
        public static bool isPCNormal = true;
        public static bool isPCReportCam = false;
        public static bool isPCReportCam2 = false;
        public static bool isPCCity = false;

        public static bool isrgbMenu = false;
        public static bool isOutline = true;
        public static bool isOutline1 = true;
        public static bool isTransparent = false;
        public static bool PAGEisSide = false;
        public static bool PAGEisTop = false;
        public static bool PAGEisBottom = false;
        public static bool PAGEisLeft = false;
        public static bool PAGEisBottomV2 = true;
        public static bool disconnectTop = true;
        public static bool disconnectBottom = false;
        public static bool drawV2 = true;

        public static bool isMaster()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                return true;
            }
            return false;
        }

        public static bool inModded()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED"))
            {
                return true;
            }
            return false;
        }

        public static bool leftclick = false;
        public static bool rightclick = false;

        public static bool normalFont = true;

        public static bool na = false;
        public static bool eu = false;
        public static bool naw = false;

        public static bool theusefullestboolever = false;
        public static bool theusefullestboolever1 = false;
        public static bool EnableFirstPersonCamera;

        public static bool isActivated = false;

        public static bool LeftPrimary = ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool LeftSecondary = ControllerInputPoller.instance.leftControllerSecondaryButton;
        public static bool RightPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton;
        public static bool RightSecondary = ControllerInputPoller.instance.rightControllerSecondaryButton;

        //inputs
        //keys
        public static bool wkey = UnityInput.Current.GetKey(KeyCode.W) || UnityInput.Current.GetKey(KeyCode.UpArrow);
        public static bool akey = UnityInput.Current.GetKey(KeyCode.A) || UnityInput.Current.GetKey(KeyCode.LeftArrow);
        public static bool skey = UnityInput.Current.GetKey(KeyCode.S) || UnityInput.Current.GetKey(KeyCode.DownArrow);
        public static bool dkey = UnityInput.Current.GetKey(KeyCode.D) || UnityInput.Current.GetKey(KeyCode.RightArrow);
        public static bool ekey = UnityInput.Current.GetKey(KeyCode.E) || UnityInput.Current.GetKey(KeyCode.Insert);
        public static bool qkey = UnityInput.Current.GetKey(KeyCode.Q) || UnityInput.Current.GetKey(KeyCode.RightControl);
        public static bool Skey = UnityInput.Current.GetKey(KeyCode.Space) || UnityInput.Current.GetKey(KeyCode.LeftShift);
        public static bool Ckey = UnityInput.Current.GetKey(KeyCode.LeftControl) || UnityInput.Current.GetKey(KeyCode.RightControl);
        public static bool SSkey = UnityInput.Current.GetKey(KeyCode.LeftShift) || UnityInput.Current.GetKey(KeyCode.RightShift);
        //holdings
        public static bool isHoldingW = false;
        public static bool isHoldingA = false;
        public static bool isHoldingS = false;
        public static bool isHoldingD = false;
        public static bool isHoldingCTRL = false;
        public static bool isHoldingSPACE = false;
        public static bool isHoldingE = false;
        public static bool isHoldingQ = false;
        public static bool isHoldingClick = false;
        public static bool isNoClipping = false;
        public static bool isHoldingKey = false;
        public static bool joiningCode = false;
        //destinations
        public static bool isForest = false;
        public static bool isStump = false;
        public static bool isCity = false;
        public static bool isCanyon = false;
        public static bool isMountains = false;
        public static bool isTutorial = false;
        public static bool isClouds = false;
        public static bool isCaves = false;

        public static int MaxValue = int.MaxValue;
        public static int MinValue = int.MinValue;
        public static int themePage = 1;
        public static int themePresets = 1;
        public static int flyChanger = 0;
        public static int speedChanger = 0;
        public static int armsizeChanger = 0;
        public static int headaxisChanger = 0;
        public static int slidecontrolChanger = 0;
        public static int waypointChanger = 0;
        public static int menunameChanger = 0;
        public static int pageButtonChanger = 4;
        public static int disconnectChanger = 1;
        public static int menuPCposChanger = 1;
        public static int arrowtypeChanger = 1;
        public static int arrowType = 0;
        public static int fontChanger = 1;
        public static int rainbowmenu = 1;
        public static int slideSpeed = 1;

        public static int buttonSoundChanger = 1;
        public static int buttonIndex = 100;

        public static int conductStringHelper = 0;
        public static int conductStringHelper1 = 0;
        public static int FPSValue = 1;

        public static int randomNumber = UnityEngine.Random.Range(0, 1);
        public static int randomNumber1 = UnityEngine.Random.Range(0, 2);
        public static int randomNumber2 = UnityEngine.Random.Range(0, 3);
        public static int randomNumber3 = UnityEngine.Random.Range(0, 4);
        public static int randomNumber4 = UnityEngine.Random.Range(0, 5);
        public static int randomCodeNumber = UnityEngine.Random.Range(0, 12);

        public static System.Random random = new System.Random();

        public static GameObject ThePointer;
        public static GameObject BigDick = null;

        public static GameObject Forest = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
        public static GameObject City = GameObject.Find("Environment Objects/LocalObjects_Prefab/City");
        public static GameObject Canyons = GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon");
        public static GameObject Mountains = GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain");
        public static GameObject Sky = GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle");
        public static GameObject Caves = GameObject.Find("Environment Objects/LocalObjects_Prefab/Cave_Main_Prefab");
        public static GameObject Stump = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom");

        public static GameObject MoTD = GameObject.Find("motd"); // motd title
        public static GameObject CoC = GameObject.Find("CodeOfConduct"); // coc title
        public static GameObject MoTDScreen = GameObject.Find("motdtext"); // motd text
        public static GameObject CoCScreen = GameObject.Find("COC Text"); // coc text

        public static GameObject MotdColor = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen");

        public static GameObject Camera1 = GameObject.Find("Third Person Camera");
        public static GameObject Camera2 = GameObject.Find("CameraTablet(Clone)");
        public static GameObject CameraObjective;

        public static GameObject background;
        public static GameObject leftpage;
        public static GameObject rightpage;
        public static GameObject disconnect;

        public static GameObject LeftPlatform;
        public static GameObject RightPlatform;

        public static GameObject LaserPointer;
        public static GameObject PlayerTrail;
        public static GameObject Cham;

        public static GameObject ParentalConfiguration;

        public static Material SkyMaterial = GameObject.Find("Clouds").GetComponent<Material>();

        public static Vector3 SpinHead = GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset;
        public static Vector3 LeftHand = GorillaTagger.Instance.leftHandTransform.position;
        public static Vector3 RightHand = GorillaTagger.Instance.rightHandTransform.position;
        public static Vector3 LeftHandForward = GorillaTagger.Instance.leftHandTransform.forward;
        public static Vector3 RightHandForward = GorillaTagger.Instance.rightHandTransform.forward;
        public static Vector3 Body = GorillaTagger.Instance.bodyCollider.transform.position;
        public static Vector3 Head = GorillaTagger.Instance.headCollider.transform.position;

        public static Vector3 right = GorillaTagger.Instance.headCollider.transform.right;
        public static Vector3 forward = GorillaTagger.Instance.headCollider.transform.forward;
        public static Vector3 position = GorillaTagger.Instance.transform.position;

        public static Vector2 joyy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
        public static Vector2 joyx = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
        /*
        public static Vector2 joyy = ControllerInputPoller.instance.leftControllerPrimary2DAxis;
        public static Vector2 joyx = ControllerInputPoller.instance.leftControllerPrimary2DAxis; // i wish :sob:
        */

        //destinations
        public static Vector3 ForestDestination = new Vector3(-63.2165f, 2.4458f, -69.2397f);
        public static Vector3 StumpDestination = new Vector3(-66.8426f, 11.8702f, -82.9965f);
        public static Vector3 TutorialDestination = new Vector3(-82.4832f, 36.2805f, -67.2576f);
        public static Vector3 CityDestination = new Vector3(-55.6347f, 16.5433f, -105.9818f);
        public static Vector3 CanyonDestination = new Vector3(-87.8208f, 10.2235f, -115.7228f);
        public static Vector3 CavesDestination = new Vector3(-69.2063f, -12.282f, -30.9525f);
        public static Vector3 MountainsDestination = new Vector3(-20.0139f, 17.8684f, -97.0398f);
        public static Vector3 CloudsDestination = new Vector3(-76.5415f, 162.5568f, -97.8439f);

        public static Vector3 scale = new Vector3(0.13f, 0.13f, 0.13f);

        public static Color32 MenuColor1 = new Color32(0, 0, 0, 255);
        public static Color32 MenuColor2 = new Color32(0, 0, 0, 255);
        public static Color32 ButtonEnabled = new Color32(20, 20, 20, 255);
        public static Color32 ButtonDisabled = new Color32(50, 50, 50, 255);
        public static Color32 LeftPageButton = new Color32(50, 50, 50, 255);
        public static Color32 RightPageButton = new Color32(50, 50, 50, 255);
        public static Color32 DisconnectButton = new Color32(50, 50, 50, 255);
        public static Color32 ButtonText = Color.white;
        //public static Color32 ButtonText1 = new Color32(0, 0, 0, 255);

        public static Color rigColor = GorillaTagger.Instance.offlineVRRig.mainSkin.material.color;

        public static Shader GUIShader = Shader.Find("GUI/Text Shader");
        public static Shader UberShader = Shader.Find("GorillaTag/UberShader");

        public static GameObject lineFollow = new GameObject("Line");
        public static LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

        public static List<string> cocboardstrings = new List<string>();
        public static List<string> motdboardstrings = new List<string>();

        public static VRRig copiedPlayer;

        public static bool botthing = false;

        public static string[] Spoofer = new string[]
        {
            "BUTTHOLE",
            "GORILLA",
            "F3ISTHEBEST",
            "STINKY",
            "CATLICKER",
            "DITLEVSTINK",
        };

        public static string[] NameMods = new string[]
        {
            "PPBV",
            "J3VU",
            "DAISY09",
            "STATUE",
            "RUN",
            "SCREAMER",
            "GHOST",
            "NONAME",
        };

        public static string[] GhostCodes = new string[]
        {
            "GHOST",
            "BOT",
            "SCARY",
            "DAISY",
            "SREN17",
            "STATUE",
            "J3VU",
            "ECHO",
            "LURK",
            "TR33",
            "TR33S",
            "H3LP",
            "SPIDER",
        };

        public static string[] AmongUs = new string[]
        {
            @"
            ⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⢰⡿⠋⠁⠀⠀⠈⠉⠙⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⢀⣿⠇⠀⢀⣴⣶⡾⠿⠿⠿⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⣀⣀⣸⡿⠀⠀⢸⣿⣇⠀⠀⠀⠀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⣾⡟⠛⣿⡇⠀⠀⢸⣿⣿⣷⣤⣤⣤⣤⣶⣶⣿⠇⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀
            ⢀⣿⠀⢀⣿⡇⠀⠀⠀⠻⢿⣿⣿⣿⣿⣿⠿⣿⡏⠀⠀⠀⠀⢴⣶⣶⣿⣿⣿⣆
            ⢸⣿⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⣿⡇⣀⣠⣴⣾⣮⣝⠿⠿⠿⣻⡟
            ⢸⣿⠀⠘⣿⡇⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠉⠀
            ⠸⣿⠀⠀⣿⡇⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀
            ⠀⠻⣷⣶⣿⣇⠀⠀⠀⢠⣼⣿⣿⣿⣿⣿⣿⣿⣛⣛⣻⠉⠁⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⢸⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⢸⣿⣀⣀⣀⣼⡿⢿⣿⣿⣿⣿⣿⡿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠙⠻⠿⠟⠋⠑⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            "
        };

        public static string[] AmongUs2 = new string[]
        {                            
            @"                       
            ⠀⠀⠀⠀⠀⢀⣴⡾⠿⠿⠿⠿⢶⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⢠⣿⠁⠀⠀⠀⣀⣀⣀⣈⣻⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⣾⡇⠀⠀⣾⣟⠛⠋⠉⠉⠙⠛⢷⣄⠀⠀⠀⠀⠀⠀⠀
            ⢀⣤⣴⣶⣿⠀⠀⢸⣿⣿⣧⠀⠀⠀⠀⢀⣀⢹⡆⠀⠀⠀⠀⠀⠀
            ⢸⡏⠀⢸⣿⠀⠀⠀⢿⣿⣿⣷⣶⣶⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀
            ⣼⡇⠀⢸⣿⠀⠀⠀⠈⠻⠿⣿⣿⠿⠿⠛⢻⡇⠀⠀⠀⠀⠀⠀⠀
            ⣿⡇⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣼⣷⣶⣶⣶⣤⡀⠀⠀
            ⣿⡇⠀⢸⣿⠀⠀⠀⠀⠀⠀⣀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀
            ⢻⡇⠀⢸⣿⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⡿⠿⣿⣿⣿⣿⡇
            ⠈⠻⠷⠾⣿⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⢸⣿⣿⣿⣇
            ⠀⠀⠀⠀⣿⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⢸⣿⣿⣿⡿
            ⠀⠀⠀⠀⢿⣧⣀⣠⣴⡿⠙⠛⠿⠿⠿⠿⠉⠀⠀⢠⣿⣿⣿⣿⠇
            ⠀⠀⠀⠀⠀⢈⣩⣭⣥⣤⣤⣤⣤⣤⣤⣤⣤⣤⣶⣿⣿⣿⣿⠏⠀
            ⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀
            ⠀⠀⠀⢸⣿⣿⣿⡟⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠋⠁⠀⠀⠀⠀
            ⠀⠀⠀⢸⣿⣿⣿⣷⣄⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠈⠛⠿⠿⣿⣿⣿⣿⣿⠿⠿⢿⣿⣿⣿⣿⣿⡄⠀⠀
            ⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⢀⣹⣿⣿⣿⡇⠀⠀
            ⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀
            ⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠀⠀⠀
            ⠀⠀⠀⠀⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠉⠉⠁⢤⣤⣤⣤⣤⣤⣤⡀
            ⠀⠀⠀⠀⢿⣿⣿⣿⣷⣶⣶⣶⣶⣾⣿⣿⣿⣆⢻⣿⣿⣿⣿⣿⡇
            ⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠻⣿⣿⣿⡿⠁
            ⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠉⠀⠙⠛⠉⠀⠀
            "                        
        };                            

        public static string[][] arrowTypes = new string[][]//iidk's
        {
            new string[] {"<", ">"},
            new string[] {"←", "→"},
            new string[] {"↞", "↠"},
            new string[] {"◄", "►"},
            new string[] {"〈 ", " 〉"},
            new string[] {"‹", "›"},
            new string[] {"«", "»"},
            new string[] {"◀", "▶"},
            new string[] {"-", "+"},
            new string[] {"", ""},
        };

        public const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public const string characters1 = "1234567890";
        public static string TextConfiguration = "<";
        public static string TextConfiguration1 = ">";

        public static string RandomNumberGenerator(int length)
        {
            StringBuilder stringHelper = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characters1.Length);
                stringHelper.Append(characters1[index]);
            }
            return stringHelper.ToString();
        }

        public static string RandomGenerator(int length)
        {
            StringBuilder stringHelper = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characters.Length);
                stringHelper.Append(characters[index]);
            }
            return stringHelper.ToString();
        } // RandomGenerator(index);

        public static void RigSizer()
        {
            playerScale = 1f;
            GorillaLocomotion.Player.Instance.scale = 1f;
        }

        public static void EnableModeratorStick()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/Mod Stick Anchor/MOD STICK").SetActive(true);
        }

        public static void DisableModeratorStick()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/Mod Stick Anchor/MOD STICK").SetActive(false);
        }

        public static void EnableFingerPainter()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/2023_04DungeonV2 Body/LBADE.").SetActive(true);
        }

        public static void DisableFingerPainter()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/2023_04DungeonV2 Body/LBADE.").SetActive(false);
        } // best code right here guys

        public static void EnableAdminBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(true);
        }

        public static void DisableAdminBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(false);
        }
    }
}
