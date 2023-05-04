using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class WinModel
    {

        private WinView _view;

        public WinModel(WinView view) => _view = view;
        public void ShowScore(float health)
        {
            Time.timeScale = 0.0f;
            _view._panel.gameObject.SetActive(true);
            Transform _winScore = _view._panel.transform.GetChild(2).gameObject.transform;
            _winScore.gameObject.SetActive(false);

            if (health > 90)
            {
                _winScore.gameObject.SetActive(true);
                SaveScore(3);
            }
            else if (health > 70)
            {
                _winScore.gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                SaveScore(2);
            }
            else if (health > 49)
            {

                _winScore.gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                _winScore.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                SaveScore(1);
            }
            else
            {
                _winScore.gameObject.SetActive(true);
                _winScore.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                _winScore.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                _winScore.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                SaveScore();
            }

        }


        public void SaveScore(int count = 0)
        {
            if (PlayerPrefs.HasKey("Win_count"))
            {
                _view._count.text = "X  "  +  (PlayerPrefs.GetInt("Win_count") + count).ToString();
                PlayerPrefs.SetInt("Win_count", PlayerPrefs.GetInt("Win_count") + count);
            }
            else
            {
                _view._count.text = "X  " + (count).ToString();
                PlayerPrefs.SetInt("Win_count", 0 + count);
            }
        }


    }


   
}