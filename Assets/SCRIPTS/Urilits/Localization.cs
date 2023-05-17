using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class Localization : MonoBehaviour
    {

        private Localization languege;
        private YandexSDK yandex;

        [DllImport("__Internal")]
        private static extern string GetLang();
        public string Lang { get; private set; }
        public Localization Langueage { get => languege; set => languege = value; }
       
        public YandexSDK Yandex { get { return yandex; } set { yandex = value;  } }

        void Start()
        {
           
            if(languege == null  ){

                languege = this;
                DontDestroyOnLoad(gameObject);

#if !UNITY_EDITOR
                Lang = GetLang();
#else 
                Lang = "en";
#endif
                this.gameObject.name = "-[Languege Pakage]-";

                int maxLevel = 0;

                    if (PlayerPrefs.HasKey("Levels")){

                        maxLevel = PlayerPrefs.GetInt("Levels");
                        SceneManager.LoadScene("Level_"+maxLevel.ToString());
                    }
                    else SceneManager.LoadScene("Level_1");
                
            }
            else Destroy(gameObject);
        }

        public void SwitchLanguege(string lang)
        {
            if (lang == "ru")
            {
                yandex._win.text = "Уровень пройден!";
                yandex._lose.text = "Поражение!";
                yandex._menuName.text = "Меню";
                yandex._levelsButt.text = "Уровни";
                yandex._shopButt.text = "Магазин";
                yandex._levelMain.text = "Выбрать уровень";
                yandex._shopName.text = "Магазинчик";
                yandex._shopPerconButt.text = "Персонаж";
                yandex._backButShop.text = "Назад";
                yandex._shopColorMain.text = "Выбери цвет!";

                yandex._backLevelShopColor.text = "Назад";
                string price = "45 Очков";
                yandex._scoreColorPrice1.text = price;
                yandex._scoreColorPrice2.text = price;
                yandex._scoreColorPrice3.text = price;

                yandex._textErrorColor.text = "Выбери цвет для игрули!";
                Languege.current = "ru";
                Lang = lang;

            }
            else if (lang == "en")
            {

                yandex._win.text = "Level passed!";
                yandex._lose.text = "checkmate!";
                yandex._menuName.text = "Menu";
                yandex._levelsButt.text = "Levels";
                yandex._shopButt.text = "Shop";
                yandex._levelMain.text = "Сhoose a level";
                yandex._shopName.text = "Shop";
                yandex._shopPerconButt.text = "Character";
                yandex._backButShop.text = "Back";
                yandex._shopColorMain.text = "Choose a color";

                yandex._backLevelShopColor.text = "Back";
                string price = "45 (score)";
                yandex._scoreColorPrice1.text = price;
                yandex._scoreColorPrice2.text = price;
                yandex._scoreColorPrice3.text = price;

                yandex._textErrorColor.text = "Choose a color to play with!";
                Languege.current = "en";
            }
            Lang = lang;
            Debug.Log(lang);
        }
      
       
    }
}
