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
    public class Main : MelonMod
    {
        private static GameObject TopRight;
        private static GameObject TopLeft;
        private static GameObject PlayerProfile;
        private static GameObject Quest;
        private static GameObject Latency;
        private static GameObject UID;
        private static GameObject UID2;
        private static GameObject Chat;
        private static GameObject isRunning;
        private static GameObject Txt;
        private static GameObject Cutscene;
        private static float uiScale = 1;
        private static bool isVisible = true;

        public override void OnUpdate()
        {

            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                if (isRunning == null)
                {
                    isRunning = new GameObject();
                    TopRight = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/GrpMainBtn/GrpMainToggle");
                    TopLeft = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/GrpButtons");
                    Quest = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnToggleQuest");
                    PlayerProfile = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/MapInfo/BtnPlayerProfile");
                    Latency = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/NetworkLatency");
                    Chat = GameObject.Find("/Canvas/Pages/InLevelMainPage/GrpMainPage/Chat/Content");
                    UID = GameObject.Find("/BetaWatermarkCanvas(Clone)/Panel/TxtUID");
                    ToggleHUD();
                }
                else
                    ToggleHUD();

                if (Txt == null)
                    Txt = GameObject.Find("/Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                else
                    Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;

                if (Cutscene == null)
                    Cutscene = GameObject.Find("/Canvas/Pages/InLevelCutScenePage");
            }
            if (Txt)
            {
                if (Txt.GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                    Txt.GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
            }
            if (Cutscene)
            {
                if (Cutscene.activeInHierarchy)
                    Time.timeScale = 5f;
                else
                    Time.timeScale = 1f;
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                if (UID2 == null)
                    UID2 = GameObject.Find("/Canvas/Pages/PlayerProfilePage/GrpProfile/Right/GrpPlayerCard/UID/Layout/PlayerID");
                if (UID2)
                    UID2.GetComponent<Text>().m_Text = "^_^";
                if (UID)
                    UID.GetComponent<Text>().text = "^_^";
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
                UID.transform.localScale = new Vector3(uiScale, uiScale, uiScale);
                isVisible = true;
            }
        }
    }
}
