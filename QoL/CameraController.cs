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

        private Transform _mainTransform;

        private void Awake()
        {
            _mainTransform = transform;
        }

        public void Update()
        {
            if (newcam)
                newcam.fieldOfView = newcamFOV;
            if (maincam)
                _mainTransform.rotation = maincam.transform.rotation;
            if (newcamTarget)
                _mainTransform.position = newcamTarget.position + new Vector3(xOffset, yOffset, zOffset) - _mainTransform.forward * distanceFromTarget;
        }
    }
}
