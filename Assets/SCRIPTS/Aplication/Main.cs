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

        [Inject]
        private AudioController _audio;

      

        
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private ShopView _shopView;
        [SerializeField] private LevelView _levelView;

        private ShopController _shopController;
        private LevelController _levelController;

       
        private void Start(){
            _shopController = new ShopController(_shopView);
            _levelController = new LevelController(_levelView);
            _audio.PlayMusic();
            _audio.PlaySpawn();
        }

        private void Update(){
           _playerController?.Update();
            _cannonController?.Update();
          
        }
        private void LateUpdate() => _cameraController.LateUpdate();

        public void ReloadLevel(int level) {
            
            Time.timeScale = 1;
            SceneManager.LoadScene("Level_" + level.ToString()); }
        
        public void ToNextLevel(int level){
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Level_" + level.ToString());
        }

        public void ToMenu(){
            _loseController.View._panel.SetActive(false);
            _winController.View._panel.SetActive(false);
            _shopView._colorsPanel.SetActive(false);
            _shopView._panel.SetActive(false);
            _menuPanel.SetActive(true);
        }
        public void ToShop(){
                _shopController.ShowShop();
        }
        public void ToColor(){
            _shopController.ShowColors();
        }
        public void ToGuns(){
            _shopController.ShowGuns();
        }
      
        public void GetColor(int color){
            _shopController.BuyColor(color);
        }

        public void LoadLevel(int level){
            Time.timeScale = 1.0f;
            _levelController.SceneLoad(level);
        }
        public void ToLevelScreen(){
            _menuPanel.SetActive(false);
            _levelController.ShowScreen();
        }
        public void TryPlayMusic(){
            _audio.PlayMusic();
        }
    }
}
