using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using GorillaNetworking;
using Photon.Pun;
using System.Reflection;
using GorillaLocomotion;
using Steamworks;
using UnityEngine.UIElements;
using PlayFab.CloudScriptModels;
using Rift.Menu;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.GlobalIllumination;
using BepInEx;
using UnityEngine.Animations.Rigging;
using UnityEngine.XR.Interaction.Toolkit;
using Rift.Patches;
using PlayFab.ProfilesModels;
using System.Diagnostics;
using Object = UnityEngine.Object;
using GorillaExtensions;
using System.Linq;
using UnityEngine.PlayerLoop;
using Unity.Mathematics;
using OVRTouchSample;
using Rift.Mods;
using static NetworkSystem;
using Rift.Classes;
using ExitGames.Client.Photon;
using System.Timers;
using Rift.Notifications;
using GorillaTag.Cosmetics;
using Photon.Voice.PUN.UtilityScripts;
using GorillaTag;
using HarmonyLib;
using static BetterDayNightManager;

namespace Rift.Mods
{
    internal class Functions
    {
        public static void DisableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
        }
        public static void EnableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
        }

        public static void JoinDiscordServer()
        {
            Process.Start("https://discord.gg/4FySMhJBZ7");
        }

        public static void JoinRandomRoom()
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
        }

        public static void LobbyHop()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                PhotonNetwork.Disconnect();
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
            }
            else
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
        }

        public static void PlayerFly()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Variables.flySpeed;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void NoClipFly()
        {
            foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    mesh.enabled = false;
                    Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Variables.flySpeed;
                    Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else { mesh.enabled = true; }
            }
        }

        public static void BouncyFly()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity += Player.Instance.headCollider.transform.forward * Time.deltaTime * Variables.flySpeed * 1.5f;
                GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = new Vector3(9, 9, 9);
            }
        }

        public static void FixVelocity()
        {
            Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        public static void UpAndDown()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed || ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity += Player.Instance.bodyCollider.transform.up * Time.deltaTime * -25f;
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed || ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity += Player.Instance.bodyCollider.transform.up * Time.deltaTime * 25f;
            }
        }

        public static void PlayerSpeedBoost()
        {
            Vector3 Velocity = Player.Instance.GetComponent<Rigidbody>().velocity;
            Player.Instance.maxJumpSpeed = Variables.playerSpeed;
            Player.Instance.jumpMultiplier = Variables.playerMult;
            Player.Instance.GetComponent<Rigidbody>().velocity = Velocity;
        }

        public static void UseLongArms()
        {
            Player.Instance.transform.localScale = new Vector3(Variables.armSize, Variables.armSize, Variables.armSize);
        }

        public static void LaunchRocket()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/RocketShip_IdleDummy").SetActive(false);
            ScheduledTimelinePlayer.FindObjectOfType<ScheduledTimelinePlayer>().timeline.Play();
            NotifiLib.SendNotification("Lauching Rocket.");
        }

        public static void AcceptToS()
        {
            //GameObject.Find("Miscellaneous Scripts/LegalAgreementCheck").SetActive(false);
            GameObject.Find("Miscellaneous Scripts/LegalAgreementCheck/Legal Agreements").SetActive(false); // the screen itself
            GameObject.Find("Miscellaneous Scripts/LegalAgreementCheck/UIParent").SetActive(false); //removes black screen via tos glitch (somehow fixes the glitch)
        }

        public static void disableChams()
        {
            Variables.ifDisabled = true;
            Variables.casual = false; Variables.fected = false;
        }

        public static bool AllowedToGhost = true;
        public static void Ghost()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                if (AllowedToGhost)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                    AllowedToGhost = false;
                }
            }
            else
            {
                if (!AllowedToGhost)
                {
                    AllowedToGhost = true;
                }
            }
            if (!GorillaTagger.Instance.offlineVRRig.enabled)
            {
                GameObject righth = GameObject.CreatePrimitive(0);
                GameObject lefth = GameObject.CreatePrimitive(0);

                Object.Destroy(righth.GetComponent<Rigidbody>());
                Object.Destroy(righth.GetComponent<SphereCollider>());
                Object.Destroy(lefth.GetComponent<Rigidbody>());
                Object.Destroy(lefth.GetComponent<SphereCollider>());

                righth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                lefth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                righth.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                lefth.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                righth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                lefth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                Object.Destroy(righth, Time.deltaTime);
                Object.Destroy(lefth, Time.deltaTime);
            }
        }

        public static bool AllowedToInvis = true;
        public static void Invisible()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                if (AllowedToInvis)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                    GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    AllowedToInvis = false;
                }
            }
            else
            {
                if (!AllowedToInvis)
                {
                    AllowedToInvis = true;
                }
            }
            if (!GorillaTagger.Instance.offlineVRRig.enabled)
            {
                GameObject righth = GameObject.CreatePrimitive(0);
                GameObject lefth = GameObject.CreatePrimitive(0);

                Object.Destroy(righth.GetComponent<Rigidbody>());
                Object.Destroy(righth.GetComponent<SphereCollider>());
                Object.Destroy(lefth.GetComponent<Rigidbody>());
                Object.Destroy(lefth.GetComponent<SphereCollider>());

                righth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                lefth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                righth.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                lefth.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                righth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                lefth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                Object.Destroy(righth, Time.deltaTime);
                Object.Destroy(lefth, Time.deltaTime);
            }
        }

        public static void RigGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit OnHitInformation;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out OnHitInformation);
                GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                pointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                pointer.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                pointer.transform.position = OnHitInformation.point;
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    pointer.GetComponent<Renderer>().material.color = new Color32(175, 25, 0, 255);
                    GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.45f, 0f);
                    GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.45f, 0f);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    pointer.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                }
            }
        }

        public static void SpazMonkey()
        {
            if (ControllerInputPoller.instance.rightGrab || ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.leftControllerPrimaryButton || ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
            }
        }

        public static void ResetLongArms()
        {
            Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public static void ResetSpaz()
        {
            GorillaTagger.Instance.headCollider.contactOffset = 0;
        }

        public static GameObject gameObject = null;
        public static GameObject checkPoint = null;
        public static void C4()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                if (gameObject == null)
                {
                    gameObject = GameObject.CreatePrimitive(0);
                    gameObject.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                    gameObject.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                    Object.Destroy(gameObject.GetComponent<SphereCollider>());
                    Object.Destroy(gameObject.GetComponent<Rigidbody>());
                }
                gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                if (gameObject != null)
                {
                    Vector3 distance = (GorillaTagger.Instance.bodyCollider.transform.position - gameObject.transform.position);
                    distance.Normalize();
                    Player.Instance.GetComponent<Rigidbody>().velocity += 10f * distance;
                    Object.Destroy(gameObject);
                    gameObject = null;
                }
            }
        }

        public static void Checkpoint()
        {
            foreach (MeshCollider collide in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
                {
                    if (checkPoint == null)
                    {
                        checkPoint = GameObject.CreatePrimitive(0);
                        checkPoint.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                        checkPoint.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                        Object.Destroy(checkPoint.GetComponent<SphereCollider>());
                        Object.Destroy(checkPoint.GetComponent<Rigidbody>());
                    }
                    checkPoint.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                }
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    if (checkPoint != null)
                    {
                        collide.enabled = false;
                        GorillaTagger.Instance.GetComponent<Rigidbody>().transform.position = checkPoint.transform.position;
                        GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        Object.Destroy(checkPoint);
                        checkPoint = null;
                        if (Time.time > 0.1f)
                        {
                            collide.enabled = true;
                        }
                    }
                }
            }
        }

        public static void DisableC4()
        {
            if (gameObject != null)
            {
                Object.Destroy(gameObject);
                gameObject = null;
            }
        }

        public static void DisableCheckPoint()
        {
            if (checkPoint != null)
            {
                Object.Destroy(checkPoint);
                checkPoint = null;
            }
        }

        public static void ForceTagFreeze()
        {
            Player.Instance.maxJumpSpeed = 1f;
        }

        public static void FixTagFreeze()
        {
            Player.Instance.maxJumpSpeed = 6.5f;
        }

        public static void DisableMeshColliders()
        {
            foreach (MeshCollider AllMeshColliders in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f || Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed)
                {
                    AllMeshColliders.enabled = false;
                }
                else
                {
                    AllMeshColliders.enabled = true;
                }
            }
        }

        public static void GrabRig()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                GorillaTagger.Instance.GetComponent<Rigidbody>().transform.position = GorillaTagger.Instance.rightHandTransform.position;
                GorillaTagger.Instance.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                GorillaTagger.Instance.GetComponent<Rigidbody>().transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void ChangeRigSize()
        {
            if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f || Mouse.current.leftButton.isPressed)
            {
                Variables.playerScale += 0.05f;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Variables.playerScale -= 0.05f;
            }

            if (ControllerInputPoller.instance.leftControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                Variables.playerScale = 1f;
            }

            if (Variables.playerScale <= 0)
            {
                Variables.playerScale = 0.05f;
            }

            if (ControllerInputPoller.instance.leftControllerSecondaryButton && Settings.rightHanded)
            {
                Variables.playerScale = 1f;
            }

            if (ControllerInputPoller.instance.rightControllerSecondaryButton && !Settings.rightHanded)
            {
                Variables.playerScale = 1f;
            }

            Player.Instance.scale = Variables.playerScale;
        }

        public static void Update()//thanks shibagt 
        {
            if (ghostRig == null)
            {
                ghostRig = UnityEngine.Object.Instantiate<VRRig>(GorillaTagger.Instance.offlineVRRig, Player.Instance.transform.position, Player.Instance.transform.rotation);
                UnityEngine.Object.Destroy(ghostRig.GetComponent<Rigidbody>());
                Object.Destroy(ghostRig, Time.deltaTime);
                ghostRig.enabled = false;
                ghostRig.transform.position = Vector3.zero;
            }
            if (!GorillaTagger.Instance.offlineVRRig.enabled)
            {
                ghostRig.enabled = true;
                GameObject sphere = GameObject.CreatePrimitive(0);
                sphere.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                Object.Destroy(sphere, Time.deltaTime);
                Object.Destroy(sphere.GetComponent<SphereCollider>());
                Object.Destroy(sphere.GetComponent<Rigidbody>());
                ghostRig.leftHandTransform.position = Player.Instance.leftControllerTransform.position;
                ghostRig.rightHandTransform.position = Player.Instance.rightControllerTransform.position;
                ghostRig.leftHandTransform.rotation = Player.Instance.leftControllerTransform.rotation;
                ghostRig.rightHandTransform.rotation = Player.Instance.rightControllerTransform.rotation;
                ghostRig.transform.position = Player.Instance.transform.position;
                ghostRig.transform.rotation = Player.Instance.transform.rotation;
                ghostRig.GetComponent<Renderer>().material.shader = Variables.GUIShader;
                ghostRig.GetComponent<Renderer>().material = sphere.GetComponent<Renderer>().material;
                ghostRig.playerColor.a = 0.25f;
            }
            else
            {
                doneDid = false;
                ghostRig.enabled = false;
                ghostRig.transform.position = Vector3.zero;
            }
            Material material = ghostRig.mainSkin.material;
            material.SetFloat("_Mode", 2f);
            Color SeerColor = Variables.ButtonDisabled;
            SeerColor.a = 0.25f;
            material.color = SeerColor;
        }

        public static void DisableUpdate()
        {
            ghostRig = null;
        }

        public static bool doneDid = false;
        public static VRRig ghostRig = null;

        public static void SpinHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 10f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 10f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 10f;
        }

        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
        }

        public static void FPSBoost()
        {
            QualitySettings.globalTextureMipmapLimit = Variables.MaxValue;
        }

        public static void DisableFPSBoost()
        {
            QualitySettings.globalTextureMipmapLimit = Variables.FPSValue;
        }

        public static void DisableTagFreeze()
        {
            Player.Instance.disableMovement = false;
        }
        public static void EnableTagFreeze()
        {
            Player.Instance.disableMovement = true;
        }

        public static void CurrentDisconnect()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void ReverseGravity()
        {
            Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (12f / Time.deltaTime)), ForceMode.Acceleration);
        }
        public static void ZeroGravity()
        {
            Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.89f / Time.deltaTime)), ForceMode.Acceleration);
        }
        public static void LowGravity()
        {
            Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (7f / Time.deltaTime)), ForceMode.Acceleration);
        }
        public static void HighGravity()
        {
            Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.down * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static float CurrentSpeed = 0;
        public static void IronMonkey()
        {
            if (ControllerInputPoller.instance.leftGrab && ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                if (CurrentSpeed < 7.5f) 
                { 
                    CurrentSpeed += 0.1f; 
                }
                Player.Instance.transform.position += (Player.Instance.leftControllerTransform.transform.up * Time.deltaTime) * 5f;
                Player.Instance.transform.position += (Player.Instance.leftControllerTransform.transform.forward * Time.deltaTime) * CurrentSpeed;

                Player.Instance.transform.position += (Player.Instance.rightControllerTransform.transform.up * Time.deltaTime) * 5f;
                Player.Instance.transform.position += (Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * CurrentSpeed;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                if (CurrentSpeed != 0) 
                { 
                    CurrentSpeed -= 0.1f; 
                }
            }
        }

        public static void AntiModerator()
        {
            foreach (VRRig Players in GorillaParent.instance.vrrigs)
            {
                if (!Players.isOfflineVRRig && Players.concatStringOfCosmeticsAllowed.Contains("LBAAK"))
                {
                    PhotonNetwork.Disconnect();
                }
            }
        }

        public static void DisableFingerMovement()
        {
            /*Variables.LeftPrimary = false;
            Variables.LeftSecondary = false;

            Variables.RightPrimary = false;
            Variables.RightSecondary = false;

            Variables.LeftTriggerIndex = 0f;
            Variables.LeftGripIndex = 0f;

            Variables.RightTriggerIndex = 0f;
            Variables.RightGripIndex = 0f;*/

            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;

            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;


            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;

            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }

        public static void RestartGame()
        {
            Process.Start("steam://rungameid/1533390");
            Application.Quit();
        }

        public static void QuitGame()
        {
            Application.Quit();
        }
        
        public static void SlideController()
        {
            Player.Instance.slideControl = Variables.slideControl;
        }

        public static void UnlockCompetitive()
        {
            GorillaComputer.instance.CompQueueUnlockButtonPress();
        }

        public static void FakeOculusMenu()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed)
            {
                Vector3 RightHand = Player.Instance.bodyCollider.transform.position;
                Vector3 LeftHand = Player.Instance.bodyCollider.transform.position;
                Player.Instance.rightControllerTransform.transform.position = RightHand;
                Player.Instance.leftControllerTransform.transform.position = LeftHand;
            }
        }

        public static void FakeOculusArms()
        {
            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                Vector3 RightHand = Player.Instance.bodyCollider.transform.position;
                Vector3 LeftHand = Player.Instance.bodyCollider.transform.position;
                Vector3 Positioning = new Vector3(0f, -0.5f, 0f);
                Player.Instance.rightControllerTransform.transform.position = RightHand;
                Player.Instance.leftControllerTransform.transform.position = LeftHand;
                Player.Instance.rightControllerTransform.transform.position = Positioning;
                Player.Instance.leftControllerTransform.transform.position = Positioning;
            }
        }

        public static void FakeLeftController()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Vector3 LeftHand = Player.Instance.bodyCollider.transform.position;
                Player.Instance.leftControllerTransform.transform.position = LeftHand + new Vector3(0.1f, 0f, 0f);
            }
        }

        public static void FakeRightController()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Vector3 RightHand = Player.Instance.bodyCollider.transform.position;
                Player.Instance.rightControllerTransform.transform.position = RightHand + new Vector3(0.1f, 0f, 0f);
            }
        }

        public static void HeadInHands()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Vector3 RightHand = GorillaTagger.Instance.rightHandTransform.transform.position;
                Player.Instance.headCollider.transform.position = RightHand;
            }
        }

        public static void HandsInHead()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Vector3 HeadCollider = GorillaTagger.Instance.headCollider.transform.position;
                Player.Instance.leftControllerTransform.position = HeadCollider;
                Player.Instance.rightControllerTransform.position = HeadCollider;
            }
        }

        public static void FasterTurnSpeed()
        {
            foreach (GorillaSnapTurn SpinAmount in (GorillaSnapTurn[])Object.FindObjectsOfType(typeof(GorillaSnapTurn)))
            {
                SpinAmount.ChangeTurnMode("SMOOTH", 275);
                SpinAmount.turnAmount = 275f;
            }
        }

        public static void FixTurnSpeed()
        {
            foreach (GorillaSnapTurn SpinAmount in Object.FindObjectsOfType<GorillaSnapTurn>())
            {
                SpinAmount.ChangeTurnMode("SMOOTH", 5);
                SpinAmount.turnAmount = 5f;
            }
        }

        public static void AutoJoinPrivate()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                PhotonNetwork.Disconnect();
                if (!PhotonNetwork.InRoom || !PhotonNetwork.InLobby)
                {
                    PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Variables.RandomGenerator(5));
                }
            }
            if (!PhotonNetwork.InRoom || !PhotonNetwork.InLobby)
            {
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Variables.RandomGenerator(5));
            }
        }

        public static void AutoJoinRandomGhostCode()
        {
            PhotonNetwork.Disconnect();
            /*if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                PhotonNetwork.Disconnect();
                if (!PhotonNetwork.InRoom || !PhotonNetwork.InLobby)
                {
                    PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Variables.GhostCodes[Variables.randomCodeNumber]);
                }
            }*/
            if (!PhotonNetwork.InRoom || !PhotonNetwork.InLobby)
            {
                Variables.joiningCode = true;
            }
            if (Variables.joiningCode)
            {
                Variables.joiningCode = false;
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Variables.GhostCodes[Variables.randomCodeNumber]);
            }
        }

        public static void disableCode()
        {
            Variables.joiningCode = false;
        }

        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void GrabBall()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/WaterPolo/BeachBall").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void BugGun()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                RaycastHit onHitInfo;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out onHitInfo);
                GameObject CreatePointer = GameObject.CreatePrimitive(0);
                CreatePointer.transform.position = onHitInfo.point;
                CreatePointer.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                CreatePointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                Object.Destroy(CreatePointer, Time.deltaTime);
                Object.Destroy(CreatePointer.GetComponent<SphereCollider>());
                Object.Destroy(CreatePointer.GetComponent<Rigidbody>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonEnabled;
                    Vector3 ExtraGunHelper = new Vector3(0f, 0.45f, 0f);
                    GameObject BugGameObject = GameObject.Find("Floating Bug Holdable");
                    BugGameObject.transform.position = CreatePointer.transform.position + ExtraGunHelper;
                }
                else
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
        }

        public static void BatGun()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                RaycastHit onHitInfo;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out onHitInfo);
                GameObject CreatePointer = GameObject.CreatePrimitive(0);
                CreatePointer.transform.position = onHitInfo.point;
                CreatePointer.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                CreatePointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                Object.Destroy(CreatePointer, Time.deltaTime);
                Object.Destroy(CreatePointer.GetComponent<SphereCollider>());
                Object.Destroy(CreatePointer.GetComponent<Rigidbody>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonEnabled;
                    Vector3 ExtraGunHelper = new Vector3(0f, 0.45f, 0f);
                    GameObject BugGameObject = GameObject.Find("Cave Bat Holdable");
                    BugGameObject.transform.position = CreatePointer.transform.position + ExtraGunHelper;
                }
                else
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
        }

        public static void BallGun()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                RaycastHit onHitInfo;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out onHitInfo);
                GameObject CreatePointer = GameObject.CreatePrimitive(0);
                CreatePointer.transform.position = onHitInfo.point;
                CreatePointer.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                CreatePointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                Object.Destroy(CreatePointer, Time.deltaTime);
                Object.Destroy(CreatePointer.GetComponent<SphereCollider>());
                Object.Destroy(CreatePointer.GetComponent<Rigidbody>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonEnabled;
                    Vector3 ExtraGunHelper = new Vector3(0f, 0.45f, 0f);
                    GameObject BugGameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/WaterPolo/BeachBall");
                    BugGameObject.transform.position = CreatePointer.transform.position + ExtraGunHelper;
                }
                else
                {
                    CreatePointer.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
        }

        private static GameObject bug = GameObject.Find("Floating Bug Holdable");
        private static GameObject bat = GameObject.Find("Cave Bat Holdable");
        private static GameObject ball = GameObject.Find("Environment Objects/PersistentObjects_Prefab/WaterPolo/BeachBall");

        public static void SpazBug()
        {
            bug.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
            bug.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
        }

        public static void SpazBat()
        {
            bat.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
            bat.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
        }

        public static void ResetEntities()
        {
            bug.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
            bat.transform.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0), (float)UnityEngine.Random.Range(0, 0));
        }

        public static void RideBug()
        {
            GorillaTagger.Instance.offlineVRRig.transform.position = bug.transform.position + new Vector3(0, 1, 0);
            GorillaTagger.Instance.myVRRig.transform.position = bug.transform.position + new Vector3(0, 1, 0);
        }

        public static void RideBat()
        {
            GorillaTagger.Instance.offlineVRRig.transform.position = bat.transform.position + new Vector3(0, 1, 0);
            GorillaTagger.Instance.myVRRig.transform.position = bat.transform.position + new Vector3(0, 1, 0);
        }

        public static void EntitiesESP()
        {
            GameObject yo = GameObject.CreatePrimitive(0);
            Object.Destroy(yo, Time.deltaTime);
            Object.Destroy(yo.GetComponent<SphereCollider>());
            Object.Destroy(yo.GetComponent<Rigidbody>());
            yo.transform.localScale = bug.transform.localScale + new Vector3(-0.2f, -0.2f, -0.2f);
            yo.transform.position = bug.transform.position;

            GameObject yo1 = GameObject.CreatePrimitive(0);
            Object.Destroy(yo1, Time.deltaTime);
            Object.Destroy(yo1.GetComponent<SphereCollider>());
            Object.Destroy(yo1.GetComponent<Rigidbody>());
            yo1.transform.localScale = bat.transform.localScale + new Vector3(-0.2f, -0.2f, -0.2f);
            yo1.transform.position = bat.transform.position;

            GameObject yo2 = GameObject.CreatePrimitive(0);
            Object.Destroy(yo2, Time.deltaTime);
            Object.Destroy(yo2.GetComponent<SphereCollider>());
            Object.Destroy(yo2.GetComponent<Rigidbody>());
            yo2.transform.localScale = ball.transform.localScale + new Vector3(-0.1f, -0.1f, -0.1f);
            yo2.transform.position = ball.transform.position * Time.deltaTime;
        }

        public static void RequestBugOwnership()
        {
            GameObject.Find("Throwable Bug Holdable").GetComponent<ThrowableBug>().ownerRig = GorillaTagger.Instance.offlineVRRig;
            GameObject.Find("Throwable Bug Holdable").GetComponent<ThrowableBug>().allowWorldSharableInstance = true;
            GameObject.Find("Throwable Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
        }

        public static void RequestBatOwnership()
        {
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().ownerRig = GorillaTagger.Instance.offlineVRRig;
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().allowWorldSharableInstance = true;
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
        }

        public static void CheckIfEntityOwnership()
        {
            bool BugOwned = false; bool BatOwned = false;
            if (bug.GetComponent<ThrowableBug>().ownerRig == GorillaTagger.Instance.offlineVRRig)
            {
                BugOwned = true;
            }
            else
            {
                BugOwned = false;
            }
            if (bat.GetComponent<ThrowableBug>().ownerRig == GorillaTagger.Instance.offlineVRRig)
            {
                BatOwned = true;
            }
            else
            {
                BatOwned = false;
            }
            NotifiLib.SendNotification("Bug Ownership = " + BugOwned);
            NotifiLib.SendNotification("Bat Ownership = " + BatOwned);
        }

        public static void DestroyAnimals()
        {
            GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(99999, float.MaxValue, 99999);
            GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(99999, float.MaxValue, 99999);
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/WaterPolo/BeachBall").transform.position = new Vector3(99999, float.MaxValue, 99999);
        }

        public static void FastBug()
        {
            foreach (ThrowableBug bugg in ThrowableBug.FindObjectsOfType<ThrowableBug>())
            {
                if (bugg == bug)
                {
                    bugg.bobingSpeed = 100f;
                    bugg.maxNaturalSpeed = 100f;
                    bugg.startingSpeed = 100f;
                }
            }
        }

        public static void FastBat()
        {
            foreach (ThrowableBug batt in ThrowableBug.FindObjectsOfType<ThrowableBug>())
            {
                if (batt == bat)
                {
                    batt.bobingSpeed = 100f;
                    batt.maxNaturalSpeed = 100f;
                    batt.startingSpeed = 100f;
                }
            }
        }

        public static void ResetSpeeds()
        {
            foreach (ThrowableBug bugg in ThrowableBug.FindObjectsOfType<ThrowableBug>())
            {
                if (bugg == bug)
                {
                    bugg.bobingSpeed = 5f;
                    bugg.maxNaturalSpeed = 5f;
                    bugg.startingSpeed = 5f;
                }
            }
            foreach (ThrowableBug batt in ThrowableBug.FindObjectsOfType<ThrowableBug>())
            {
                if (batt == bat)
                {
                    batt.bobingSpeed = 5f;
                    batt.maxNaturalSpeed = 5f;
                    batt.startingSpeed = 5f;
                }
            }
        }

        public static void TeleportToBug()
        {
            GorillaTagger.Instance.transform.position = bug.transform.position;
            GorillaTagger.Instance.GetComponent<Rigidbody>().transform.position = bug.transform.position;
        }

        public static void TeleportToBat()
        {
            GorillaTagger.Instance.transform.position = bat.transform.position;
            GorillaTagger.Instance.GetComponent<Rigidbody>().transform.position = bat.transform.position;
        }

        public static void BigBug()
        {
            bug.transform.localScale = new Vector3(5f, 5f, 5f);
        }
        public static void BigBat()
        {
            bat.transform.localScale = new Vector3(5f, 5f, 5f);
        }

        public static void ResetBug()
        {
            bug.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        public static void ResetBat()
        {
            bat.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public static void OrbitBug()
        {
            bug.transform.RotateAround(GorillaTagger.Instance.headCollider.center, Vector3.right, 15f * Time.deltaTime);
            bug.transform.Rotate(GorillaTagger.Instance.headCollider.bounds.center, Time.deltaTime * 15f);
        }

        public static void OrbitBat()
        {
            bat.transform.RotateAround(GorillaTagger.Instance.headCollider.center, Vector3.right, 15f * Time.deltaTime);
            bat.transform.Rotate(GorillaTagger.Instance.headCollider.bounds.center, Time.deltaTime * 15f);
        }

        public static string info = "[<color=yellow>Rift</color>]";
        public static void MakeRedWin()
        {
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(1);
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(1);
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(1);
            NotifiLib.SendNotification(info + " Red Won.");
        }

        public static void MakeBlueWin()
        {
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(0);
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(0);
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(0);
            NotifiLib.SendNotification(info + " Blue Won.");
        }

        public static void AddScoreToRed()
        {
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(1);
            NotifiLib.SendNotification(info + " Added Score To Red.");
        }

        public static void AddScoreToBlue()
        {
            GorillaTag.Sports.SportScoreboard.Instance.TeamScored(0);
            NotifiLib.SendNotification(info + " Added Score To Blue.");
        }

        public static void ResetScores()
        {
            GorillaTag.Sports.SportScoreboard.Instance.ResetScores();
            NotifiLib.SendNotification(info + " Resetting Score.");
        }

        public static void DelayedRig()
        {
            if (Time.time > Variables.timeDelay)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Variables.timeDelay = Time.time + 1f;
                Variables.ifTime = true;
            }
            else
            {
                if (Variables.ifTime)
                {
                    Variables.ifTime = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }
            }
        }

        public static void FixRig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void FixHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0.1f;
        }
        public static void LoudHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = int.MaxValue;
        }
        public static void SilentHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0;
        }

        public static void NoTapCoolDown()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }
        public static void FixNoTapCooldown()
        {
            GorillaTagger.Instance.tapCoolDown = 0.33f;
        }

        public static void Keyboarding()
        {
            float currentSpeed = 10;
            Transform bodyTransform = Camera.main.transform;
            GorillaTagger.Instance.rigidbody.useGravity = false;
            GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= 2.5f;
            }
            if (UnityInput.Current.GetKey(KeyCode.W))
            {
                bodyTransform.position += bodyTransform.forward * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetKey(KeyCode.A))
            {
                bodyTransform.position += -bodyTransform.right * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetKey(KeyCode.S))
            {
                bodyTransform.position += -bodyTransform.forward * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetKey(KeyCode.D))
            {
                bodyTransform.position += bodyTransform.right * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space))
            {
                bodyTransform.position += bodyTransform.up * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl))
            {
                bodyTransform.position += -bodyTransform.up * currentSpeed * Time.deltaTime;
            }
            if (UnityInput.Current.GetMouseButton(1))
            {
                Vector3 pos = UnityInput.Current.mousePosition - oldMousePos;
                float x = bodyTransform.localEulerAngles.x - pos.y * 0.3f;
                float y = bodyTransform.localEulerAngles.y + pos.x * 0.3f;
                bodyTransform.localEulerAngles = new Vector3(x, y, 0f);
            }
            oldMousePos = UnityInput.Current.mousePosition;
        }
        private static Vector3 oldMousePos;

        public static void RemoveTrees()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(false);
        }

        public static void EnableTrees()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(true);
        }

        public static void Helicopter()
        {
            if (ControllerInputPoller.instance.leftControllerPrimaryButton || ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.leftButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position 
                    += new Vector3(0f, 0.075f, 0f);
                GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles 
                    + new Vector3(0f, 10f, 0f));
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void TpGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit onHit;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out onHit);
                GameObject game = GameObject.CreatePrimitive(0);
                game.transform.position = onHit.point;
                game.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                game.GetComponent<Renderer>().material.color = Settings.OutlineColor;
                Object.Destroy(game, Time.deltaTime);
                Object.Destroy(game.GetComponent<Rigidbody>());
                Object.Destroy(game.GetComponent<SphereCollider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    GorillaTagger.Instance.transform.position = game.transform.position;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = game.transform.position;
                }
            }
        }

        public static void CarMonke()
        {
            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                if (Variables.speed < 15f)
                {
                    Variables.speed += 0.1f;
                }
                else
                {
                    if (Variables.speed != 15)
                    {
                        Variables.speed = 15;
                    }
                }
                Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * Variables.speed;
                Player.Instance.transform.position += Player.Instance.headCollider.transform.up * Time.deltaTime * -0.2f;
            }
            else
            {
                if (Variables.speed > 0)
                {
                    Variables.speed -= 0.5f;
                    Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * Variables.speed;
                }
                else if (Variables.speed < 0 || Variables.speed == 0)
                {
                    Variables.speed = 0;
                }
            }
        }
    }
}
