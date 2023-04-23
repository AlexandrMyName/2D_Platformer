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

        private void Awake(){

            _playerController?.Awake();
        }
        private void Update(){

           _playerController?.Update();
        }
    }
}
