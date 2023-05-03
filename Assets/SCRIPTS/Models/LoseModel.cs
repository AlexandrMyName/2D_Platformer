using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class LoseModel
    {

        public int UpdateCount(LoseView view)
        {
            int Checker_count = 0;
            view._losePanel.SetActive(true);
            
            if (PlayerPrefs.HasKey("death_count"))
            {
                Checker_count = PlayerPrefs.GetInt("death_count");
                Checker_count++;

                PlayerPrefs.SetInt("death_count", Checker_count);

                view._deathCount.text = "x " + Checker_count.ToString();
                return Checker_count;
            }
            else
            {
                PlayerPrefs.SetInt("death_count", ++Checker_count);

                view._deathCount.text = "x " + Checker_count.ToString();
                
                return Checker_count;

            }
        }


    }
}
