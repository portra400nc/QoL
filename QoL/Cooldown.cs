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

        public static float modHeight = 100f;

        public static float char1timer = 0;
        public static float char2timer = 0;
        public static float char3timer = 0;
        public static float char4timer = 0;

        //public Rect windowRect = new Rect(20, 200, 160, 140);
        public Rect windowRect = new Rect(20, 200, 160, modHeight);


        public void OnGUI()
        {
            windowRect = GUI.Window(1, windowRect, (GUI.WindowFunction)CDWindow, "Skill Cooldown");
        }
        public void CDWindow(int id)
        {
            if (id == 1)
            {
                GUIStyle style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleRight
                };
                style.normal.textColor = Color.white;

                GUIStyle style2 = new GUIStyle
                {
                    alignment = TextAnchor.MiddleLeft
                };
                style2.normal.textColor = Color.white;
                //GUI.Label(new Rect(20, 40, 150, 30), "Character 1    " + char1timer.ToString("F1"));
                //GUI.Label(new Rect(20, 40, 150, 30), $"{char1name.m_Text}    {char1timer.ToString("F1")}");
                GUI.Label(new Rect(10, 10, 150, 30), $"{char1name.m_Text}", style2);
                GUI.Label(new Rect(0, 10, 150, 30), $"{char1timer.ToString("F1")}", style);

                GUI.Label(new Rect(10, 30, 150, 30), $"{char2name.m_Text}", style2);
                GUI.Label(new Rect(0, 30, 150, 30), $"{char2timer.ToString("F1")}", style);

                GUI.Label(new Rect(10, 50, 150, 30), $"{char3name.m_Text}", style2);
                GUI.Label(new Rect(0, 50, 150, 30), $"{char3timer.ToString("F1")}", style);

                GUI.Label(new Rect(10, 70, 150, 30), $"{char4name.m_Text}", style2);
                GUI.Label(new Rect(0, 70, 150, 30), $"{char4timer.ToString("F1")}", style);
            }
            GUI.DragWindow();
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                modHeight -= 5;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                modHeight += 5;
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

            if (isReady == null)
            {
                isReady = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)").GetComponent<MonoBattleBtn>();
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
