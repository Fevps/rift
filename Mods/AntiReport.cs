using Photon.Pun;
using Rift.Notifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static DevConsole.MessagePayload;
using UnityEngine;
using Object = UnityEngine.Object;
using Color = UnityEngine.Color;
using Rift.Menu;
using UnityEngine.InputSystem;

namespace Rift.Mods
{
    internal class AntiReport
    {
        public static GameObject arBlock = null;
        public static float range = 2.0f;
        public static Vector3 size = new Vector3(1.5f, 1.5f, 1.5f);
        public static Color GetColor = Variables.ButtonDisabled;
        public static void GameObjectAntiReport()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                if (arBlock == null)
                {
                    arBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    arBlock.transform.localScale = size;
                    arBlock.GetComponent<Renderer>().material.color = GetColor;
                    Object.Destroy(arBlock.GetComponent<BoxCollider>());
                    Object.Destroy(arBlock.GetComponent<Rigidbody>());
                }
                arBlock.transform.position = GorillaTagger.Instance.leftHandTransform.position + Vector3.forward * 0.5f;
            }
            else
            {
                if (arBlock != null)
                {
                    foreach (VRRig i in GorillaParent.instance.vrrigs)
                    {
                        if (i != GorillaTagger.Instance.offlineVRRig)
                        {
                            float distance = Vector3.Distance(i.transform.position, arBlock.transform.position);
                            if (distance <= range)
                            {
                                PhotonNetwork.Disconnect();
                                NotifiLib.SendNotification("Somebody reached the game object, you've been disconnected.");
                            }
                        }
                    }
                }
            }
            if (arBlock != null)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        float distance = Vector3.Distance(i.transform.position, arBlock.transform.position);
                        if (distance <= range)
                        {
                            PhotonNetwork.Disconnect();
                            NotifiLib.SendNotification("Somebody reached the game object, you've been disconnected.");
                        }
                    }
                }
            }
        }

        public static GameObject AntireportBlock = null;
        public static GameObject AntiReportCityBlock = null;
        public static GameObject CityReportScoreBoard = GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/monitor (1)");
        public static GameObject AntiReportSkyBlock = null;
        public static GameObject SkyBoard = GameObject.Find("skyjungle/UI/Scoreboard/scoreboard (2)/board");
        public static GameObject CanyonBoard = GameObject.Find("Canyon/Canyon/canyonmonitor");
        public static GameObject CanyonReport = null;
        public static GameObject BeachBoard = GameObject.Find("Beach/scoreboard (2)/board");
        public static GameObject BeachReport = null;
        public static GameObject CavesBoard = GameObject.Find("Cave_Main_Prefab/CaveGameplayObjects/scoreboard (3)/board");
        public static GameObject CavesReport = null;
        public static GameObject MountainsBoard = GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/Mirror Effect Toggle/StopMirrorEffect");
        public static GameObject MountainsReport = null;
        public static GameObject RotatingBoard = GameObject.Find("RotatingMap/DO-NOT-TOUCH/UI (1)/RotatingScoreboard/stand");
        public static GameObject RotatingReport = null;

        public static void AntiReports()
        {
            if (AntireportBlock == null && AntiReportCityBlock == null && AntiReportSkyBlock == null && CavesReport == null)
            {
                GorillaScoreBoard[] ScoreBoard = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                foreach (GorillaScoreBoard boardObject in ScoreBoard)
                {
                    AntireportBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    AntireportBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    AntireportBlock.transform.position = boardObject.transform.position;
                    AntireportBlock.transform.rotation = boardObject.transform.rotation;
                    Object.Destroy(AntireportBlock.GetComponent<BoxCollider>());

                    AntiReportCityBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    AntiReportCityBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    AntiReportCityBlock.transform.position = CityReportScoreBoard.transform.position;
                    AntiReportCityBlock.transform.rotation = CityReportScoreBoard.transform.rotation;
                    Object.Destroy(AntiReportCityBlock.GetComponent<BoxCollider>());

                    AntiReportSkyBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    AntiReportSkyBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    AntiReportSkyBlock.transform.position = SkyBoard.transform.position;
                    AntiReportSkyBlock.transform.rotation = SkyBoard.transform.rotation;
                    Object.Destroy(AntiReportSkyBlock.GetComponent<BoxCollider>());

                    CavesReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    CavesReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    CavesReport.transform.position = CavesBoard.transform.position;
                    CavesReport.transform.rotation = CavesBoard.transform.rotation;
                    Object.Destroy(CavesReport.GetComponent<BoxCollider>());
                }
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, AntireportBlock.transform.position);
                    float distance1 = Vector3.Distance(i.transform.position, AntiReportCityBlock.transform.position);
                    float distance2 = Vector3.Distance(i.transform.position, AntiReportSkyBlock.transform.position);
                    float distance3 = Vector3.Distance(i.transform.position, CavesReport.transform.position);
                    if (distance <= 2.125f || distance1 <= 1.12f || distance2 <= 2.235f || distance3 <= 2f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportCity()
        {
            if (AntiReportCityBlock == null)
            {
                AntiReportCityBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                AntiReportCityBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                AntiReportCityBlock.transform.position = CityReportScoreBoard.transform.position;
                AntiReportCityBlock.transform.rotation = CityReportScoreBoard.transform.rotation;
                Object.Destroy(AntiReportCityBlock.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, AntiReportCityBlock.transform.position);
                    if (distance <= 1.12f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportSky()
        {
            if (AntiReportSkyBlock == null)
            {
                AntiReportSkyBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                AntiReportSkyBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                AntiReportSkyBlock.transform.position = SkyBoard.transform.position;
                AntiReportSkyBlock.transform.rotation = SkyBoard.transform.rotation;
                Object.Destroy(AntiReportSkyBlock.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, AntiReportSkyBlock.transform.position);
                    if (distance <= 2.235f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportCanyon()
        {
            if (CanyonReport == null)
            {
                CanyonReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                CanyonReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                CanyonReport.transform.position = CanyonBoard.transform.position;
                CanyonReport.transform.rotation = CanyonBoard.transform.rotation;
                Object.Destroy(CanyonReport.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, CanyonReport.transform.position);
                    if (distance <= 2f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportBeach()
        {
            if (BeachReport == null)
            {
                BeachReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                BeachReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                BeachReport.transform.position = BeachBoard.transform.position;
                BeachReport.transform.rotation = BeachBoard.transform.rotation;
                Object.Destroy(BeachReport.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, BeachReport.transform.position);
                    if (distance <= 1.75f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportCaves()
        {
            if (CavesReport == null)
            {
                CavesReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                CavesReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                CavesReport.transform.position = CavesBoard.transform.position;
                CavesReport.transform.rotation = CavesBoard.transform.rotation;
                Object.Destroy(CavesReport.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, CavesReport.transform.position);
                    if (distance <= 2f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportMountains()
        {
            if (MountainsReport == null)
            {
                MountainsReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MountainsReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                MountainsReport.transform.position = MountainsBoard.transform.position;
                MountainsReport.transform.rotation = MountainsBoard.transform.rotation;
                Object.Destroy(MountainsReport.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, MountainsReport.transform.position);
                    if (distance <= 2.35f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static void AntiReportRotatingMap()
        {
            if (RotatingReport == null)
            {
                RotatingReport = GameObject.CreatePrimitive(PrimitiveType.Cube);
                RotatingReport.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                RotatingReport.transform.position = RotatingBoard.transform.position;
                RotatingReport.transform.rotation = RotatingBoard.transform.rotation;
                Object.Destroy(RotatingReport.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, RotatingReport.transform.position);
                    if (distance <= 1.5f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }

        public static int staticchanger = 1;
        public static void ARSizeChanger()
        {
            staticchanger++;
            if (staticchanger > 3)
            {
                staticchanger = 1;
            }
            if (staticchanger == 1)
            {
                size = new Vector3(1.5f, 1.5f, 1.5f);
                range = 2.0f;
            }
            if (staticchanger == 2)
            {
                size = new Vector3(2.25f, 2.25f, 2.25f);
                range = 4.0f;
            }
            if (staticchanger == 3)
            {
                size = new Vector3(3f, 3f, 3f);
                range = 7.5f;
            }
        }

        public static void DisableAntiReport()
        {
            if (arBlock != null)
            {
                Object.Destroy(arBlock);
                arBlock = null;
            }
        }

        //public static GameObject MetaReporting = GameObject.Find("Miscellaneous Scripts/MetaReporting");
        //public static GameObject MetaOccluder = GameObject.Find("Miscellaneous Scripts/MetaReporting/ReportOccluder");
        //public static GameObject MetaRB = GameObject.Find("Miscellaneous Scripts/MetaReporting/CollisionRB"); // keeping this tab

        public static GameObject MetaCanvas = GameObject.Find("Miscellaneous Scripts/MetaReporting/Canvas");
        public static GameObject reporting = null;

        public static void MetaAntiReport()
        {
            if (reporting == null)
            {
                reporting = GameObject.CreatePrimitive(PrimitiveType.Cube);
                reporting.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                reporting.transform.position = MetaCanvas.transform.position;
                reporting.transform.rotation = MetaCanvas.transform.rotation;
                Object.Destroy(reporting.GetComponent<BoxCollider>());
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(i.transform.position, reporting.transform.position);
                    if (distance <= 5f)
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                    }
                }
            }
        }
    }
}
