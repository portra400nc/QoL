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
    public class Loader : MelonMod
    {
        public static GameObject isRunning;
        public static bool showCD = true;
        public static bool showMenu = false;

        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Cooldown>();
            ClassInjector.RegisterTypeInIl2Cpp<Main>();
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                if (isRunning == null)
                {
                    isRunning = new GameObject();
                    isRunning.AddComponent<Cooldown>();
                    isRunning.AddComponent<Main>();
                }
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
                showCD = !showCD;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.BackQuote))
                showMenu = !showMenu;
        }
    }
}
