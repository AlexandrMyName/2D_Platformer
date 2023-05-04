using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        [Inject(Id = "LoseId")]
        private LoseController _loseController;

        [Inject]
        private WinController _winController;


       
        private void Update(){

           _playerController?.Update();
            _cannonController?.Update();
          
        }
        private void LateUpdate()
        {
            _cameraController.LateUpdate();
        }


        public void ReloadLevel(int level)
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }
        public void ToNextLevel(int level)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }
}
