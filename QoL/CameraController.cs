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
        public void Update()
        {
            if (newcam)
                newcam.fieldOfView = newcamFOV;
            if (maincam)
                transform.rotation = maincam.transform.rotation;
            if (_target)
                transform.position = _target.position + new Vector3(xOffset, yOffset, zOffset) - transform.forward * _distanceFromTarget;
        }
    }
}
