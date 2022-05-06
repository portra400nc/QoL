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

        public static Action<string> Msg;
        public static Action<string> Warning;
        public static Action<string> Error;
        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Cooldown>();
            ClassInjector.RegisterTypeInIl2Cpp<Main>();
            ClassInjector.RegisterTypeInIl2Cpp<CameraController>();
            Msg = LoggerInstance.Msg;
            Warning = LoggerInstance.Warning;
            Error = LoggerInstance.Error;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote) && isRunning == null)
            {
                isRunning = new GameObject();
                isRunning.AddComponent<Cooldown>();
                isRunning.AddComponent<Main>();
                GameObject.DontDestroyOnLoad(isRunning);
            }
        }
    }
}
