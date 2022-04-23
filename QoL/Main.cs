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
    public class Main : MelonMod
    {
        private static GameObject TopRight;
        private static GameObject TopLeft;
        private static GameObject PlayerProfile;
        private static GameObject Quest;
        private static GameObject Latency;
        private static GameObject Chat;
        public static GameObject isRunning;

        public static GameObject mainCanvas;
        public static GameObject uidCanvas;
        public static GameObject dialogCanvas;

        public static GameObject Txt;
        public static GameObject Cutscene;
        public static GameObject UID;
        public static GameObject UID2;

        private static Transform[] canvasChildren;
        private static Transform[] uidChildren;
        private static float uiScale = 1;
        private static bool isVisible = true;
        private static bool changeUID = false;

        public static bool foundTxt = false;
        /*  Plans
         *  Add character name
            Remove character switching cooldown
            Remove edit party cooldown
            DPS calculator
        */

        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Toggle>();
            ClassInjector.RegisterTypeInIl2Cpp<Cooldown>();
            ClassInjector.RegisterTypeInIl2Cpp<Starter>();

        }

        public override void OnUpdate()
        {
            if (!Input.anyKey || !Input.anyKeyDown)
                return;
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                if (isRunning == null)
                {
                    isRunning = new GameObject();
                    isRunning.AddComponent<Starter>();
                    isRunning.AddComponent<Cooldown>();
                    TopRight = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/GrpMainBtn/GrpMainToggle");
                    TopLeft = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpButtons");
                    Quest = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnToggleQuest");
                    PlayerProfile = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnPlayerProfile");
                    Latency = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/NetworkLatency");
                    Chat = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/Chat/Content");
                    //UID = GameObject.Find("/BetaWatermarkCanvas(Clone)/Panel/TxtUID");
                    uidCanvas = GameObject.Find("BetaWatermarkCanvas(Clone)");
                    mainCanvas = GameObject.Find("Canvas");
                    dialogCanvas = GameObject.Find("/Canvas/Dialogs");
                    ToggleHUD();
                }
                else
                    ToggleHUD();

                //if (Txt == null)
                //    Txt = GameObject.Find("/Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                //else
                //    Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;

                //if (Cutscene == null)
                //    Cutscene = GameObject.Find("/Canvas/Pages/InLevelCutScenePage");
            }
            

            //if (Txt != null)
            //{
            //    if (Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
            //        Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
            //}
            //if (Cutscene != null)
            //{
            //    if (Cutscene.activeInHierarchy)
            //        Time.timeScale = 5f;
            //    else
            //        Time.timeScale = 1f;
            //}
            ////if (Input.GetKeyDown(KeyCode.F8))
            ////{
            ////    if (UID2 == null)
            ////        UID2 = GameObject.Find("/Canvas/Pages/PlayerProfilePage/GrpProfile/Right/GrpPlayerCard/UID/Layout/PlayerID");
            ////    if (UID)
            ////        UID.GetComponent<Text>().text = "I HECKING LOOOOVE GENSHIN";
            ////}
            //if (UID2 != null)
            //{
            //    if (UID2.GetComponent<Text>().m_Text != "I HECKING LOOOOVE GENSHIN")
            //        UID2.GetComponent<Text>().m_Text = "I HECKING LOOOOVE GENSHIN";
            //}
            //if (UID != null)
            //{
            //    if (UID.GetComponent<Text>().text != "I HECKING LOOOOVE GENSHIN")
            //        UID.GetComponent<Text>().text = "I HECKING LOOOOVE GENSHIN";
            //}
        }
        public static IEnumerator FindObjects()
        {
            for (; ; )
            {
                canvasChildren = mainCanvas.GetComponentsInChildren<Transform>(true);
                uidChildren = uidCanvas.GetComponentsInChildren<Transform>(true);

                if (mainCanvas != null)
                {
                    if (canvasChildren != null)
                    {
                        foreach (var child in canvasChildren)
                        {
                            if (child == null)
                            {
                                continue;
                            }
                            if (child.gameObject.GetComponent<Toggle>() != null)
                            {
                                continue;
                            }

                            if (child.name == "TxtDesc")
                            {
                                //if (child.gameObject.GetComponent<Toggle>() == null)
                                child.gameObject.AddComponent<Toggle>();
                            }
                            if (child.name == "PlayerID")
                            {
                                child.gameObject.AddComponent<Toggle>();
                            }
                            if (child.name == "Pages")
                            {
                                child.gameObject.AddComponent<Toggle>();
                            }
                        }
                    }
                }
                if (uidCanvas != null)
                {
                    if (uidChildren != null)
                    {
                        foreach (var child in uidChildren)
                        {
                            if (child == null)
                            {
                                continue;
                            }
                            if (child.gameObject.GetComponent<Toggle>() != null)
                            {
                                continue;
                            }
                            if (child.name == "TxtUID")
                            {
                                child.gameObject.AddComponent<Toggle>();
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(10f);

            }
        }
        public void ToggleHUD()
        {
            if (isVisible == true)
            {
                TopRight.transform.localScale = new Vector3(0, 0, 0);
                TopLeft.transform.localScale = new Vector3(0, 0, 0);
                Quest.transform.localScale = new Vector3(0, 0, 0);
                PlayerProfile.transform.localScale = new Vector3(0, 0, 0);
                Latency.transform.localScale = new Vector3(0, 0, 0);
                Chat.transform.localScale = new Vector3(0, 0, 0);
                if (UID)
                    UID.transform.localScale = new Vector3(0, 0, 0);
                isVisible = false;
            }
            else
            {
                TopRight.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                TopLeft.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                Quest.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                PlayerProfile.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                Latency.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                Chat.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                if (UID)
                    UID.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                isVisible = true;
            }
        }
        
    }
}
