using BepInEx;
using HarmonyLib;
using Photon.Pun;
using Photon.Voice;
using Rift.Classes;
using Rift.Mods;
using Rift.Notifications;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Rift.Menu.Buttons;
using static Rift.Settings;

namespace Rift.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        public static Material menumat = null;
        public static void Prefix()
        {
            string contains = Variables.CoCScreen.GetComponent<Text>().text;
            Variables.MoTD.GetComponent<Text>().text = "" +
                "WELCOME TO RIFT V7";
            Variables.MoTDScreen.GetComponent<Text>().text = "" +
                "<color=white>Menu is open sourced and fully undetected as of 4/21\n\n\n\n\n\n\n\nThank you for using the Rift Essentials mod menu.</color>";
            Variables.CoCScreen.GetComponent<Text>().text = "\nWe had glider mods first." + contains;
            if (!PhotonNetwork.InRoom && OtherMods.AntiBanEnabled)
            {
                OtherMods.AntiBanEnabled = false;
            }
                    /*if (menumat == null)
                    {
                        if (Configuration.CurrentTheme == 1)
                        {
                            menumat = Variables.ThanksNXO("https://cdn.discordapp.com/attachments/1220927152065872043/1227738993375055942/90994381381729.png?ex=6629800a&is=66170b0a&hm=5020006d60b922e510b6adb5a7dfb3e2bb386e1cafb26836c0be2675d9a914ce&");
                        }
                        else
                        {
                            menumat = null;
                        }
                    }*/
                    if (PhotonNetwork.InRoom)
            {
                Variables.isMaster();
            } else { }
            try
            {
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if ((toOpen || keyboardOpen))
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }

                        UnityEngine.Object.Destroy(menu, 2);
                        menu = null;

                        UnityEngine.Object.Destroy(reference);
                        reference = null;

                        float flipStrength = 235f;
                        float spinStrength = 145f;
                        menu.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.insideUnitSphere * flipStrength);
                        Vector3 randomSpin = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * spinStrength;
                        menu.GetComponent<Rigidbody>().AddTorque(randomSpin);
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
            try
            {
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                }
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            } catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
        }
        public static bool BanGun = false;
        public static void CreateMenu()
        {
            if (Variables.drawV2)
            {
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = MenuColor;
                /*if (BanGun)
                {
                    menuBackground.GetComponent<Renderer>().material = menumat;
                }
                else
                {
                    menuBackground.GetComponent<Renderer>().material.color = MenuColor;
                }*/
                menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
                /*colorChanger = menuBackground.AddComponent<ColorChanger>();
                colorChanger.colorInfo = backgroundColor;
                colorChanger.Start();*/
                canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;
                text = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
                text.font = currentFont;
                text.text = PluginInfo.Name + " [" + (pageNumber + 1).ToString() + "]";
                text.fontSize = 1;
                text.color = textColors[0];
                text.supportRichText = true;
                text.fontStyle = FontStyle.Italic;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.28f, 0.05f);
                component.position = new Vector3(0.06f, 0f, 0.165f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                GameObject disconnectbutton = null;
                if (fpsCounter)
                {
                    fpsObject = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
                    fpsObject.font = currentFont;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    fpsObject.color = textColors[0];
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Italic;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.28f, 0.02f);
                    component2.position = new Vector3(0.06f, 0f, 0.135f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }
                if (disconnectButton)
                {
                    disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(keyboardButton)) { disconnectbutton.layer = 2; }
                    UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                    disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                    disconnectbutton.transform.parent = menuBackground.transform;
                    disconnectbutton.transform.rotation = Quaternion.identity;
                    disconnectbutton.transform.localScale = new Vector3(1f, 1f, 0.08f);
                    disconnectbutton.transform.localPosition = new Vector3(0.0f, 0f, 0.6f);
                    disconnectbutton.GetComponent<Renderer>().material.color = SideButtonsColor;
                    disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";
                    Text discontext = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
                    discontext.text = "Disconnect";
                    discontext.font = currentFont;
                    discontext.fontSize = 1;
                    discontext.color = textColors[0];
                    discontext.alignment = TextAnchor.MiddleCenter;
                    discontext.resizeTextForBestFit = true;
                    discontext.resizeTextMinSize = 0;
                    RectTransform rectt = discontext.GetComponent<RectTransform>();
                    rectt.localPosition = Vector3.zero;
                    rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                    rectt.localPosition = new Vector3(0.06f, 0f, 0.23f);
                    rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }
                if (Variables.isOutline && Variables.isOutline1)
                {
                    GameObject Outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(Outline.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(Outline.GetComponent<BoxCollider>());
                    Outline.transform.parent = menu.transform;
                    Outline.transform.rotation = Quaternion.identity;
                    Outline.transform.localScale = new Vector3(0.09f, 0.9f, 1.02f);
                    Outline.GetComponent<Renderer>().material.color = OutlineColor;
                    Outline.transform.position = menuBackground.transform.position;
                    if (disconnectButton)
                    {
                        GameObject OutlineDisconnect = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(OutlineDisconnect.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(OutlineDisconnect.GetComponent<BoxCollider>());
                        OutlineDisconnect.transform.parent = menuBackground.transform;
                        OutlineDisconnect.transform.rotation = Quaternion.identity;
                        OutlineDisconnect.transform.localScale = new Vector3(0.9f, 1.02f, 0.1f);
                        OutlineDisconnect.GetComponent<Renderer>().material.color = OutlineColor;
                        OutlineDisconnect.transform.position = new Vector3(disconnectbutton.transform.position.x, disconnectbutton.transform.position.y, disconnectbutton.transform.position.z);
                    }
                }
                if (InCategory)
                {
                    GameObject HomeButton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    float num5 = 0.84f;
                    HomeButton.GetComponent<BoxCollider>().isTrigger = true;
                    HomeButton.transform.parent = menu.transform;
                    HomeButton.transform.rotation = Quaternion.identity;
                    HomeButton.transform.localScale = new Vector3(0.09f, 0.8f, 0.07f);
                    HomeButton.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num5);
                    HomeButton.AddComponent<Classes.Button>().relatedText = "BackToHome";
                    HomeButton.GetComponent<Renderer>().material.color = SideButtonsColor;
                    Text text2 = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
                    text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                    text2.text = "Return";
                    text2.fontSize = 1;
                    text2.alignment = TextAnchor.MiddleCenter;
                    text2.resizeTextForBestFit = true;
                    text2.resizeTextMinSize = 0;
                    RectTransform component2 = text2.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.2f, 0.03f) * GorillaLocomotion.Player.Instance.scale;
                    component2.localPosition = new Vector3(0.064f, 0f, 0.118f - num5 / 2.55f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                    GameObject HomeOutline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    HomeOutline.transform.parent = menu.transform;
                    HomeOutline.transform.rotation = Quaternion.identity;
                    HomeOutline.transform.localScale = new Vector3(0.08f, 0.83f, 0.073f);
                    HomeOutline.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num5);
                    HomeOutline.GetComponent<Renderer>().material.color = OutlineColor;
                }
                buttonsPerPage = 6;
                CreatePageButtons(7 * 0.1f);
                ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                for (int i = 0; i < activeButtons.Length; i++)
                {
                    CreateButton(i * 0.1f, activeButtons[i]);
                }
            }
        }
        public static bool InCategory = false;
        public static ColorChanger colorChanger;
        public static Text text;
        public static RectTransform component;
        public static void CreatePageButtons(float offset)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(keyboardButton)) { gameObject.layer = 2; }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.78f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
            gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";
            Text PreviousPageText;
            PreviousPageText = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
            PreviousPageText.font = currentFont;
            PreviousPageText.text = Variables.TextConfiguration1;
            PreviousPageText.fontSize = 1;
            PreviousPageText.color = textColors[0];
            PreviousPageText.alignment = TextAnchor.MiddleCenter;
            PreviousPageText.resizeTextForBestFit = true;
            PreviousPageText.resizeTextMinSize = 0;
            component = PreviousPageText.GetComponent<RectTransform>();
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(keyboardButton)) { gameObject.layer = 2; }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.78f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset + 1 * 0.1f);
            gameObject.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
            gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";
            Text NextPageText;
            NextPageText = new GameObject { transform = { parent = canvasObject.transform } }.AddComponent<Text>();
            NextPageText.font = currentFont;
            NextPageText.text = Variables.TextConfiguration;
            NextPageText.fontSize = 1;
            NextPageText.color = textColors[0];
            NextPageText.alignment = TextAnchor.MiddleCenter;
            NextPageText.resizeTextForBestFit = true;
            NextPageText.resizeTextMinSize = 0;
            component = NextPageText.GetComponent<RectTransform>();
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(keyboardButton))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.78f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = Variables.ButtonEnabled;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
            }
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            if (Variables.normalFont)
            {
                currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            }
            if (!Variables.normalFont)
            {
                currentFont = Gothic;
            }
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                if (TPC != null)
                {
                    if (Variables.isPCNormal)
                    {
                        TPC.transform.position = new Vector3(-999f, -999f, -999f);
                        TPC.transform.rotation = Quaternion.identity;
                        GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = Variables.MenuColor1;
                        GameObject.Destroy(bg, Time.deltaTime);
                    }
                    if (Variables.isPCSky)
                    {
                        TPC.transform.position = GameObject.Find("Third Person Camera").transform.position = new Vector3(-0.1f, -0.1f, -0.1f);
                        TPC.transform.rotation = Quaternion.identity;
                        /*GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                        GameObject.Destroy(bg, Time.deltaTime);*/
                    }
                    if (Variables.isPCFace)
                    {
                        TPC.transform.position = new Vector3(-67.9299f, 11.9144f, -84.2019f);
                        TPC.transform.rotation = Quaternion.identity;
                        /*GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                        GameObject.Destroy(bg, Time.deltaTime);*/
                    }
                    if (Variables.isPCReportCam)
                    {
                        TPC.transform.position = new Vector3(-63.75f, 3.634f, -65f);
                        TPC.transform.rotation = Quaternion.identity;
                        /*GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                        GameObject.Destroy(bg, Time.deltaTime);*/
                    }
                    /*
                    if (Variables.isPCReportCam2)
                    {
                        TPC.transform.position = new Vector3(-59.6395f, 16.5243f, -106.0863f);
                        TPC.transform.rotation = Quaternion.identity;
                        GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                        GameObject.Destroy(bg, Time.deltaTime);
                    }*/ // fucking rotation bruh
                    if (Variables.isPCCity)
                    {
                        TPC.transform.position = new Vector3(-39.6395f, 16.5243f, -306.0863f);
                        TPC.transform.rotation = Quaternion.identity;
                        /*GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                        bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                        bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                        GameObject.Destroy(bg, Time.deltaTime);*/
                    }
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            if (!Variables.isrgbMenu)
            {
                colorChanger.colorInfo = backgroundColor;
            }
            else
            {
                colorChanger.colorInfo = isRainbowMenu;
            }
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            if (buttonText == "BackToHome")
            {
                buttonsType = 0;
                InCategory = false;
                if (!Settings.ResetToDefault)
                {
                    pageNumber = Settings.SavePage;
                }
            }
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            }
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isCategoryButton)
                        {
                            InCategory = true;
                        }
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                if (target.toolTip != "")
                                {
                                    NotifiLib.SendNotification("<color=grey>[</color><color=green>TOOLTIP</color><color=grey>]</color> " + target.toolTip);
                                }
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            if (target.toolTip != "")
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>TOOLTIP</color><color=grey>]</color> " + target.toolTip);
                            }
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        // Variables
        // Important
        // Objects
        public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        // Data
            public static int pageNumber = 0;
            public static int buttonsType = 0;
    }
}