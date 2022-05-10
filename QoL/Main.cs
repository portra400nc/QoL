using System;
using System.Collections;
using MelonLoader;
using MoleMole;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;

namespace QoL
{
    public class Main : MonoBehaviour
    {
        public Main(IntPtr ptr) : base(ptr)
        {
        }

        public Main() : base(ClassInjector.DerivedConstructorPointer<Main>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        #region Properties

        public static int TargetFPS = 300;

        public static bool ShowCd = true;
        public static bool ShowMenu;

        public static bool EnableFastTxt = true;
        public static bool EnableFastCutscene;
        public static bool EnableCam;
        public static bool HideMinimap;
        public static bool DisableLoadingScreen = true;


        public static bool CamIsActive;

        public static GameObject ActiveAvatar;
        public static GameObject AvatarRoot;

        public static Transform NewcamTarget;
        public static float DistanceFromTarget = 20f;
        public static float XOffset;
        public static float YOffset = 1.5f;
        public static float ZOffset;
        public static float NewcamFOV = 45f;


        public static Camera Maincam;
        public static Camera Newcam;
        public static GameObject MaincamObj;
        public static GameObject NewcamObj;

        private static GameObject _topRight;
        private static GameObject _topLeft;
        private static GameObject _playerProfile;
        private static GameObject _quest;
        private static GameObject _latency;
        private static GameObject _chat;
        private static GameObject _minimap;

        public static GameObject Txt;
        public static GameObject Cutscene;
        public static GameObject UID;
        public static GameObject UID2;


        public static GUILayoutOption[] ButtonSize;
        public static GUILayoutOption[] ButtonSize2;

        public static string UIDText = "Hello!";

        private static bool _isVisible = true;
        private static float uiScale = 1;

        private static int _winW = 250;
        private static int _winH = 50;
        public Rect windowRect = new Rect((Screen.width - _winW) / 2, 100, _winW, _winH);

        #endregion

        public void Start()
        {
            SetFPS();
            MelonCoroutines.Start(FindElements());
        }

        public void OnGUI()
        {
            if (ShowMenu)
                windowRect = GUILayout.Window(2, windowRect, (GUI.WindowFunction) UIDWindow, "QoL by portra",
                    new GUILayoutOption[0]);
        }

        public void UIDWindow(int id)
        {
            if (id == 2)
            {
                ButtonSize = new[]
                {
                    GUILayout.Width(40),
                    GUILayout.Height(20)
                };
                ButtonSize2 = new[]
                {
                    GUILayout.Width(60),
                    GUILayout.Height(20)
                };
                EnableFastTxt = GUILayout.Toggle(EnableFastTxt, "Fast Text Speed", new GUILayoutOption[0]);
                EnableFastCutscene =
                    GUILayout.Toggle(EnableFastCutscene, "Fast Cutscene Speed", new GUILayoutOption[0]);
                HideMinimap = GUILayout.Toggle(HideMinimap, "Hide Minimap", new GUILayoutOption[0]);
                EnableCam = GUILayout.Toggle(EnableCam, "Custom Camera Distance", new GUILayoutOption[0]);
                DisableLoadingScreen = GUILayout.Toggle(DisableLoadingScreen, "Disable Loading Screens",
                    new GUILayoutOption[0]);

                GUILayout.Space(20);

                GUILayout.Label("Settings", new GUILayoutOption[0]);

                GUILayout.Space(10);

                GUILayout.Label($"Camera Distance: {DistanceFromTarget:F1}", new GUILayoutOption[0]);
                DistanceFromTarget = GUILayout.HorizontalSlider(DistanceFromTarget, -5f, 100f, new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", ButtonSize2))
                    DistanceFromTarget = 20f;
                if (GUILayout.Button("-", ButtonSize))
                    DistanceFromTarget -= 0.1f;
                if (GUILayout.Button("+", ButtonSize))
                    DistanceFromTarget += 0.1f;
                GUILayout.EndHorizontal();
                GUILayout.Label($"Field of View: {NewcamFOV:F0}", new GUILayoutOption[0]);
                NewcamFOV = GUILayout.HorizontalSlider(NewcamFOV, 1f, 160f, new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", ButtonSize2))
                    NewcamFOV = 45f;
                if (GUILayout.Button("-", ButtonSize))
                    NewcamFOV -= 1f;
                if (GUILayout.Button("+", ButtonSize))
                    NewcamFOV += 1f;
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", ButtonSize2))
                    XOffset = 0f;
                if (GUILayout.Button("-", ButtonSize))
                    XOffset -= 0.1f;
                if (GUILayout.Button("+", ButtonSize))
                    XOffset += 0.1f;
                GUILayout.Label($"X Offset: {XOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", ButtonSize2))
                    YOffset = 1.5f;
                if (GUILayout.Button("-", ButtonSize))
                    YOffset -= 0.1f;
                if (GUILayout.Button("+", ButtonSize))
                    YOffset += 0.1f;
                GUILayout.Label($"Y Offset: {YOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", ButtonSize2))
                    ZOffset = 0f;
                if (GUILayout.Button("-", ButtonSize))
                    ZOffset -= 0.1f;
                if (GUILayout.Button("+", ButtonSize))
                    ZOffset += 0.1f;
                GUILayout.Label($"Z Offset: {ZOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();

                GUILayout.Space(10);

                GUILayout.Label("UID", new GUILayoutOption[0]);
                UIDText = GUILayout.TextField(UIDText, new GUILayoutOption[0]);

                GUILayout.Space(10);

                GUILayout.Label($"FPS Limit: {TargetFPS}", new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Apply", new GUILayoutOption[0]))
                    SetFPS();
                if (GUILayout.Button("-", new GUILayoutOption[0]))
                    TargetFPS -= 10;
                if (GUILayout.Button("+", new GUILayoutOption[0]))
                    TargetFPS += 10;
                GUILayout.EndHorizontal();
            }

            GUI.DragWindow();
        }

        public void Update()
        {
            if (ShowMenu)
                Focused = false;

            UpdateInput();
            FindObjects();
            CamComponents();
            SetTextSpeed();
            SetCutsceneSpeed();
            SetUID();
            SetLimiters();

            if (MaincamObj && NewcamObj && Maincam)
                SetCam();
        }

        private void UpdateInput()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
                ToggleHUD();
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.BackQuote))
                ShowMenu = !ShowMenu;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
                ShowCd = !ShowCd;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
                EnableCam = !EnableCam;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                DistanceFromTarget--;
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                DistanceFromTarget++;
        }

        #region MainFunctions

        private static void SetTextSpeed()
        {
            if (EnableFastTxt && Txt && Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
        }

        private static void SetCutsceneSpeed()
        {
            if (!EnableFastCutscene || !Cutscene) return;
            Time.timeScale = Cutscene.activeInHierarchy ? 5f : 1f;
        }

        private static void SetUID()
        {
            if (UID && UID.GetComponent<Text>().text != UIDText)
                UID.GetComponent<Text>().text = UIDText;
            if (UID2 && UID2.GetComponent<Text>().m_Text != UIDText)
                UID2.GetComponent<Text>().m_Text = UIDText;
        }

        private void SetCam()
        {
            if (EnableCam)
            {
                if (!CamIsActive)
                    EnableCustomCam();
            }
            else
            {
                if (CamIsActive)
                    DisableCustomCam();
            }

            if (CamIsActive && MaincamObj.activeInHierarchy)
                EnableCustomCam();
            if (!CamIsActive && NewcamObj.activeInHierarchy)
                DisableCustomCam();
        }

        private static void CamComponents()
        {
            if (MaincamObj)
            {
                if (Maincam == null)
                    Maincam = MaincamObj.GetComponent<Camera>();

                if (NewcamObj == null)
                {
                    NewcamObj = Instantiate(MaincamObj);
                    if (NewcamObj.GetComponent<CameraController>() == null)
                        NewcamObj.AddComponent<CameraController>();
                }
            }

            if (NewcamObj)
            {
                if (Newcam == null)
                    Newcam = NewcamObj.GetComponent<Camera>();
            }
        }

        public void EnableCustomCam()
        {
            if (!MaincamObj || !NewcamObj || !Maincam) return;

            NewcamObj.SetActive(true);
            MaincamObj.SetActive(false);
            CamIsActive = true;
        }

        public void DisableCustomCam()
        {
            if (!MaincamObj || !NewcamObj) return;

            NewcamObj.SetActive(false);
            MaincamObj.SetActive(true);
            CamIsActive = false;
        }

        public void ToggleHUD()
        {
            switch (_isVisible)
            {
                case true:
                    if (_topRight)
                        _topRight.transform.localScale = new Vector3(0, 0, 0);
                    if (_topLeft)
                        _topLeft.transform.localScale = new Vector3(0, 0, 0);
                    if (_quest)
                        _quest.transform.localScale = new Vector3(0, 0, 0);
                    if (_playerProfile)
                        _playerProfile.transform.localScale = new Vector3(0, 0, 0);
                    if (_latency)
                        _latency.transform.localScale = new Vector3(0, 0, 0);
                    if (_chat)
                        _chat.transform.localScale = new Vector3(0, 0, 0);
                    if (UID)
                        UID.transform.localScale = new Vector3(0, 0, 0);
                    if (_minimap)
                        _minimap.transform.localScale =
                            HideMinimap ? new Vector3(0, 0, 0) : new Vector3(uiScale, uiScale, uiScale);
                    _isVisible = false;
                    break;
                default:
                    if (_topRight)
                        _topRight.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_topLeft)
                        _topLeft.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_quest)
                        _quest.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_playerProfile)
                        _playerProfile.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_latency)
                        _latency.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_chat)
                        _chat.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (UID)
                        UID.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (_minimap)
                        _minimap.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    _isVisible = true;
                    break;
            }
        }

        private static void SetFPS()
        {
            Application.targetFrameRate = TargetFPS;
        }

        #endregion

        #region HelperFunctions

        private static IEnumerator FindElements()
        {
            for (;;)
            {
                if (EnableFastTxt && Txt == null)
                    Txt = GameObject.Find(
                        "/Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                if (EnableFastCutscene && Cutscene == null)
                    Cutscene = GameObject.Find("/Canvas/Pages/InLevelCutScenePage");
                if (UID == null)
                    UID = GameObject.Find("/BetaWatermarkCanvas(Clone)/Panel/TxtUID");
                if (UID2 == null)
                    UID2 = GameObject.Find(
                        "/Canvas/Pages/PlayerProfilePage/GrpProfile/Right/GrpPlayerCard/UID/Layout/PlayerID");
                yield return new WaitForSeconds(1f);
            }
        }

        private void FindObjects()
        {
            if (MaincamObj == null)
                MaincamObj = GameObject.Find("/EntityRoot/MainCamera(Clone)");
            if (AvatarRoot == null)
                AvatarRoot = GameObject.Find("/EntityRoot/AvatarRoot");
            if (_topRight == null)
                _topRight = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/GrpMainBtn/GrpMainToggle");
            if (_topLeft == null)
                _topLeft = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpButtons");
            if (_quest == null)
                _quest = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnToggleQuest");
            if (_playerProfile == null)
                _playerProfile = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnPlayerProfile");
            if (_latency == null)
                _latency = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/NetworkLatency");
            if (_chat == null)
                _chat = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/Chat/Content");
            if (_minimap == null)
                _minimap = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpMiniMap");

            if (AvatarRoot)
            {
                try
                {
                    if (ActiveAvatar == null)
                        FindActiveAvatar();
                    if (!ActiveAvatar.activeInHierarchy)
                        FindActiveAvatar();
                }
                catch
                {
                }
            }
        }

        private static void SetLimiters()
        {
            if (DistanceFromTarget < -5f)
                DistanceFromTarget = -5f;
            if (DistanceFromTarget > 100f)
                DistanceFromTarget = 100f;
            if (NewcamFOV < 1f)
                NewcamFOV = 1f;
            if (NewcamFOV > 160f)
                NewcamFOV = 160f;
        }

        public void FindActiveAvatar()
        {
            foreach (var a in AvatarRoot.transform)
            {
                var active = a.Cast<Transform>();
                if (!active.gameObject.activeInHierarchy) continue;
                NewcamTarget = active;
                ActiveAvatar = active.gameObject;
            }
        }

        private static bool Focused
        {
            get => Cursor.lockState == CursorLockMode.Locked;
            set
            {
                Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = value == false;
            }
        }

        public static GameObject FindObject(GameObject parent, string name)
        {
            GameObject candidate = null;
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (var t in trs)
            {
                if (t == null) continue;
                if (t.name == name)
                    candidate = t.gameObject;
            }

            Array.Clear(trs, 0, trs.Length);
            return candidate;
        }

        #endregion
    }
}