using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using GorillaLocomotion;
using Rift.Classes;

namespace Rift.Menu
{
    internal class Movement
    {
        public static void FlickJump()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -1.85f, 0f);
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -1.85f, 0f);
            }
        }

        public static void PlayspaceMovement()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.bodyCollider.transform.forward * Time.deltaTime * -0.25f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.bodyCollider.transform.forward * Time.deltaTime * 0.25f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void SlingshotYourself()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity += Player.Instance.headCollider.transform.forward * Time.deltaTime * Variables.flySpeed * 4.5f;
            }
        }

        public static bool left = false;
        public static bool right = false;
        public static void AutoRun()
        {
            if (!left && ControllerInputPoller.instance.rightGrab || !left && Mouse.current.rightButton.isPressed)
            {
                Vector3 runPosition = CalculatePreferredPosition();
                GorillaTagger.Instance.rightHandTransform.position = runPosition;
                right = true;
            }
            else { right = false; }
            if (!right && ControllerInputPoller.instance.leftGrab || !right && Mouse.current.leftButton.isPressed)
            {
                Vector3 runPosition = CalculatePreferredPosition();
                GorillaTagger.Instance.leftHandTransform.position = runPosition;
                left = true;
            }
            else { left = false; }
        }

        private static Vector3 CalculatePreferredPosition()
        {
            Transform headPosition = GorillaTagger.Instance.headCollider.transform;
            float xOffset = MathF.Cos(Time.frameCount);
            float yOffset = -0.5f - MathF.Sin(Time.frameCount);

            Vector3 newPosition = headPosition.position +
                                  headPosition.forward * xOffset +
                                  new Vector3(0, yOffset, 0);
            return newPosition;
        }
        public static bool ena = false;
        public static void Beyblade()
        {
            ena = true;
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.headCollider.transform.position;
            GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
        }

        public static void disableBlade()
        {
            ena = false;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void AnnoyRandomPlayer()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                foreach (VRRig vR in GorillaParent.instance.vrrigs)
                {
                    if (vR != GorillaTagger.Instance.offlineVRRig)
                    {
                        ena = true;
                        VRRig ii = RigManager.GetRandomVRRig(vR);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = ii.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = ii.transform.position;
                        GorillaTagger.Instance.leftHandTransform.transform.position = ii.transform.position;
                        GorillaTagger.Instance.rightHandTransform.transform.position = ii.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
                    }
                }
            }
            else
            {
                ena = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
    }
}
