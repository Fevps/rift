using Rift.Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.InputSystem;
using HarmonyLib;
using Rift.Patches;
using BepInEx;
using Player = GorillaLocomotion.Player;

namespace Rift.Menu
{
    internal class PlayerMods
    {
        public static void FreezeArms()
        {
            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static GameObject getbeamedbymercs;
        public static void FlickTag()
        {
            if (Mouse.current.rightButton.isPressed)
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(UnityInput.Current.mousePosition);
                if (Physics.Raycast(ray, out raycastHit) && getbeamedbymercs == null)
                {
                    getbeamedbymercs = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(getbeamedbymercs.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(getbeamedbymercs.GetComponent<SphereCollider>());
                    getbeamedbymercs.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                    getbeamedbymercs.transform.position = raycastHit.point;
                    getbeamedbymercs.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                }
                getbeamedbymercs.transform.position = raycastHit.point;
                if (Mouse.current.leftButton.isPressed)
                {
                    GorillaTagger.Instance.leftHandTransform.position = getbeamedbymercs.transform.position;
                    getbeamedbymercs.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                }
                else
                {
                    getbeamedbymercs.GetComponent<Renderer>().material.color = new Color32(20, 20, 20, 255);
                }
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 currentPosition = GorillaTagger.Instance.leftHandTransform.position;
                Vector3 forwardVector = GorillaTagger.Instance.leftHandTransform.forward;
                GorillaTagger.Instance.leftHandTransform.position = currentPosition + forwardVector * 20f;
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 currentPosition = GorillaTagger.Instance.rightHandTransform.position;
                Vector3 forwardVector = GorillaTagger.Instance.rightHandTransform.forward;
                GorillaTagger.Instance.rightHandTransform.position = currentPosition + forwardVector * 20f;
            }
        }

        public static void FlipArms()
        {
            Vector3 LeftHand = GorillaTagger.Instance.leftHandTransform.position;
            Vector3 RightHand = GorillaTagger.Instance.rightHandTransform.position;
            GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position = LeftHand;
            GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position = RightHand;
        }

        public static void BigMonkey()
        {
            Variables.scale1 = 5f;
            Player.Instance.scale = Variables.scale1;
        }

        public static void SmallMonkey()
        {
            Variables.scale1 = 0.2f;
            Player.Instance.scale = Variables.scale1;
        }

        public static void FixScaleMonkey()
        {
            Variables.scale1 = 1f;
            Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
