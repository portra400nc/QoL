using MoleMole;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static bool enableTxt = true;
        public static bool enableCutscene = true;

        private static GameObject TopRight;
        private static GameObject TopLeft;
        private static GameObject PlayerProfile;
        private static GameObject Quest;
        private static GameObject Latency;
        private static GameObject Chat;

        public static GameObject mainCanvas;
        public static GameObject uidCanvas;
        public static GameObject dialogCanvas;

        public static GameObject Txt;
        public static GameObject Cutscene;
        public static GameObject UID;
        public static GameObject UID2;

        public static string UIDText = "Press Ctrl + ` to edit your UID";

        private static bool isVisible = true;
        private static float uiScale = 1;
        private static float xAlign = 10;

        private static int winW = 150;
        private static int winH = 50;
        public Rect windowRect = new Rect((Screen.width - winW) / 2, (Screen.height - winH) / 2, winW, winH);


        public void Start()
        {
            MelonCoroutines.Start(FindElements());
        }

        public void OnGUI()
        {
            if (Loader.showMenu)
                windowRect = GUILayout.Window(2, windowRect, (GUI.WindowFunction)UIDWindow, "QoL by portra", new GUILayoutOption[0]);
        }
        public void UIDWindow(int id)
        {
            if (id == 2)
            {
                enableTxt = GUILayout.Toggle(enableTxt, "Fast Text Speed", new GUILayoutOption[0]);
                enableCutscene = GUILayout.Toggle(enableCutscene, "Fast Cutscene Speed", new GUILayoutOption[0]);
                UIDText = GUILayout.TextField(UIDText, new GUILayoutOption[0]);
            }
            GUI.DragWindow();
        }

        IEnumerator FindElements()
        {
            for (; ; )
            {
                // FIND
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
                if (enableTxt)
                {
                    if (Txt == null)
                        Txt = GameObject.Find("/Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                }
                if (enableCutscene)
                {
                    if (Cutscene == null)
                        Cutscene = GameObject.Find("/Canvas/Pages/InLevelCutScenePage");
                }
                if (UID == null)
                    UID = GameObject.Find("/BetaWatermarkCanvas(Clone)/Panel/TxtUID");
                if (UID2 == null)
                    UID2 = GameObject.Find("/Canvas/Pages/PlayerProfilePage/GrpProfile/Right/GrpPlayerCard/UID/Layout/PlayerID");
                yield return new WaitForSeconds(1f);
            }
        }

        public void Update()
        {
            // HOTKEY
            if (Input.GetKeyDown(KeyCode.BackQuote))
                ToggleHUD();

            if (Loader.showMenu == true)
                Focused = false;

            // SET
            if (enableTxt)
            {
                if (Txt)
                {
                    if (Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                        Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
                }
            }
            if (enableCutscene)
            {
                if (Cutscene)
                {
                    if (Cutscene.activeInHierarchy)
                        Time.timeScale = 5f;
                    else
                        Time.timeScale = 1f;
                }
            }
            if (UID)
            {
                if (UID.GetComponent<Text>().text != UIDText)
                    UID.GetComponent<Text>().text = UIDText;
            }
            if (UID2)
            {
                if (UID2.GetComponent<Text>().m_Text != UIDText)
                    UID2.GetComponent<Text>().m_Text = UIDText;
            }
        }
        public void ToggleHUD()
        {
            if (isVisible == true)
            {
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
                isVisible = false;
            }
            else
            {
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
                isVisible = true;
            }
        }
        static bool Focused
        {
            get => Cursor.lockState == CursorLockMode.Locked;
            set
            {
                Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = value == false;
            }
        }
    }
}
