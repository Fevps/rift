using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GorillaLocomotion;
using Object = UnityEngine.Object;
using Color = UnityEngine.Color;
using Photon.Pun;
using Rift.Menu;
using Rift.Notifications;
using UnityEngine.InputSystem;
namespace Rift.Mods
{
    internal class OtherPlayer
    {
        public static GameObject headPos = null;
        public static float range = 0.5f;
        public static Vector3 size = new Vector3(0.25f, 0.25f, 0.25f);
        public static Color GetColor = Color.clear;
        public static bool leftGrabbed = false;
        public static bool rightGrabbed = false;
        public static void PlayerGrabRig()
        {
            if (headPos == null)
            {
                headPos = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                headPos.transform.localScale = size;
                headPos.GetComponent<Renderer>().material.color = GetColor;
                Object.Destroy(headPos.GetComponent<SphereCollider>());
                Object.Destroy(headPos.GetComponent<Rigidbody>());
            }
            headPos.transform.position = GorillaTagger.Instance.headCollider.transform.position;
            if (headPos != null)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        float distance = Vector3.Distance(i.leftHand.rigTarget.transform.position, headPos.transform.position);
                        if (distance <= range)
                        {
                            leftGrabbed = true;
                        }
                        float distance1 = Vector3.Distance(i.rightHand.rigTarget.transform.position, headPos.transform.position);
                        if (distance <= range)
                        {
                            rightGrabbed = true;
                        }
                    }
                }
            }
            if (leftGrabbed)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.bodyCollider.transform.position = i.leftHand.rigTarget.transform.position + new Vector3(0f, 0.5f, 0f);
                        GorillaTagger.Instance.bodyCollider.transform.rotation = Quaternion.Euler(i.leftHand.rigTarget.transform.rotation.eulerAngles);
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = i.leftHandTransform.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = i.leftHand.rigTarget.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = i.leftHand.rigTarget.transform.rotation;
                    }
                }
            }
            if (rightGrabbed)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.bodyCollider.transform.position = i.rightHand.rigTarget.transform.position + new Vector3(0f, 0.5f, 0f);
                        GorillaTagger.Instance.bodyCollider.transform.rotation = Quaternion.Euler(i.rightHand.rigTarget.transform.rotation.eulerAngles);
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = i.rightHandTransform.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = i.rightHand.rigTarget.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = i.rightHand.rigTarget.transform.rotation;
                    }
                }
            }
            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                leftGrabbed = false;
                rightGrabbed = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
    }
}
