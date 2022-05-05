using System;
using UnhollowerRuntimeLib;
using UnityEngine;

using static QoL.Main;

namespace QoL
{
    public class CameraController : MonoBehaviour
    {
        public CameraController(IntPtr ptr) : base(ptr) { }
        public CameraController() : base(ClassInjector.DerivedConstructorPointer<CameraController>())
        {
            ClassInjector.DerivedConstructorBody(this);
        }

        //private Transform _target;

        public void Start()
        {
            //_target = activeAvatar.transform;
        }

        public void Update()
        {
            transform.rotation = maincam.transform.rotation;
            transform.position = _target.position + new Vector3(0, 1f, 0) - transform.forward * _distanceFromTarget;
        }
    }
}
