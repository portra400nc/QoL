using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using MoleMole;

namespace QoL
{
    public class Cooldown : MonoBehaviour
    {
        public Cooldown(IntPtr ptr) : base(ptr) { }
        public Cooldown() : base(ClassInjector.DerivedConstructorPointer<Cooldown>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        public static GameObject char1;
        public static GameObject char2;
        public static GameObject char3;
        public static GameObject char4;

        public static Text char1name;
        public static Text char2name;
        public static Text char3name;
        public static Text char4name;

        public static GameObject char1select;
        public static GameObject char2select;
        public static GameObject char3select;
        public static GameObject char4select;
        public static MonoBattleBtn isReady;
        public static MonoBattleBtn bisReady;

        public static float modHeight = 100f;

        public static float char1timer = 0;
        public static float char2timer = 0;
        public static float char3timer = 0;
        public static float char4timer = 0;

        public static float char1btimer = 0;
        public static float char2btimer = 0;
        public static float char3btimer = 0;
        public static float char4btimer = 0;

        public static GameObject char1bstate;
        public static GameObject char2bstate;
        public static GameObject char3bstate;
        public static GameObject char4bstate;

        public static GameObject charbKeyboard;
        public static GameObject charbController;

        public static string char1bisready = "X";
        public static string char2bisready = "X";
        public static string char3bisready = "X";
        public static string char4bisready = "X";

        public static float xAlign = 0f;

        //public Rect windowRect = new Rect(20, 200, 160, 100);
        public Rect windowRect = new Rect(20, 200, 240, 100);



        public void OnGUI()
        {
            windowRect = GUI.Window(1, windowRect, (GUI.WindowFunction)CDWindow, "Cooldown");
        }
        public void CDWindow(int id)
        {
            if (id == 1)
            {
                GUIStyle style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter
                };
                style.normal.textColor = Color.white;

                GUIStyle style2 = new GUIStyle
                {
                    alignment = TextAnchor.MiddleLeft
                };
                style2.normal.textColor = Color.white;

                GUIStyle style3 = new GUIStyle
                {
                    alignment = TextAnchor.MiddleRight
                };
                style3.normal.textColor = Color.white;
                //GUI.Label(new Rect(20, 40, 150, 30), "Character 1    " + char1timer.ToString("F1"));
                //GUI.Label(new Rect(20, 40, 150, 30), $"{char1name.m_Text}    {char1timer.ToString("F1")}");
                if (char1name)
                {
                    GUI.Label(new Rect(10, 10, 150, 30), $"{char1name.m_Text}", style2);
                    GUI.Label(new Rect(80, 10, 150, 30), $"{char1timer.ToString("F1")}", style);
                    GUI.Label(new Rect(80, 10, 150, 30), $"{char1btimer.ToString("F1")} {char1bisready}", style3);
                }

                if (char2name)
                {
                    GUI.Label(new Rect(10, 30, 150, 30), $"{char2name.m_Text}", style2);
                    GUI.Label(new Rect(80, 30, 150, 30), $"{char2timer.ToString("F1")}", style);
                    GUI.Label(new Rect(80, 30, 150, 30), $"{char2btimer.ToString("F1")} {char2bisready}", style3);
                }

                if (char3name)
                {
                    GUI.Label(new Rect(10, 50, 150, 30), $"{char3name.m_Text}", style2);
                    GUI.Label(new Rect(80, 50, 150, 30), $"{char3timer.ToString("F1")}", style);
                    GUI.Label(new Rect(80, 50, 150, 30), $"{char3btimer.ToString("F1")} {char3bisready}", style3);

                }

                if (char4name)
                {
                    GUI.Label(new Rect(10, 70, 150, 30), $"{char4name.m_Text}", style2);
                    GUI.Label(new Rect(80, 70, 150, 30), $"{char4timer.ToString("F1")}", style);
                    GUI.Label(new Rect(80, 70, 150, 30), $"{char4btimer.ToString("F1")} {char4bisready}", style3);
                }

            }
            GUI.DragWindow();
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                xAlign -= 5;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                xAlign += 5;
            if (isReady)
            {
                if (isReady.GPGMMHJKEJM == 0)
                {
                    if (char1select.activeInHierarchy)
                    {
                        char1timer = isReady.FODDLLMGGNB;
                    }
                    if (char2select.activeInHierarchy)
                    {
                        char2timer = isReady.FODDLLMGGNB;
                    }
                    if (char3select.activeInHierarchy)
                    {
                        char3timer = isReady.FODDLLMGGNB;
                    }
                    if (char4select.activeInHierarchy)
                    {
                        char4timer = isReady.FODDLLMGGNB;
                    }
                }
            }
            if (bisReady)
            {
                if (bisReady.GPGMMHJKEJM == 0)
                {
                    if (char1select.activeInHierarchy)
                    {
                        char1btimer = bisReady.FODDLLMGGNB;
                    }
                    if (char2select.activeInHierarchy)
                    {
                        char2btimer = bisReady.FODDLLMGGNB;
                    }
                    if (char3select.activeInHierarchy)
                    {
                        char3btimer = bisReady.FODDLLMGGNB;
                    }
                    if (char4select.activeInHierarchy)
                    {
                        char4btimer = bisReady.FODDLLMGGNB;
                    }
                }
            }

            // Skill timer
            if (char1timer > 0)
                char1timer -= Time.deltaTime;
            if (char1timer < 0)
                char1timer = 0.00f;

            if (char2timer > 0)
                char2timer -= Time.deltaTime;
            if (char2timer < 0)
                char2timer = 0.00f;

            if (char3timer > 0)
                char3timer -= Time.deltaTime;
            if (char3timer < 0)
                char3timer = 0.00f;

            if (char4timer > 0)
                char4timer -= Time.deltaTime;
            if (char4timer < 0)
                char4timer = 0.00f;

            //Burst timer
            if (char1btimer > 0)
                char1btimer -= Time.deltaTime;
            if (char1btimer < 0)
                char1btimer = 0.00f;

            if (char2btimer > 0)
                char2btimer -= Time.deltaTime;
            if (char2btimer < 0)
                char2btimer = 0.00f;

            if (char3btimer > 0)
                char3btimer -= Time.deltaTime;
            if (char3btimer < 0)
                char3btimer = 0.00f;

            if (char4btimer > 0)
                char4btimer -= Time.deltaTime;
            if (char4btimer < 0)
                char4btimer = 0.00f;

            if (char1bstate)
            {
                if (char1bstate.activeInHierarchy)
                    char1bisready = "O";
                else
                    char1bisready = "X";
            }
            if (char2bstate)
            {
                if (char2bstate.activeInHierarchy)
                    char2bisready = "O";
                else
                    char2bisready = "X";
            }
            if (char3bstate)
            {
                if (char3bstate.activeInHierarchy)
                    char3bisready = "O";
                else
                    char3bisready = "X";
            }
            if (char4bstate)
            {
                if (char4bstate.activeInHierarchy)
                    char4bisready = "O";
                else
                    char4bisready = "X";
            }

            // Find Objects
            if (char1 == null)
                char1 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/0");
            if (char2 == null)
                char2 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/1");
            if (char3 == null)
                char3 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/2");
            if (char4 == null)
                char4 = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/3");

            if (char1select == null)
            {
                if (char1)
                    char1select = Starter.FindObject(char1, "Eff_UI_Pressed");
            }
            if (char2select == null)
            {
                if (char2)
                    char2select = Starter.FindObject(char2, "Eff_UI_Pressed");
            }
            if (char3select == null)
            {
                if (char3)
                    char3select = Starter.FindObject(char3, "Eff_UI_Pressed");
            }
            if (char4select == null)
            {
                if (char4)
                    char4select = Starter.FindObject(char4, "Eff_UI_Pressed");
            }

            if (char1bstate == null)
            {
                if (char1)
                    char1bstate = Starter.FindObject(char1, "EC_Btn");
            }
            if (char2bstate == null)
            {
                if (char2)
                    char2bstate = Starter.FindObject(char2, "EC_Btn");
            }
            if (char3bstate == null)
            {
                if (char3)
                    char3bstate = Starter.FindObject(char3, "EC_Btn");
            }
            if (char4bstate == null)
            {
                if (char4)
                    char4bstate = Starter.FindObject(char4, "EC_Btn");
            }

            if (isReady == null)
            {
                isReady = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)").GetComponent<MonoBattleBtn>();
            }

            //if (charbKeyboard == null)
            //    charbKeyboard = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/Skill5Grp/Slot5/ActionBtn_Skill5_PC(Clone)");

            //if (charbController == null)
            //    charbController = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill5Grp/Slot5/ActionBtn_Skill5(Clone)");

            if (bisReady == null)
            {
                if (GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/Skill5Grp/Slot5/ActionBtn_Skill5_PC(Clone)"))
                    bisReady = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/Skill5Grp/Slot5/ActionBtn_Skill5_PC(Clone)").GetComponent<MonoBattleBtn>();
                else if (GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill5Grp/Slot5/ActionBtn_Skill5(Clone)"))
                    bisReady = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill5Grp/Slot5/ActionBtn_Skill5(Clone)").GetComponent<MonoBattleBtn>();
            }

            if (char1name == null)
                char1name = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/0/TeamBtn/NameText").GetComponent<Text>();
            if (char2name == null)
                char2name = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/1/TeamBtn/NameText").GetComponent<Text>();
            if (char3name == null)
                char3name = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/2/TeamBtn/NameText").GetComponent<Text>();
            if (char4name == null)
                char4name = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/TeamBtnContainer/Content/3/TeamBtn/NameText").GetComponent<Text>();

            //if (cdText == null)
            //{
            //    cdText = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)/CD").GetComponent<SimpleText>();
            //}


            //// debug
            //if (char1)
            //    Debug.Log($"char1: {char1.name}");
            //if (char2)
            //    Debug.Log($"char1: {char2.name}");
            //if (char3)
            //    Debug.Log($"char1: {char3.name}");
            //if (char4)
            //    Debug.Log($"char1: {char4.name}");

            //if (cdText)
            //    Debug.Log($"cdText: {cdText.transform.name}");

            //if (char1select)
            //    Debug.Log($"char1: {char1select.name}");
            //if (char2select)
            //    Debug.Log($"char1: {char2select.name}");
            //if (char3select)
            //    Debug.Log($"char1: {char3select.name}");
            //if (char4select)
            //    Debug.Log($"char1: {char4select.name}");
        }
    }
}
