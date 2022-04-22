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
        public static GameObject Team;

        public static GameObject char1;
        public static GameObject char2;
        public static GameObject char3;
        public static GameObject char4;

        public static GameObject char1select;
        public static GameObject char2select;
        public static GameObject char3select;
        public static GameObject char4select;
        public static MonoBattleBtn isReady;

        public static float char1timer = 0;
        public static float char2timer = 0;
        public static float char3timer = 0;
        public static float char4timer = 0;

        public static SimpleText cd1;
        public static SimpleText cd2;
        public static SimpleText cd3;
        public static SimpleText cd4;
        public static SimpleText cdText;

        public Rect windowRect = new Rect(20, 200, 190, 140);

        public void OnGUI()
        {
            windowRect = GUI.Window(0, windowRect, (GUI.WindowFunction)CDWindow, "Cooldown");
        }
        public void CDWindow(int id)
        {
            if (id == 0)
            {
                GUI.Label(new Rect(20, 40, 150, 30), "Character 1 | " + char1timer.ToString("F2"));
                GUI.Label(new Rect(20, 60, 150, 30), "Character 2 | " + char2timer.ToString("F2"));
                GUI.Label(new Rect(20, 80, 150, 30), "Character 3 | " + char3timer.ToString("F2"));
                GUI.Label(new Rect(20, 100, 150, 30), "Character 4 | " + char4timer.ToString("F2"));
            }
            GUI.DragWindow();
        }
        public void Update()
        {
            //if isready = false then grab isready's float then start timer
            if (cdText != null)
            {
                if (cdText.m_Text != "0.0")
                {
                    if (cdText.m_Text != null)
                    {
                        if (isReady)
                        {
                            if (isReady.GPGMMHJKEJM == 0)
                            {
                                if (char1select.activeInHierarchy)
                                {
                                    if (char1timer == 0)
                                    {
                                        //char1timer = float.Parse(cdText.m_Text);
                                        char1timer = isReady.FODDLLMGGNB;
                                    }
                                }
                                if (char2select.activeInHierarchy)
                                {
                                    if (char2timer == 0)
                                    {
                                        char2timer = isReady.FODDLLMGGNB;
                                    }
                                }
                                if (char3select.activeInHierarchy)
                                {
                                    if (char3timer == 0)
                                    {
                                        char3timer = isReady.FODDLLMGGNB;
                                    }
                                }
                                if (char4select.activeInHierarchy)
                                {
                                    if (char4timer == 0)
                                    {
                                        char4timer = isReady.FODDLLMGGNB;
                                    }
                                }
                            }
                        }
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

            if (cdText == null)
            {
                cdText = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)/CD").GetComponent<SimpleText>();
            }
            if (isReady == null)
            {
                isReady = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/ActionPanelContainer/ActionBtnPanel/GrpSkill/Skill2Grp/Slot2/ActionBtn_Skill2(Clone)").GetComponent<MonoBattleBtn>();
            }

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
