using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class CameraController
    {
        private CameraView _cameraView;

        public CameraController(CameraView cameraView) => _cameraView = cameraView;
        public void LateUpdate() => 
             _cameraView._transform.position = new Vector3( _cameraView._playerView._transform.position.x, _cameraView._transform.position.y, -10 );
        
    }
}