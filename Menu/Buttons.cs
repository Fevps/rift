using BepInEx;
using Cinemachine;
using Photon.Pun;
using Photon.Realtime;
using Rift.Mods;
using Rift.Classes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Rift.Settings;

namespace Rift.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Join Discord Server", method =() => Functions.JoinDiscordServer(), isTogglable = false, toolTip = "Joins the menu's main discord server"},
                new ButtonInfo { buttonText = "Configuration", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Room Settings", method =() => SettingsMods.RoomSettings(), isTogglable = false, toolTip = "Opens the room settings page for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Movement Mods", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the essential settings for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Player Mods", method =() => SettingsMods.PlayerSettings(), isTogglable = false, toolTip = "Opens the player settings for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Visual Mods", method =() => SettingsMods.VisualSettings(), isTogglable = false, toolTip = "Opens the visual settings for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Entity Mods", method =() => SettingsMods.EntitySettings(), isTogglable = false, toolTip = "Opens the entity settings for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Overpowered Mods", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the overpowered mods for the menu.", isCategoryButton = true},
                //new ButtonInfo { buttonText = "Other Player Mods", method =() => SettingsMods.OtherPlayerSettings(), isTogglable = false, toolTip = "Opens the other player mods for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Miscellaneous Mods", method =() => SettingsMods.MiscellaneousSettings(), isTogglable = false, toolTip = "Opens the miscelleneous mods for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Safety Settings", method =() => SettingsMods.SafetySettings(), isTogglable = false, toolTip = "Opens the safety settings for the menu.", isCategoryButton = true},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Mod Configuration", method =() => SettingsMods.GameModeMods(), isTogglable = false, isCategoryButton = false},
                new ButtonInfo { buttonText = "Change Menu Theme", method =() => Configuration.ChangeMenuThemeV2(), isTogglable = false, toolTip = "Change Menu Theme."},
                //new ButtonInfo { buttonText = "Add Menu Material", method =() => Main.BanGun = true, disableMethod =() => Main.BanGun = false, isTogglable = true, enabled = true, toolTip = "Change Menu Material."},
                new ButtonInfo { buttonText = "Change Button Sound Type", method =() => Configuration.ChangeButtonSoundType(), isTogglable = false, toolTip = "Change Button Sound Type."},
                new ButtonInfo { buttonText = "Change PC Menu Background", method =() => Configuration.ChangeMenuPCPosition(), isTogglable = false, toolTip = "Change Menu PC Theme."},
                new ButtonInfo { buttonText = "Change Arrow Type", method =() => Configuration.ChangeArrowType(), isTogglable = false, toolTip = "Change Menu Arrow Type."},
                new ButtonInfo { buttonText = "Change Antireport Block Scale", method =() => AntiReport.ARSizeChanger(), isTogglable = false},
                new ButtonInfo { buttonText = "Enable Menu Outline", method =() => Configuration.EnableMenuOutline(), disableMethod =() => Configuration.DisableMenuOutline(), isTogglable = true, enabled = true, toolTip = "Enables a menu outline."},

                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                //new ButtonInfo { buttonText = "Custom Boards", method =() => Variables.RiftMenuCustomBoards(), isTogglable = true, enabled = true, toolTip = "This button enables custom boards for the menu, refer from turning this off."},
                new ButtonInfo { buttonText = "[need to be activated]", method =() => Configuration.EnableMenuOutline1(), disableMethod =() => Configuration.DisableMenuOutline1(), isTogglable = true, enabled = true},
            },

            new ButtonInfo[] { // Room Settings
                new ButtonInfo { buttonText = "First Person Camera", method =() => Configuration.FirstPersonCameraFix(), disableMethod =() => Configuration.DisableFPC(), isTogglable = true, toolTip = "Changes your camera position to your head."},
                new ButtonInfo { buttonText = "Disconnect", method =() => Functions.CurrentDisconnect(), isTogglable = false, toolTip = "Disconnects you from your current lobby."},
                new ButtonInfo { buttonText = "Less Laggy Servers", method =() => Configuration.LessLaggyServers(), isTogglable = true, toolTip = "Disconnects you from your current lobby."},
                new ButtonInfo { buttonText = "Join Random Room", method =() => Functions.JoinRandomRoom(), isTogglable = false, toolTip = "Joins a random public lobby of whatever map you have loaded."},
                new ButtonInfo { buttonText = "Lobby Hop", method =() => Functions.LobbyHop(), isTogglable = false, toolTip = "Disconnects then joins a random public lobby of whatever map you have loaded."},
                new ButtonInfo { buttonText = "Auto Join Private", method =() => Functions.AutoJoinPrivate(), isTogglable = false, toolTip = "When you leave the lobby, it auto joins a private lobby."},
                new ButtonInfo { buttonText = "Join Random Ghost Code", method =() => Functions.AutoJoinRandomGhostCode(), isTogglable = false, toolTip = "Automatically joins random ghost codes, randomized."},

                new ButtonInfo { buttonText = "Switch Region To US", method =() => Configuration.USRegion(), isTogglable = true, toolTip = "Forces application to connect to US servers."},
                new ButtonInfo { buttonText = "Switch Region To US West", method =() => Configuration.USWestRegion(), isTogglable = true, toolTip = "Forces application to connect to USW servers."},
                new ButtonInfo { buttonText = "Switch Region To EU", method =() => Configuration.EURegion(), isTogglable = true, toolTip = "Forces application to connect to EU servers."},
                new ButtonInfo { buttonText = "Connect To US", method =() => Configuration.ConnectToUSRegion(), isTogglable = false, toolTip = "Forces application to connect to US servers."},
                new ButtonInfo { buttonText = "Connect To US West", method =() => Configuration.ConnectToUSWestRegion(), isTogglable = false, toolTip = "Forces application to connect to USW servers."},
                new ButtonInfo { buttonText = "Connect To EU", method =() => Configuration.ConnectToEURegion(), isTogglable = false, toolTip = "Forces application to connect to EU servers."},
            },

            new ButtonInfo[] { // Miscellaneous
                new ButtonInfo { buttonText = "Unlock Competitive Queue", method =() => Functions.UnlockCompetitive(), isTogglable = false, toolTip = "Unlocks competitive queue."},
                new ButtonInfo { buttonText = "Accept ToS", method =() => Functions.AcceptToS(), isTogglable = false, toolTip = "Removes the annoying hold down face button queue streen."},
                new ButtonInfo { buttonText = "Grab All Info", method =() => Miscellaneous.GetInfo(), isTogglable = false, toolTip = "Grabs Everyones ID and saves it to a folder."},
                new ButtonInfo { buttonText = "Launch City Rocket", method =() => Functions.LaunchRocket(), isTogglable = false, toolTip = "Launches the city rocket."},
                new ButtonInfo { buttonText = "Restart Game", method =() => Functions.RestartGame(), isTogglable = false, toolTip = "Closes your game then attempts to open gorilla tag game id."},
                new ButtonInfo { buttonText = "Quit Game", method =() => Functions.QuitGame(), isTogglable = false, toolTip = "Closes your game, lmao."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Keyboard Movement", method =() => Functions.Keyboarding(), isTogglable = true, toolTip = "Lets you control your screen and your rig with your mouse and keys."},
                new ButtonInfo { buttonText = "Platforms <color=gray>[</color>G<color=gray>]</color>", method =() => Platforms.Plattys(Variables.ButtonDisabled), isTogglable = true, toolTip = "Platforms, left and right grip to activate platforms."},
                new ButtonInfo { buttonText = "Drop Platforms <color=gray>[</color>G<color=gray>]</color>", method =() => Platforms.ThrowPlattys(Variables.ButtonDisabled), isTogglable = true, toolTip = "Platforms, left and right grip to activate platforms."},
                new ButtonInfo { buttonText = "Speed Boost", method =() => Functions.PlayerSpeedBoost(), isTogglable = true, toolTip = "Speed Boost, speed is your preference, change speed in settings."},
                new ButtonInfo { buttonText = "Slide Control", method =() => Functions.SlideController(), isTogglable = true, toolTip = "Slide Control, control is your preference, change amount in settings."},
                new ButtonInfo { buttonText = "Fly <color=gray>[</color>RG<color=gray>]</color>", method =() => Functions.PlayerFly(), isTogglable = true, toolTip = "Fly, speed is your preference, change speed in settings."},
                new ButtonInfo { buttonText = "Velocity Fly <color=gray>[</color>RG<color=gray>]</color>", method =() => Functions.BouncyFly(), disableMethod =() => Functions.FixVelocity(), isTogglable = true, toolTip = "Fly, speed is your preference, change speed in settings."},
                new ButtonInfo { buttonText = "No Clip", method =() => Functions.DisableMeshColliders(), isTogglable = true, toolTip = "Disables mesh colliders when holding either trigger."},
                new ButtonInfo { buttonText = "Playspace Movement", method =() => Movement.PlayspaceMovement(), isTogglable = true, toolTip = "Either grip moves you in a way to look like you're moving around irl."},
                new ButtonInfo { buttonText = "Slingshot Yourself", method =() => Movement.SlingshotYourself(), isTogglable = true, toolTip = "Shoots you forwards in a slingshot moving manner."},
                new ButtonInfo { buttonText = "Jetpack Monkey", method =() => Functions.IronMonkey(), isTogglable = true, toolTip = "Holding both grips will activate jetpacks for your player."},
                new ButtonInfo { buttonText = "Auto Run", method =() => Movement.AutoRun(), isTogglable = true, toolTip = "Either grip moves your arms up and down and forward and backwards to move forward."},
                new ButtonInfo { buttonText = "Car Monkey", method =() => Functions.CarMonke(), isTogglable = true, toolTip = "Using grips will move you around where ever you're facing, like a car."},
                new ButtonInfo { buttonText = "Up And Down", method =() => Functions.UpAndDown(), isTogglable = true, toolTip = "Moves you up and down via grip you're pressing, left for down and right for up."},
                new ButtonInfo { buttonText = "C4 <color=grey>[</color>G<color=grey>]</color>", method =() => Functions.C4(), disableMethod =() => Functions.DisableC4(), isTogglable = true, toolTip = "Explodes a gameobject when you click grip."},
                new ButtonInfo { buttonText = "Checkpoint <color=grey>[</color>G<color=grey>]</color>", method =() => Functions.Checkpoint(), disableMethod =() => Functions.DisableCheckPoint(), isTogglable = true, toolTip = "Teleport to a sphere when holding right grip."},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => Functions.TpGun(), isTogglable = true, toolTip = "Teleports you to where ever your pointer is facing."},
                new ButtonInfo { buttonText = "Player Rig Gun", method =() => Functions.RigGun(), isTogglable = true, toolTip = "Disables your rig and transforms it to your pointer."},
                new ButtonInfo { buttonText = "Helicopter <color=grey>[</color>A<color=grey>]</color>", method =() => Functions.Helicopter(), isTogglable = true, toolTip = "Helicopter monkey, use primary to activate."},
                new ButtonInfo { buttonText = "Beyblade", method =() => Movement.Beyblade(), disableMethod =() => Movement.disableBlade(), isTogglable = true},
                new ButtonInfo { buttonText = "Spin Head", method =() => Functions.SpinHead(), disableMethod =() => Functions.FixHead(), isTogglable = true, toolTip = "Spins your head via whatever setting you have, in settings you can change."},

                new ButtonInfo { buttonText = "Reverse Gravity", method =() => Functions.ReverseGravity(), isTogglable = true, toolTip = "Reverses your player's gravity fully, disable to restore."},
                new ButtonInfo { buttonText = "Zero Gravity", method =() => Functions.ZeroGravity(), isTogglable = true, toolTip = "Removes your player's gravity fully, disable to restore."},
                new ButtonInfo { buttonText = "Low Gravity", method =() => Functions.LowGravity(), isTogglable = true, toolTip = "Lowers your player's gravity fully, disable to restore."},
                new ButtonInfo { buttonText = "High Gravity", method =() => Functions.HighGravity(), isTogglable = true, toolTip = "Applies more grabity to your player's gravity, disable to restore."},
                
                new ButtonInfo { buttonText = "Force Tag Freeze", method =() => Functions.ForceTagFreeze(), disableMethod =() => Functions.FixTagFreeze(), isTogglable = true, toolTip = "Forces the freeze delay you receive when you are tagged."},
                new ButtonInfo { buttonText = "Disable Tag Freeze", method =() => Functions.DisableTagFreeze(), isTogglable = true, toolTip = "Disables the delay you receive when getting tagged."},
            },

            new ButtonInfo[] { // Overpowered Mods
                new ButtonInfo { buttonText = "<color=red>Antiban</color> [<color=red>RISKY</color>]", method =() => OtherMods.AntiBan(), isTogglable = false},
                new ButtonInfo { buttonText = "Set Master", method =() => OtherMods.SetMasterModded(), isTogglable = false},

                new ButtonInfo { buttonText = "Tag Aura", method =() => OtherMods.TagAura(), isTogglable = true},
                new ButtonInfo { buttonText = "Tag Aura [ONE ARM]", method =() => OtherMods.TagAuraOneArm(), isTogglable = true},
                new ButtonInfo { buttonText = "Tag All", method =() => OtherMods.InfectAll(), disableMethod =() => GorillaTagger.Instance.offlineVRRig.enabled = true, isTogglable = true},
                new ButtonInfo { buttonText = "Tag Self [M]", method =() => OtherMods.InfectSelf(), isTogglable = false},

                new ButtonInfo { buttonText = "Annoy All", method =() => Movement.AnnoyRandomPlayer(), isTogglable = true},

                new ButtonInfo { buttonText = "Grab Glider [SS] [M] [SKY]", method =() => OtherMods.GrabAGlider(), isTogglable = true, toolTip = "Grab a glider."},
                new ButtonInfo { buttonText = "Grab All Gliders [SS] [M] [SKY]", method =() => OtherMods.GrabEveryGlider(), isTogglable = true},
                new ButtonInfo { buttonText = "Glider All [SS] [M] [SKY]", method =() => OtherMods.GliderAll1(), isTogglable = true, toolTip = "Everyone grab a glider."},
                new ButtonInfo { buttonText = "Spaz Every Glider [SS] [M] [SKY]", method =() => OtherMods.SpamAllGliders(), isTogglable = true},
                new ButtonInfo { buttonText = "Float Gliders [SS] [M] [SKY]", method =() => OtherMods.FloatGliders(), isTogglable = true},
                new ButtonInfo { buttonText = "Respawn Gliders [NW] [SS] [M] [SKY]", method =() => OtherMods.RespawnGliders(), isTogglable = false, toolTip = "Resets every active and non-active glider."},

                new ButtonInfo { buttonText = "Mat All [SS] [W?] [M]", method =() => OtherMods.InfectSpamAll(), isTogglable = true},
                new ButtonInfo { buttonText = "Acid All [CS] [M]", method =() => OtherMods.AcidAll(), isTogglable = false},
                new ButtonInfo { buttonText = "Acid Self [SS] [M]", method =() => OtherMods.AcidSelf(), isTogglable = false},

                new ButtonInfo { buttonText = "Make Red Win [BEACH] [M]", method =() => Functions.MakeRedWin(), isTogglable = false, toolTip = "Addes 3 points to red team to win."},
                new ButtonInfo { buttonText = "Make Blue Win [BEACH] [M]", method =() => Functions.MakeBlueWin(), isTogglable = false, toolTip = "Addes 3 points to blue team to win."},
                new ButtonInfo { buttonText = "+1 Red Score [BEACH] [M]", method =() => Functions.AddScoreToRed(), isTogglable = false, toolTip = "Adds score to red team in beach."},
                new ButtonInfo { buttonText = "+1 Blue Score [BEACH] [M]", method =() => Functions.AddScoreToBlue(), isTogglable = false, toolTip = "Adds score to blue team in beach."},
                new ButtonInfo { buttonText = "Reset Game [BEACH] [M]", method =() => Functions.ResetScores(), isTogglable = false, toolTip = "Sets both of the teams to 0."},
            },

            new ButtonInfo[] { // Visual Mods
                new ButtonInfo { buttonText = "Enable RGB Visuals", method =() => Visuals.isRainbowVisuals = true, disableMethod =() => Visuals.isRainbowVisuals = false, isTogglable = true, toolTip = "Turns visuals to rainbow."},
                new ButtonInfo { buttonText = "Chams", method =() => Visuals.Chams(), disableMethod =() => Visuals.DisableChams(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},
                new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},
                new ButtonInfo { buttonText = "Hand Tracers", method =() => Visuals.HandTracers(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},
                new ButtonInfo { buttonText = "Beacons", method =() => Visuals.Beacons(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},
                new ButtonInfo { buttonText = "Box ESP", method =() => Visuals.BoxESP(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},
                new ButtonInfo { buttonText = "Head ESP", method =() => Visuals.HeadChams(), isTogglable = true, toolTip = "Activates esp for the entire lobby."},

                new ButtonInfo { buttonText = "Draw Mod", method =() => Visuals.RainbowDraw(), isTogglable = true, toolTip = "Draws via using spheres to cumulate a paintbrush."},

                new ButtonInfo { buttonText = "Time Changer", method =() => Visuals.WeatherChangers(), isTogglable = false, toolTip = "Changes the time and sky outside."},//[7][8]
                new ButtonInfo { buttonText = "Activate Rain", enableMethod =() => Visuals.ForceRain(), disableMethod =() => Visuals.ClearWeather(), isTogglable = true, toolTip = "Makes outside rain."},

                new ButtonInfo { buttonText = "Low Quality Settings", method =() => Functions.FPSBoost(), disableMethod =() => Functions.DisableFPSBoost(), isTogglable = true, toolTip = "Takes out extra graphics."},
                new ButtonInfo { buttonText = "Remove Trees", method =() => Functions.RemoveTrees(), disableMethod =() => Functions.EnableTrees(), isTogglable = true, toolTip = "Removes trees until disabled, not permament, just fixing it."},
                new ButtonInfo { buttonText = "Finger Painter", method =() => Variables.EnableFingerPainter(), disableMethod =() => Variables.DisableFingerPainter(), isTogglable = true, toolTip = "ENABLED FINGER PAINTER."},
                new ButtonInfo { buttonText = "Admin Badge", method =() => Variables.EnableAdminBadge(), disableMethod =() => Variables.DisableAdminBadge(), isTogglable = true, toolTip = "ENABLED ADMIN BADGE."},
            },

            new ButtonInfo[] { // Safety
                new ButtonInfo { buttonText = "Antireport [FOREST, CAVES, CITY, SKY]", method =() => AntiReport.AntiReports(), isTogglable = true},
                new ButtonInfo { buttonText = "GameObject Antireport", method =() => AntiReport.GameObjectAntiReport(), disableMethod =() => AntiReport.DisableAntiReport(), isTogglable = true},
                new ButtonInfo { buttonText = "Anti Moderator", method =() => Functions.AntiModerator(), isTogglable = true, toolTip = "Disconnects if a moderator joins the lobby."},
                new ButtonInfo { buttonText = "Disable Network Triggers", method =() => Functions.DisableNetworkTriggers(), disableMethod =() => Functions.EnableNetworkTriggers(), isTogglable = true, toolTip = "Disconnects if a moderator joins the lobby."},
                new ButtonInfo { buttonText = "Disable Finger Movement", method =() => Functions.DisableFingerMovement(), isTogglable = true, toolTip = "Disables all of your fingers until you disable the mod."},
                new ButtonInfo { buttonText = "Disable AFK Kick", method =() => Configuration.DisableAfkKick(), disableMethod =() => Configuration.EnableAfkKick(), isTogglable = true, toolTip = "Disables the kick you receive for being afk."},
                new ButtonInfo { buttonText = "Disable Quit Box", method =() => Configuration.DisableQuitBox(), disableMethod =() => Configuration.EnableQuitBox(), isTogglable = true, toolTip = "Disables the trigger that quits your game."},
                new ButtonInfo { buttonText = "Disable AC Crash", method =() => Configuration.DisableAntiCheatCrash(), disableMethod =() => Configuration.FixAntiCheatCrashing(), isTogglable = true, toolTip = "Disables the disconnect you receive by anticheat."},
            },

            new ButtonInfo[] { // Player 
                new ButtonInfo { buttonText = "Ghost Monkey", method =() => Functions.Ghost(), disableMethod =() => Functions.DisableUpdate(), isTogglable = true, toolTip = "Disables your rig position until you activate it again."},
                new ButtonInfo { buttonText = "Invisible Monkey", method =() => Functions.Invisible(), isTogglable = true, toolTip = "Disables your rig postion until you activate it again."},
                new ButtonInfo { buttonText = "Cocaine Monkey", method =() => Functions.SpazMonkey(), isTogglable = true, toolTip = "Spazzes your rig fast until you disable the mod."},
                new ButtonInfo { buttonText = "Delayed Rig", method =() => Functions.DelayedRig(), disableMethod =() => Functions.FixRig(), isTogglable = true, toolTip = "Delayed rig, disables rig and enables it after a short time."},
                new ButtonInfo { buttonText = "Long Arms", method =() => Functions.UseLongArms(), disableMethod =() => Functions.ResetLongArms(), isTogglable = true, toolTip = "Long arms, size is your preference, change it in settings."},
                new ButtonInfo { buttonText = "Grab Rig", method =() => Functions.GrabRig(), isTogglable = true, toolTip = "Holding any grip will transform your player's rig to via hand."},

                new ButtonInfo { buttonText = "Faster Turn Speed", method =() => Functions.FasterTurnSpeed(), disableMethod =() => Functions.FixTurnSpeed(), isTogglable = true, toolTip = "Makes your player preferences turn speed set from what you have selected to 275."},

                new ButtonInfo { buttonText = "Flick Tagger", method =() => PlayerMods.FlickTag(), isTogglable = true, toolTip = "Extends your arms outwards for possible further tagging."},
                new ButtonInfo { buttonText = "Flick Jump", method =() => Movement.FlickJump(), isTogglable = true, toolTip = "Extends your arms downwards for possible further jumping."},
                new ButtonInfo { buttonText = "Hands In Head", method =() => Functions.HandsInHead(), isTogglable = true, toolTip = "Moves both of your hands in your head when holding right grab."},
                new ButtonInfo { buttonText = "Head In Hands", method =() => Functions.HeadInHands(), isTogglable = true, toolTip = "Moves your head into your right hand when holding right grab."},
                new ButtonInfo { buttonText = "Fish Arms", method =() => PlayerMods.FlipArms(), isTogglable = true, toolTip = "Flips your arms so it looks like you have fish arms."},
                new ButtonInfo { buttonText = "Freeze Arms", method =() => PlayerMods.FreezeArms(), isTogglable = true, toolTip = "Holding grip freezes your arms so it looks like you're lagging."},

                new ButtonInfo { buttonText = "Size Changer", method =() => Functions.ChangeRigSize(), enableMethod =() => Variables.RigSizer(), disableMethod =() => Variables.RigSizer(), isTogglable = true, toolTip = "Changes your rig size based on the controls you hold and use."},
                new ButtonInfo { buttonText = "Big Monkey", method =() => PlayerMods.BigMonkey(), disableMethod =() => PlayerMods.FixScaleMonkey(), isTogglable = true, toolTip = "Slowly brings your player rig scale up to 3f, reset by disabling."},
                new ButtonInfo { buttonText = "Small Monkey", method =() => PlayerMods.SmallMonkey(), disableMethod =() => PlayerMods.FixScaleMonkey(), isTogglable = true, toolTip = "Slowly brings your player rig scale down to 0.2f, reset by disabling."},

                new ButtonInfo { buttonText = "Fake Oculus Menu", method =() => Functions.FakeOculusMenu(), isTogglable = true, toolTip = "Moves your arms/hands in a way to make you look like you're on standalone."},
                new ButtonInfo { buttonText = "Fake Afk Position", method =() => Functions.FakeOculusArms(), isTogglable = true, toolTip = "Moves your arms away from your body to make it look like you're afk."},
                new ButtonInfo { buttonText = "Fake Left Dead Controller", method =() => Functions.FakeLeftController(), isTogglable = true, toolTip = "Moves your left hand in a way to make you look like you're controller is dead."},
                new ButtonInfo { buttonText = "Fake Right Dead Controller", method =() => Functions.FakeRightController(), isTogglable = true, toolTip = "Moves your right hand in a way to make you look like you're controller is dead."},

                new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Functions.LoudHandTaps(), disableMethod =() => Functions.FixHandTaps(), isTogglable = true, toolTip = "Increases your players handtap volume."},
                new ButtonInfo { buttonText = "Quiet Hand Taps", method =() => Functions.SilentHandTaps(), disableMethod =() => Functions.FixHandTaps(), isTogglable = true, toolTip = "Deletes your players handtap volume."},
                new ButtonInfo { buttonText = "No Hand Tap Cooldown", method =() => Functions.NoTapCoolDown(), disableMethod =() => Functions.FixNoTapCooldown(), isTogglable = true, toolTip = "Deletes hand tap cooldown, fix by disabling."},
            },

            new ButtonInfo[] { // Entity
                new ButtonInfo { buttonText = "Request Bug Ownership", method =() => Functions.RequestBugOwnership(), isTogglable = false},
                new ButtonInfo { buttonText = "Request Bat Ownership", method =() => Functions.RequestBatOwnership(), isTogglable = false},
                new ButtonInfo { buttonText = "Check For Entity Ownership", method =() => Functions.CheckIfEntityOwnership(), isTogglable = false},
                new ButtonInfo { buttonText = "Entity ESP", method =() => Functions.EntitiesESP(), isTogglable = true, toolTip = "Activates esp for the animals and entities."},
                new ButtonInfo { buttonText = "Grab Bug", method =() => Functions.GrabBug(), isTogglable = true, toolTip = "Grabs bug when holding right grab, when grip it transforms bug into right hand."},
                new ButtonInfo { buttonText = "Grab Bat", method =() => Functions.GrabBat(), isTogglable = true, toolTip = "Grabs bat when holding right grab, when grip it transforms bat into right hand."},
                new ButtonInfo { buttonText = "Grab Ball", method =() => Functions.GrabBall(), isTogglable = true, toolTip = "Grabs ball when holding right grab, when grip it transforms ball into right hand."},
                new ButtonInfo { buttonText = "Bug Gun", method =() => Functions.BugGun(), isTogglable = true, toolTip = "To where ever your pointer is facing, will be where the bug is via how long you hold it for."},
                new ButtonInfo { buttonText = "Bat Gun", method =() => Functions.BatGun(), isTogglable = true, toolTip = "To where ever your pointer is facing, will be where the bat is via how long you hold it for."},
                new ButtonInfo { buttonText = "Big Bug", method =() => Functions.BigBug(), disableMethod =() => Functions.ResetBug(), isTogglable = true},
                new ButtonInfo { buttonText = "Big Bat", method =() => Functions.BigBat(), disableMethod =() => Functions.ResetBat(), isTogglable = true},
                //new ButtonInfo { buttonText = "Orbit Bug", method =() => Functions.OrbitBug(), isTogglable = true},
                //new ButtonInfo { buttonText = "Orbit Bat", method =() => Functions.OrbitBat(), isTogglable = true},
                new ButtonInfo { buttonText = "Spaz Bug", method =() => Functions.SpazBug(), disableMethod =() => Functions.ResetEntities(), isTogglable = true},
                new ButtonInfo { buttonText = "Spaz Bat", method =() => Functions.SpazBat(), disableMethod =() => Functions.ResetEntities(), isTogglable = true},
                new ButtonInfo { buttonText = "Ride Bug", method =() => Functions.RideBug(), isTogglable = true},
                new ButtonInfo { buttonText = "Ride Bat", method =() => Functions.RideBat(), isTogglable = true},
                new ButtonInfo { buttonText = "Fast Bug", method =() => Functions.FastBug(), disableMethod =() => Functions.ResetSpeeds(), isTogglable = true},
                new ButtonInfo { buttonText = "Fast Bat", method =() => Functions.FastBat(), disableMethod =() => Functions.ResetSpeeds(), isTogglable = true},
                new ButtonInfo { buttonText = "Teleport To Bug", method =() => Functions.TeleportToBug(), isTogglable = false},
                new ButtonInfo { buttonText = "Teleport To Bat", method =() => Functions.TeleportToBat(), isTogglable = false},
                new ButtonInfo { buttonText = "Destroy Entities", method =() => Functions.DestroyAnimals(), isTogglable = false, toolTip = "Teleports every movable entity outside of the maps."},
            },

            new ButtonInfo[] { // Other Player Mods 
                new ButtonInfo { buttonText = "Coming Soon", isTogglable = false},
                new ButtonInfo { buttonText = "Place Holder", isTogglable = false},
                new ButtonInfo { buttonText = "Place Holder", isTogglable = false},
                new ButtonInfo { buttonText = "Place Holder", isTogglable = false},
                new ButtonInfo { buttonText = "Place Holder", isTogglable = false},
                new ButtonInfo { buttonText = "Place Holder", isTogglable = false},
            },

            new ButtonInfo[] { // AntiReports
                /*new ButtonInfo { buttonText = "Return", method =() => SettingsMods.SafetySettings(), isTogglable = false, toolTip = "Opens the safety settings for the menu.", isCategoryButton = true},
                new ButtonInfo { buttonText = "Forest [Antireport]", method =() => AntiReport.AntiReportForest(), isTogglable = true},
                new ButtonInfo { buttonText = "City [Antireport]", method =() => AntiReport.AntiReportCity(), isTogglable = true},
                new ButtonInfo { buttonText = "Mountains [Antireport]", method =() => AntiReport.AntiReportMountains(), isTogglable = true},
                new ButtonInfo { buttonText = "Clouds [Antireport]", method =() => AntiReport.AntiReportSky(), isTogglable = true},
                new ButtonInfo { buttonText = "Canyons [Antireport]", method =() => AntiReport.AntiReportCanyon(), isTogglable = true},
                new ButtonInfo { buttonText = "Caves [Antireport]", method =() => AntiReport.AntiReportCaves(), isTogglable = true},
                new ButtonInfo { buttonText = "Beach [Antireport]", method =() => AntiReport.AntiReportBeach(), isTogglable = true},*/
            },

            /*new ButtonInfo[] { // Game Mod Mods [Overpowered]
                new ButtonInfo { buttonText = "Return To Overpowered", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the overpowered mods for the menu.", isCategoryButton = true},

                new ButtonInfo { buttonText = "Start Battle [BATTLE] [M]", method =() => OtherMods.StartBattle(), isTogglable = false},
                new ButtonInfo { buttonText = "End Battle [BATTLE] [M]", method =() => OtherMods.EndBattle(), isTogglable = false},
                new ButtonInfo { buttonText = "Kill Other Team", method =() => OtherMods.KillOtherTeam(), isTogglable = false},
                new ButtonInfo { buttonText = "Infinite Lives [BATTLE] [M]", method =() => OtherMods.BattleInvincibility(), isTogglable = false},
                new ButtonInfo { buttonText = "All Infinite Lives [BATTLE] [M]", method =() => OtherMods.AllBattleInvincibility(), isTogglable = false},
                new ButtonInfo { buttonText = "Reset Lives [BATTLE] [M]", method =() => OtherMods.ResetHealth(), isTogglable = false},
                new ButtonInfo { buttonText = "Reset All Lives [BATTLE] [M]", method =() => OtherMods.ResetAllHealth(), isTogglable = false},
                new ButtonInfo { buttonText = "Remove 1 Life [BATTLE] [M]", method =() => OtherMods.Down1HP(), isTogglable = false},
                new ButtonInfo { buttonText = "Add 1 Life [BATTLE] [M]", method =() => OtherMods.Up1HP(), isTogglable = false},
                new ButtonInfo { buttonText = "Remove 1 Life All [BATTLE] [M]", method =() => OtherMods.Down1HPAll(), isTogglable = false},
                new ButtonInfo { buttonText = "Add 1 Life All [BATTLE] [M]", method =() => OtherMods.Up1HPAll(), isTogglable = false},

                new ButtonInfo { buttonText = "Start Hunt [HUNT] [M]", method =() => OtherMods.StartHunt(), isTogglable = false},
                new ButtonInfo { buttonText = "End Hunt [HUNT] [M]", method =() => OtherMods.EndHunt(), isTogglable = false},
            },*/

            new ButtonInfo[] { // Mods Configuration [IN CONFIG]
                new ButtonInfo { buttonText = "Go Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, isCategoryButton = true},
                new ButtonInfo { buttonText = "Change Player Speed", method =() => Configuration.ChangePlayerSpeed(), isTogglable = false, toolTip = "Change Player Speed."},
                new ButtonInfo { buttonText = "Change Fly Speed", method =() => Configuration.ChangeFlySpeed(), isTogglable = false, toolTip = "Change Fly Speed."},
                new ButtonInfo { buttonText = "Change Slide Control", method =() => Configuration.ChangeSlideControlControl(), isTogglable = false, toolTip = "Changes Players Slide Control."},
                new ButtonInfo { buttonText = "Change Arm Size", method =() => Configuration.ChangeFlySpeed(), isTogglable = false, toolTip = "Change Arm Size."},
            },
        };
    }
}