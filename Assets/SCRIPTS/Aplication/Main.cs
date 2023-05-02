using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        
        [Inject(Id = "Player_Configs")]
        private PlayerController _playerController;

        [Inject(Id = "Player_Configs")]
        private CannonController _cannonController;

        [Inject(Id = "CameraId")]
        private CameraController _cameraController;
       


      
        private void Update(){

           _playerController?.Update();
            _cannonController?.Update();
          
        }
        private void LateUpdate()
        {
            _cameraController.LateUpdate();
        }
    }
}
