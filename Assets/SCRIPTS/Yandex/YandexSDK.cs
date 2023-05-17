using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlatformerMVC
{
    public class YandexSDK : MonoBehaviour
    {

        private string lang;

        public TextMeshProUGUI _win;
        public TextMeshProUGUI _lose;
        public TextMeshProUGUI _shopButt;
        public TextMeshProUGUI _levelsButt;
        public TextMeshProUGUI _shopName;
        public TextMeshProUGUI _menuName;
        public TextMeshProUGUI _levelMain;

        public TextMeshProUGUI _shopPerconButt;
        public TextMeshProUGUI _shopColorMain;


        public TextMeshProUGUI _backButShop;

        public TextMeshProUGUI _backLevelShopColor;
        public TextMeshProUGUI _scoreColorPrice1;
        public TextMeshProUGUI _scoreColorPrice2;
        public TextMeshProUGUI _scoreColorPrice3;


        public TextMeshProUGUI _textErrorColor;



        [Inject(Id = "All_Sounds")]
        GameObject _sounds;

        [DllImport("__Internal")]
        private static extern void ShowAdv();




        [SerializeField] Main _main;


        public Localization localization;


        private void Awake()
        {
            localization = GameObject.Find("-[Languege Pakage]-").GetComponent<Localization>();
            localization.Yandex = this;
            localization.SwitchLanguege(localization.Lang);

          
         
        }
        private void Start()
        {


           



#if !UNITY_EDITOR
           
          
         ShowAdd();

           
            

#endif
        }

      
        
        public void ShowAdd(){

            _sounds.SetActive(false);
            Time.timeScale = 0.0f;
            ShowAdv();
        }
        public void AdvClosed()
        {
            _sounds.SetActive(true);
            Time.timeScale = 1.0f;
            _main.TryPlayMusic();
        }
    }
}
