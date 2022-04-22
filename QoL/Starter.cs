using System;
using System.Collections.Generic;
using System.Collections;
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
    public class Starter : MonoBehaviour
    {
        public Starter(IntPtr ptr) : base(ptr) { }
        public Starter() : base(ClassInjector.DerivedConstructorPointer<Starter>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        public bool enableTxt = false;
        public bool enableCutscene = false;
        public bool enableUID2 = false;

        public void Update()
        {
            // Set Objects
            if (enableTxt == true)
            {
                if (Main.Txt)
                {
                    if (Main.Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                        Main.Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
                }
            }
            if (enableCutscene == true)
            {
                if (Main.Cutscene)
                {
                    if (Main.Cutscene.activeInHierarchy)
                    {
                        if (Time.timeScale != 5f)
                            Time.timeScale = 5f;
                    }
                    else
                    {
                        if (Time.timeScale != 1f)
                            Time.timeScale = 1f;
                    }
                }
            }
            if (enableUID2 == true)
            {
                if (Main.UID2)
                {
                    if (Main.UID2.GetComponent<Text>().m_Text != "PotFriend")
                        Main.UID2.GetComponent<Text>().m_Text = "PotFriend";
                }
            }
            
            if (Main.UID)
            {
                if (Main.UID.GetComponent<Text>().text != "I HECKING LOOOOVE GENSHIN")
                    Main.UID.GetComponent<Text>().text = "I HECKING LOOOOVE GENSHIN";
            }
            
            // Find objects
            if (enableTxt == true)
            {
                if (Main.Txt == null)
                {
                    if (Main.dialogCanvas != null)
                    {
                        Main.Txt = FindObject(Main.dialogCanvas, "TxtDesc");
                    }
                }
            }
            if (enableCutscene == true)
            {
                if (Main.Cutscene == null)
                {
                    if (Main.mainCanvas != null)
                    {
                        Main.Cutscene = FindObject(Main.mainCanvas, "InLevelCutScenePage");
                    }
                }
            }
            
            if (Main.UID == null)
            {
                if (Main.uidCanvas != null)
                {
                    Main.UID = FindObject(Main.uidCanvas, "TxtUID");
                }
            }
            if (enableUID2 == true)
            {
                if (Main.UID2 == null)
                {
                    if (Main.mainCanvas != null)
                    {
                        Main.UID2 = FindObject(Main.mainCanvas, "PlayerID");
                    }
                }
            }
            
            //if (Main.isRunning != null)
            //{
            //    if (Main.dialogCanvas != null)
            //    {
            //        Main.Txt = FindObject(Main.dialogCanvas, "TxtDesc");
            //    }
            //    if (Main.mainCanvas != null)
            //    {
            //        if (Main.Cutscene == null)
            //        {
            //            Main.Cutscene = FindObject(Main.mainCanvas, "InLevelCutScenePage");
            //        }

            //        if (Main.UID2 == null)
            //        {
            //            Main.UID2 = FindObject(Main.mainCanvas, "PlayerID");
            //        }
            //    }

            //    if (Main.uidCanvas != null)
            //    {
            //        if (Main.UID == null)
            //        {
            //            Main.UID = FindObject(Main.uidCanvas, "TxtUID");
            //        }
            //    }

            //}
        }
        public static GameObject FindObject(GameObject parent, string name)
        {
            GameObject candidate = null;
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trs)
            {
                if (t == null)
                {
                    continue;
                }
                if (t.name == name)
                {
                    candidate = t.gameObject;
                }
            }
            Array.Clear(trs, 0, trs.Length);
            return candidate;
        }
    }
}
