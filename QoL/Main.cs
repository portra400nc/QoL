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
        public Main(IntPtr ptr) : base(ptr) { }
        public Main() : base(ClassInjector.DerivedConstructorPointer<Main>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        public static int targetFPS = 300;

        public static bool showCD = true;
        public static bool showMenu;

        public static bool enableTxt = true;
        public static bool enableCutscene = true;
        public static bool enableCam = true;
        public static bool hideMinimap = true;
        public static bool disableLoadingScreen = true;


        public static bool CamIsActive;

        public static GameObject activeAvatar;
        public static GameObject AvatarRoot;

        public static Transform newcamTarget;
        public static float distanceFromTarget = 20f;
        public static float xOffset;
        public static float yOffset = 1.5f;
        public static float zOffset;
        public static float newcamFOV = 45f;


        public static Camera maincam;
        public static Camera newcam;
        public static GameObject maincamObj;
        public static GameObject newcamObj;

        private static GameObject TopRight;
        private static GameObject TopLeft;
        private static GameObject PlayerProfile;
        private static GameObject Quest;
        private static GameObject Latency;
        private static GameObject Chat;
        private static GameObject Minimap;

        public static GameObject Txt;
        public static GameObject Cutscene;
        public static GameObject UID;
        public static GameObject UID2;


        public static GUILayoutOption[] buttonSize;
        public static GUILayoutOption[] buttonSize2;

        public static string UIDText = "Press Ctrl + ` to edit your UID";

        private static bool isVisible = true;
        private static float uiScale = 1;

        private static int winW = 250;
        private static int winH = 50;
        public Rect windowRect = new Rect((Screen.width - winW) / 2, 200, winW, winH);

        public void Start()
        {
            SetFPS();
            MelonCoroutines.Start(FindElements());
        }

        public void OnGUI()
        {
            if (showMenu)
                windowRect = GUILayout.Window(2, windowRect, (GUI.WindowFunction)UIDWindow, "QoL by portra", new GUILayoutOption[0]);
        }
        public void UIDWindow(int id)
        {
            if (id == 2)
            {
                buttonSize = new[]
                {
                    GUILayout.Width(40),
                    GUILayout.Height(20)
                };
                buttonSize2 = new[]
                {
                    GUILayout.Width(60),
                    GUILayout.Height(20)
                };
                enableTxt = GUILayout.Toggle(enableTxt, "Fast Text Speed", new GUILayoutOption[0]);
                enableCutscene = GUILayout.Toggle(enableCutscene, "Fast Cutscene Speed", new GUILayoutOption[0]);
                hideMinimap = GUILayout.Toggle(hideMinimap, "Hide Minimap", new GUILayoutOption[0]);
                enableCam = GUILayout.Toggle(enableCam, "Custom Camera Distance", new GUILayoutOption[0]);
                disableLoadingScreen = GUILayout.Toggle(disableLoadingScreen, "Disable Loading Screens", new GUILayoutOption[0]);

                GUILayout.Space(20);

                GUILayout.Label("Settings", new GUILayoutOption[0]);

                GUILayout.Space(10);

                GUILayout.Label($"Camera Distance: {distanceFromTarget:F1}", new GUILayoutOption[0]);
                distanceFromTarget = GUILayout.HorizontalSlider(distanceFromTarget, -5f, 100f, new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", buttonSize2))
                    distanceFromTarget = 20f;
                if (GUILayout.Button("-", buttonSize))
                    distanceFromTarget -= 0.1f;
                if (GUILayout.Button("+", buttonSize))
                    distanceFromTarget += 0.1f;
                GUILayout.EndHorizontal();
                GUILayout.Label($"Field of View: {newcamFOV:F0}", new GUILayoutOption[0]);
                newcamFOV = GUILayout.HorizontalSlider(newcamFOV, 1f, 160f, new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", buttonSize2))
                    newcamFOV = 45f;
                if (GUILayout.Button("-", buttonSize))
                    newcamFOV -= 1f;
                if (GUILayout.Button("+", buttonSize))
                    newcamFOV += 1f;
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", buttonSize2))
                    xOffset = 0f;
                if (GUILayout.Button("-", buttonSize))
                    xOffset -= 0.1f;
                if (GUILayout.Button("+", buttonSize))
                    xOffset += 0.1f;
                GUILayout.Label($"X Offset: {xOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", buttonSize2))
                    yOffset = 1.5f;
                if (GUILayout.Button("-", buttonSize))
                    yOffset -= 0.1f;
                if (GUILayout.Button("+", buttonSize))
                    yOffset += 0.1f;
                GUILayout.Label($"Y Offset: {yOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", buttonSize2))
                    zOffset = 0f;
                if (GUILayout.Button("-", buttonSize))
                    zOffset -= 0.1f;
                if (GUILayout.Button("+", buttonSize))
                    zOffset += 0.1f;
                GUILayout.Label($"Z Offset: {zOffset:F1}", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();

                GUILayout.Space(10);

                GUILayout.Label("UID", new GUILayoutOption[0]);
                UIDText = GUILayout.TextField(UIDText, new GUILayoutOption[0]);

                GUILayout.Space(10);

                GUILayout.Label($"FPS Limit: {targetFPS}", new GUILayoutOption[0]);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                if (GUILayout.Button("Apply", new GUILayoutOption[0]))
                    SetFPS();
                if (GUILayout.Button("-", new GUILayoutOption[0]))
                    targetFPS -= 10;
                if (GUILayout.Button("+", new GUILayoutOption[0]))
                    targetFPS += 10;
                GUILayout.EndHorizontal();
            }
            GUI.DragWindow();
        }

        private static IEnumerator FindElements()
        {
            for (; ; )
            {
                if (enableTxt && Txt == null)
                    Txt = GameObject.Find("/Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                if (enableCutscene && Cutscene == null)
                    Cutscene = GameObject.Find("/Canvas/Pages/InLevelCutScenePage");
                if (UID == null)
                    UID = GameObject.Find("/BetaWatermarkCanvas(Clone)/Panel/TxtUID");
                if (UID2 == null)
                    UID2 = GameObject.Find("/Canvas/Pages/PlayerProfilePage/GrpProfile/Right/GrpPlayerCard/UID/Layout/PlayerID");
                yield return new WaitForSeconds(1f);
            }
        }

        public void Update()
        {
            if (showMenu)
                Focused = false;

            UpdateInput();
            FindObjects();
            CamComponents();
            SetTextSpeed();
            SetCutsceneSpeed();
            SetUID();
            SetLimiters();
            if (maincamObj && newcamObj && maincam)
                SetCam();
        }

        private void FindObjects()
        {
            if (maincamObj == null)
                maincamObj = GameObject.Find("/EntityRoot/MainCamera(Clone)");
            if (AvatarRoot == null)
                AvatarRoot = GameObject.Find("/EntityRoot/AvatarRoot");
            if (TopRight == null)
                TopRight = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/GrpMainBtn/GrpMainToggle");
            if (TopLeft == null)
                TopLeft = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpButtons");
            if (Quest == null)
                Quest = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnToggleQuest");
            if (PlayerProfile == null)
                PlayerProfile = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnPlayerProfile");
            if (Latency == null)
                Latency = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/NetworkLatency");
            if (Chat == null)
                Chat = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/Chat/Content");
            if (Minimap == null)
                Minimap = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpMiniMap");

            if (AvatarRoot)
            {
                try
                {
                    if (activeAvatar == null)
                        FindActiveAvatar();
                    if (!activeAvatar.activeInHierarchy)
                        FindActiveAvatar();
                }
                catch { }
            }
        }

        private void SetCam()
        {
            if (enableCam)
            {
                if (!CamIsActive)
                    EnableCustomCam();
            }
            else
            {
                if (CamIsActive)
                    DisableCustomCam();
            }
            if (CamIsActive && maincamObj.activeInHierarchy)
                EnableCustomCam();
            if (!CamIsActive && newcamObj.activeInHierarchy)
                DisableCustomCam();
        }

        private static void CamComponents()
        {
            if (maincamObj)
            {
                if (maincam == null)
                    maincam = maincamObj.GetComponent<Camera>();

                if (newcamObj == null)
                {
                    newcamObj = Instantiate(maincamObj);
                    if (newcamObj.GetComponent<CameraController>() == null)
                        newcamObj.AddComponent<CameraController>();
                }
            }
            if (newcamObj)
            {
                if (newcam == null)
                    newcam = newcamObj.GetComponent<Camera>();
            }
        }

        private void UpdateInput()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
                ToggleHUD();
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.BackQuote))
                showMenu = !showMenu;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
                showCD = !showCD;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
                enableCam = !enableCam;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                distanceFromTarget--;
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                distanceFromTarget++;
        }

        private static void SetLimiters()
        {
            if (distanceFromTarget < -5f)
                distanceFromTarget = -5f;
            if (distanceFromTarget > 100f)
                distanceFromTarget = 100f;
            if (newcamFOV < 1f)
                newcamFOV = 1f;
            if (newcamFOV > 160f)
                newcamFOV = 160f;
        }

        private static void SetTextSpeed()
        {
            if (enableTxt && Txt && Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
        }

        private static void SetCutsceneSpeed()
        {
            if (!enableCutscene || !Cutscene) return;
            Time.timeScale = Cutscene.activeInHierarchy ? 5f : 1f;
        }

        private static void SetUID()
        {
            if (UID && UID.GetComponent<Text>().text != UIDText)
                UID.GetComponent<Text>().text = UIDText;
            if (UID2 && UID2.GetComponent<Text>().m_Text != UIDText)
                UID2.GetComponent<Text>().m_Text = UIDText;
        }

        public void ToggleHUD()
        {
            switch (isVisible)
            {
                case true:
                    if (TopRight)
                        TopRight.transform.localScale = new Vector3(0, 0, 0);
                    if (TopLeft)
                        TopLeft.transform.localScale = new Vector3(0, 0, 0);
                    if (Quest)
                        Quest.transform.localScale = new Vector3(0, 0, 0);
                    if (PlayerProfile)
                        PlayerProfile.transform.localScale = new Vector3(0, 0, 0);
                    if (Latency)
                        Latency.transform.localScale = new Vector3(0, 0, 0);
                    if (Chat)
                        Chat.transform.localScale = new Vector3(0, 0, 0);
                    if (UID)
                        UID.transform.localScale = new Vector3(0, 0, 0);
                    if (Minimap)
                        Minimap.transform.localScale = hideMinimap ? new Vector3(0, 0, 0) : new Vector3(uiScale, uiScale, uiScale);
                    isVisible = false;
                    break;
                default:
                    if (TopRight)
                        TopRight.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (TopLeft)
                        TopLeft.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (Quest)
                        Quest.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (PlayerProfile)
                        PlayerProfile.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (Latency)
                        Latency.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (Chat)
                        Chat.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (UID)
                        UID.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    if (Minimap)
                        Minimap.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                    isVisible = true;
                    break;
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

        private static void SetFPS()
        {
            Application.targetFrameRate = targetFPS;
        }

        public void FindActiveAvatar()
        {
            foreach (var a in AvatarRoot.transform)
            {
                var active = a.Cast<Transform>();
                if (!active.gameObject.activeInHierarchy) continue;
                newcamTarget = active;
                activeAvatar = active.gameObject;
            }
        }

        public void EnableCustomCam()
        {
            if (!maincamObj || !newcamObj || !maincam) return;
            
            newcamObj.SetActive(true);
            maincamObj.SetActive(false);
            CamIsActive = true;
        }
        public void DisableCustomCam()
        {
            if (!maincamObj || !newcamObj) return;
            
            newcamObj.SetActive(false);
            maincamObj.SetActive(true);
            CamIsActive = false;
        }
    }
}
