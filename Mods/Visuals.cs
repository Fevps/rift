using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using GorillaLocomotion;
using Rift.Menu;
using static BetterDayNightManager;
namespace Rift.Mods
{
    internal class Visuals
    {
        public static bool isRainbowVisuals = false;
        public static void Chams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig players in GorillaParent.instance.vrrigs)
                {
                    if (players != GorillaTagger.Instance.offlineVRRig)
                    {
                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            players.mainSkin.material.color = colortochange;
                            players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (players.mainSkin.material.name.Contains("fected"))
                            {
                                players.mainSkin.material.color = new Color32(255, 25, 1, 35);
                                players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            }
                            else
                            {
                                players.mainSkin.material.color = new Color32(25, 255, 1, 35);
                                players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            }
                        }
                    }
                }
            }
        }

        public static void DisableChams()
        {
            foreach (VRRig player in GorillaParent.instance.vrrigs)
            {
                player.mainSkin.material.color = player.mainSkin.material.color;
                player.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }

        public static void Tracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 100);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            {
                                lineUser.startColor = red; lineUser.endColor = red;
                                red.a = 0.25f;
                            }
                            else
                            {
                                lineUser.startColor = green; lineUser.endColor = green;
                                green.a = 0.25f;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, GorillaTagger.Instance.bodyCollider.transform.position);
                        lineUser.SetPosition(1, player.transform.position);

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void HandTracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 100);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            {
                                lineUser.startColor = red; lineUser.endColor = red;
                                red.a = 0.25f;
                            }
                            else
                            {
                                lineUser.startColor = green; lineUser.endColor = green;
                                green.a = 0.25f;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, GorillaTagger.Instance.leftHandTransform.transform.position);
                        lineUser.SetPosition(1, player.transform.position);

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void Beacons()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            {
                                lineUser.startColor = red; lineUser.endColor = red;
                                red.a = 0.25f;
                            }
                            else
                            {
                                lineUser.startColor = green; lineUser.endColor = green;
                                green.a = 0.25f;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, player.transform.position + new Vector3(0, 20, 0));
                        lineUser.SetPosition(1, player.transform.position + new Vector3(0, -20, 0));

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void HeadChams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject bodySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);

                        bodySphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            bodySphere.GetComponent<Renderer>().material.color = colortochange;
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                bodySphere.GetComponent<Renderer>().material.color = red;
                                red.a = 0.25f;
                            }
                            else
                            {
                                bodySphere.GetComponent<Renderer>().material.color = green;
                                green.a = 0.25f;
                            }
                        }
                        bodySphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                        bodySphere.transform.position = i.transform.position + new Vector3(0, 1, 0);
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(bodySphere, Time.deltaTime);
                    }
                }
            }
        }

        public static void BoxESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(box.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(box, Time.deltaTime);
                        box.transform.localScale = new Vector3(1f, 2f, 1f);
                        box.transform.position = i.transform.position;
                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);
                        box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[7];
                            colorkeys[0].color = Color.red;
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = Color.yellow;
                            colorkeys[1].time = 0.2f;
                            colorkeys[2].color = Color.green;
                            colorkeys[2].time = 0.3f;
                            colorkeys[3].color = Color.cyan;
                            colorkeys[3].time = 0.5f;
                            colorkeys[4].color = Color.blue;
                            colorkeys[4].time = 0.6f;
                            colorkeys[5].color = Color.magenta;
                            colorkeys[5].time = 0.8f;
                            colorkeys[6].color = Color.red;
                            colorkeys[6].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            box.GetComponent<Renderer>().material.color = colortochange;
                            colortochange.a = 0.25f;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                box.GetComponent<Renderer>().material.color = red;
                                red.a = 0.25f;
                            }
                            else
                            {
                                box.GetComponent<Renderer>().material.color = green;
                                green.a = 0.25f;
                            }
                        }
                    }
                }
            }
        }

        GameObject drawnObject = RainbowDraw();
        private static List<GameObject> drawObjects = new List<GameObject>();
        public static GameObject RainbowDraw()
        {
            GameObject drawnObject = null;

            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                GameObject draw = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(draw.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(draw.GetComponent<Collider>());
                UnityEngine.Object.Destroy(draw, 5f);
                draw.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                draw.transform.position = Player.Instance.leftControllerTransform.position;

                drawnObject = draw;
                drawObjects.Add(draw);

                if (isRainbowVisuals)
                {
                    GradientColorKey[] colorkeys = new GradientColorKey[7];
                    colorkeys[0].color = Color.red;
                    colorkeys[0].time = 0f;
                    colorkeys[1].color = Color.yellow;
                    colorkeys[1].time = 0.2f;
                    colorkeys[2].color = Color.green;
                    colorkeys[2].time = 0.3f;
                    colorkeys[3].color = Color.cyan;
                    colorkeys[3].time = 0.5f;
                    colorkeys[4].color = Color.blue;
                    colorkeys[4].time = 0.6f;
                    colorkeys[5].color = Color.magenta;
                    colorkeys[5].time = 0.8f;
                    colorkeys[6].color = Color.red;
                    colorkeys[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorkeys;
                    float t = Mathf.PingPong(Time.time / 2f, 1f);
                    var colortochange = gradient.Evaluate(t);

                    draw.GetComponent<Renderer>().material.color = colortochange;
                }
                else
                {
                    draw.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GameObject draw = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(draw.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(draw.GetComponent<Collider>());
                UnityEngine.Object.Destroy(draw, 5f);
                draw.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                draw.transform.position = Player.Instance.rightControllerTransform.position;

                drawnObject = draw;
                drawObjects.Add(draw);

                if (isRainbowVisuals)
                {
                    GradientColorKey[] colorkeys = new GradientColorKey[7];
                    colorkeys[0].color = Color.red;
                    colorkeys[0].time = 0f;
                    colorkeys[1].color = Color.yellow;
                    colorkeys[1].time = 0.2f;
                    colorkeys[2].color = Color.green;
                    colorkeys[2].time = 0.3f;
                    colorkeys[3].color = Color.cyan;
                    colorkeys[3].time = 0.5f;
                    colorkeys[4].color = Color.blue;
                    colorkeys[4].time = 0.6f;
                    colorkeys[5].color = Color.magenta;
                    colorkeys[5].time = 0.8f;
                    colorkeys[6].color = Color.red;
                    colorkeys[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorkeys;
                    float t = Mathf.PingPong(Time.time / 2f, 1f);
                    var colortochange = gradient.Evaluate(t);

                    draw.GetComponent<Renderer>().material.color = colortochange;
                }
                else
                {
                    draw.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
            return drawnObject;
        }

        public static void ForceRain()
        {
            BetterDayNightManager.instance.weatherCycle[BetterDayNightManager.instance.currentWeatherIndex] = WeatherType.Raining;
            BetterDayNightManager.instance.CurrentWeather();
        }

        public static void ClearWeather()
        {
            BetterDayNightManager.instance.weatherCycle[BetterDayNightManager.instance.currentWeatherIndex] = WeatherType.None;
            BetterDayNightManager.instance.CurrentWeather();
        }

        public static int weatherMonicle = 2;
        public static void WeatherChangers()
        {
            weatherMonicle++;
            if (weatherMonicle > 5)
            {
                weatherMonicle = 2;
            }
            if (weatherMonicle == 2)
            {
                BetterDayNightManager.instance.SetTimeOfDay(1);
                Buttons.buttons[7][8].buttonText = "Time Changer [Aesthetic]";
                Buttons.buttons[7][8].overlapText = "Time Changer [Aesthetic]";
            }
            if (weatherMonicle == 3)
            {
                BetterDayNightManager.instance.SetTimeOfDay(3);
                Buttons.buttons[7][8].buttonText = "Time Changer [Day]";
                Buttons.buttons[7][8].overlapText = "Time Changer [Day]";
            }
            if (weatherMonicle == 4)
            {
                BetterDayNightManager.instance.SetTimeOfDay(0);
                Buttons.buttons[7][8].buttonText = "Time Changer [Night]";
                Buttons.buttons[7][8].overlapText = "Time Changer [Day]";
            }
            if (weatherMonicle == 5)
            {
                BetterDayNightManager.instance.SetTimeOfDay(6);
                Buttons.buttons[7][8].buttonText = "Time Changer [Fall]";
                Buttons.buttons[7][8].overlapText = "Time Changer [Day]";
            }
            Main.RecreateMenu();
        }
    }
}
