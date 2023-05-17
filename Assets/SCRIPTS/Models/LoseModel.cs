using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class LoseModel
    {
        [Inject(Id = "Yandex")] private YandexSDK sdk;
        public int UpdateCount(LoseView view)
        {
            Time.timeScale = 0;
            int Checker_count = 0;
            int CurrentDeathForAdv = 0;
            view._panel.SetActive(true);

            #region Show Add block
            if (PlayerPrefs.HasKey("adv_deathCount")){
               
                CurrentDeathForAdv = PlayerPrefs.GetInt("adv_deathCount");

                if (CurrentDeathForAdv == Checker_count) sdk.ShowAdd();

                CurrentDeathForAdv += 15;

                PlayerPrefs.SetInt("adv_deathCount", CurrentDeathForAdv);
            }
            else{
                CurrentDeathForAdv += 20;
                PlayerPrefs.SetInt("adv_deathCount", CurrentDeathForAdv);
            }
            #endregion


            if (PlayerPrefs.HasKey("death_count"))
            {
                Checker_count = PlayerPrefs.GetInt("death_count");
                Checker_count++;
                
                PlayerPrefs.SetInt("death_count", Checker_count);

                view._count.text = "x " + Checker_count.ToString();
                return Checker_count;
            }
            else
            {
                PlayerPrefs.SetInt("death_count", ++Checker_count);

                view._count.text = "x " + Checker_count.ToString();
                
                return Checker_count;
            }
        }


    }
}
