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
    public class Toggle : MonoBehaviour
    {
        public Toggle(IntPtr ptr) : base(ptr) { }
        public Toggle() : base(ClassInjector.DerivedConstructorPointer<Toggle>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        public void Start()
        {
            MelonCoroutines.Start(Main.FindObjects());
        }
        public void Update()
        {
            if (name.Contains("TxtDesc"))
            {
                if (GetComponent<MonoTypewriter>()._secondPerChar != 0.00001f)
                    GetComponent<MonoTypewriter>()._secondPerChar = 0.00001f;
            }
            if (name.Contains("PlayerID"))
            {
                if (GetComponent<Text>().m_Text != "I HECKING LOOOOVE GENSHIN")
                    GetComponent<Text>().m_Text = "I HECKING LOOOOVE GENSHIN";
            }
            if (name.Contains("TxtUID"))
            {
                if (GetComponent<Text>().text != "I HECKING LOOOOVE GENSHIN")
                    GetComponent<Text>().text = "I HECKING LOOOOVE GENSHIN";
            }
            if (name.Contains("Pages"))
            {
                foreach (var childTransform in transform)
                {
                    Transform child = childTransform.Cast<Transform>();
                    if (child == null)
                    {
                        continue;
                    }
                    if (child.name.Contains("InLevelCutScenePage"))
                    {
                        if (child.gameObject.activeInHierarchy)
                            Time.timeScale = 5f;
                        else
                            Time.timeScale = 1f;
                    }
                }
            }
        }
    }
}
