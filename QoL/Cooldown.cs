using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using MoleMole;
using static QoL.Main;

namespace QoL
{
    public class Cooldown : MonoBehaviour
    {
        public Cooldown(IntPtr ptr) : base(ptr)
        {
        }

        public Cooldown() : base(ClassInjector.DerivedConstructorPointer<Cooldown>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        #region Properties

        public static GameObject Char1;
        public static GameObject Char2;
        public static GameObject Char3;
        public static GameObject Char4;

        public static Text Char1Name;
        public static Text Char2Name;
        public static Text Char3Name;
        public static Text Char4Name;

        public static GameObject Char1NameObj;
        public static GameObject Char2NameObj;
        public static GameObject Char3NameObj;
        public static GameObject Char4NameObj;

        public static GameObject Char1Select;
        public static GameObject Char2Select;
        public static GameObject Char3Select;
        public static GameObject Char4Select;
        public static MonoBattleBtn IsReady;
        public static MonoBattleBtn BisReady;

        public static GameObject IsReadyObj;
        public static GameObject BisReadyPC;
        public static GameObject BisReadyCon;

        public static float Char1Timer;
        public static float Char2Timer;
        public static float Char3Timer;
        public static float Char4Timer;

        public static float Char1Btimer;
        public static float Char2Btimer;
        public static float Char3Btimer;
        public static float Char4Btimer;

        public static GameObject Char1Bstate;
        public static GameObject Char2Bstate;
        public static GameObject Char3Bstate;
        public static GameObject Char4Bstate;

        public static string Char1Bisready = "X";
        public static string Char2Bisready = "X";
        public static string Char3Bisready = "X";
        public static string Char4Bisready = "X";

        public static int WinW = 240;
        public static int WinH = 100;
        public Rect windowRect = new Rect(20, (Screen.height - WinH) / 2, WinW, WinH);

        #endregion

        public void OnGUI()
        {
            if (ShowCd)
                windowRect = GUI.Window(1, windowRect, (GUI.WindowFunction) CdWindow, "Cooldown");
        }

        public void CdWindow(int id)
        {
            if (id == 1)
            {
                var style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter,
                    normal =
                    {
                        textColor = Color.white
                    }
                };

                var style2 = new GUIStyle
                {
                    alignment = TextAnchor.MiddleLeft,
                    normal =
                    {
                        textColor = Color.white
                    }
                };

                var style3 = new GUIStyle
                {
                    alignment = TextAnchor.MiddleRight,
                    normal =
                    {
                        textColor = Color.white
                    }
                };

                if (Char1Name)
                {
                    GUI.Label(new Rect(10, 10, 150, 30), $"{Char1Name.m_Text}", style2);
                    GUI.Label(new Rect(80, 10, 150, 30), $"{Char1Timer:F1}", style);
                    GUI.Label(new Rect(80, 10, 150, 30), $"{Char1Btimer:F1} {Char1Bisready}", style3);
                }

                if (Char2Name)
                {
                    GUI.Label(new Rect(10, 30, 150, 30), $"{Char2Name.m_Text}", style2);
                    GUI.Label(new Rect(80, 30, 150, 30), $"{Char2Timer:F1}", style);
                    GUI.Label(new Rect(80, 30, 150, 30), $"{Char2Btimer:F1} {Char2Bisready}", style3);
                }

                if (Char3Name)
                {
                    GUI.Label(new Rect(10, 50, 150, 30), $"{Char3Name.m_Text}", style2);
                    GUI.Label(new Rect(80, 50, 150, 30), $"{Char3Timer:F1}", style);
                    GUI.Label(new Rect(80, 50, 150, 30), $"{Char3Btimer:F1} {Char3Bisready}", style3);
                }

                if (Char4Name)
                {
                    GUI.Label(new Rect(10, 70, 150, 30), $"{Char4Name.m_Text}", style2);
                    GUI.Label(new Rect(80, 70, 150, 30), $"{Char4Timer:F1}", style);
                    GUI.Label(new Rect(80, 70, 150, 30), $"{Char4Btimer:F1} {Char4Bisready}", style3);
                }
            }

            GUI.DragWindow();
        }

        public void Update()
        {
            FindCharacters();
            FindCharacterNames();
            FindSkillIndicator();
            FindBurstIndicator();
            SetSkillTimer();
            SetBurstTimer();
            SetBurstIndicator();
        }

        #region Set

        private static void SetSkillTimer()
        {
            if (IsReady && IsReady.GPGMMHJKEJM == 0)
            {
                if (Char1Select && Char1Select.activeInHierarchy)
                    Char1Timer = IsReady.FODDLLMGGNB;
                if (Char2Select && Char2Select.activeInHierarchy)
                    Char2Timer = IsReady.FODDLLMGGNB;
                if (Char3Select && Char3Select.activeInHierarchy)
                    Char3Timer = IsReady.FODDLLMGGNB;
                if (Char4Select && Char4Select.activeInHierarchy)
                    Char4Timer = IsReady.FODDLLMGGNB;
            }

            if (Char1Timer > 0)
                Char1Timer -= Time.deltaTime;
            if (Char1Timer < 0)
                Char1Timer = 0.00f;

            if (Char2Timer > 0)
                Char2Timer -= Time.deltaTime;
            if (Char2Timer < 0)
                Char2Timer = 0.00f;

            if (Char3Timer > 0)
                Char3Timer -= Time.deltaTime;
            if (Char3Timer < 0)
                Char3Timer = 0.00f;

            if (Char4Timer > 0)
                Char4Timer -= Time.deltaTime;
            if (Char4Timer < 0)
                Char4Timer = 0.00f;
        }

        private static void SetBurstIndicator()
        {
            if (Char1Bstate)
                Char1Bisready = Char1Bstate.activeInHierarchy ? "O" : "X";
            if (Char2Bstate)
                Char2Bisready = Char2Bstate.activeInHierarchy ? "O" : "X";
            if (Char3Bstate)
                Char3Bisready = Char3Bstate.activeInHierarchy ? "O" : "X";
            if (Char4Bstate)
                Char4Bisready = Char4Bstate.activeInHierarchy ? "O" : "X";
        }

        private static void SetBurstTimer()
        {
            if (BisReady && BisReady.GPGMMHJKEJM == 0)
            {
                if (Char1Select && Char1Select.activeInHierarchy)
                    Char1Btimer = BisReady.FODDLLMGGNB;
                if (Char2Select && Char2Select.activeInHierarchy)
                    Char2Btimer = BisReady.FODDLLMGGNB;
                if (Char3Select && Char3Select.activeInHierarchy)
                    Char3Btimer = BisReady.FODDLLMGGNB;
                if (Char4Select && Char4Select.activeInHierarchy)
                    Char4Btimer = BisReady.FODDLLMGGNB;
            }

            if (Char1Btimer > 0)
                Char1Btimer -= Time.deltaTime;
            if (Char1Btimer < 0)
                Char1Btimer = 0.00f;

            if (Char2Btimer > 0)
                Char2Btimer -= Time.deltaTime;
            if (Char2Btimer < 0)
                Char2Btimer = 0.00f;

            if (Char3Btimer > 0)
                Char3Btimer -= Time.deltaTime;
            if (Char3Btimer < 0)
                Char3Btimer = 0.00f;

            if (Char4Btimer > 0)
                Char4Btimer -= Time.deltaTime;
            if (Char4Btimer < 0)
                Char4Btimer = 0.00f;
        }

        #endregion

        #region Find

        private static void FindSkillIndicator()
        {
            if (IsReadyObj == null)
                IsReadyObj =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)");

            if (IsReady == null && IsReadyObj)
            {
                IsReady = GameObject
                    .Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)")
                    .GetComponent<MonoBattleBtn>();
            }
        }

        private static void FindBurstIndicator()
        {
            if (Char1Bstate == null && Char1)
                Char1Bstate = FindObject(Char1, "EC_Btn");
            if (Char2Bstate == null && Char2)
                Char2Bstate = FindObject(Char2, "EC_Btn");
            if (Char3Bstate == null && Char3)
                Char3Bstate = FindObject(Char3, "EC_Btn");
            if (Char4Bstate == null && Char4)
                Char4Bstate = FindObject(Char4, "EC_Btn");

            if (BisReadyPC == null)
                BisReadyPC =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/Skill5Grp/Slot5/ActionBtn_Skill5_PC(Clone)");
            if (BisReadyCon == null)
                BisReadyCon =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill5Grp/Slot5/ActionBtn_Skill5(Clone)");

            if (BisReady == null)
            {
                if (BisReadyPC)
                    BisReady = BisReadyPC.GetComponent<MonoBattleBtn>();
                else if (BisReadyCon)
                    BisReady = BisReadyCon.GetComponent<MonoBattleBtn>();
            }
        }

        private static void FindCharacters()
        {
            if (Char1 == null)
                Char1 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/0");
            if (Char2 == null)
                Char2 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/1");
            if (Char3 == null)
                Char3 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/2");
            if (Char4 == null)
                Char4 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/3");

            if (Char1Select == null && Char1)
                Char1Select = FindObject(Char1, "Eff_UI_Pressed");
            if (Char2Select == null && Char2)
                Char2Select = FindObject(Char2, "Eff_UI_Pressed");
            if (Char3Select == null && Char3)
                Char3Select = FindObject(Char3, "Eff_UI_Pressed");
            if (Char4Select == null && Char4)
                Char4Select = FindObject(Char4, "Eff_UI_Pressed");
        }

        private static void FindCharacterNames()
        {
            if (Char1NameObj == null)
                Char1NameObj =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/0/TeamBtn/NameText");
            if (Char2NameObj == null)
                Char2NameObj =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/1/TeamBtn/NameText");
            if (Char3NameObj == null)
                Char3NameObj =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/2/TeamBtn/NameText");
            if (Char4NameObj == null)
                Char4NameObj =
                    GameObject.Find(
                        "/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/3/TeamBtn/NameText");

            if (Char1Name == null && Char1NameObj)
                Char1Name = GameObject
                    .Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/0/TeamBtn/NameText")
                    .GetComponent<Text>();
            if (Char2Name == null && Char2NameObj)
                Char2Name = GameObject
                    .Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/1/TeamBtn/NameText")
                    .GetComponent<Text>();
            if (Char3Name == null && Char3NameObj)
                Char3Name = GameObject
                    .Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/2/TeamBtn/NameText")
                    .GetComponent<Text>();
            if (Char4Name == null && Char4NameObj)
                Char4Name = GameObject
                    .Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/3/TeamBtn/NameText")
                    .GetComponent<Text>();
        }

        #endregion
    }
}