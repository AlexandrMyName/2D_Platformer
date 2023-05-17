using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class WinModel
    {
        private WinView _view;

        public WinModel(WinView view) => _view = view;
        public void ShowScore(float health)
        {

            CheckpointUtilit.Remove();
            Time.timeScale = 0.0f;
            _view._panel.gameObject.SetActive(true);
            Transform _winScore = _view._panel.transform.GetChild(2).gameObject.transform;
            _winScore.gameObject.SetActive(false);

            if (health > 90)
                ShowScore(3, _winScore);
            else if (health > 70)
                ShowScore(2, _winScore);
            else if (health > 49)
                ShowScore(1, _winScore);
            else
                ShowScore(0, _winScore);
        }
        private void ShowScore(int score, Transform parrentObject)
        {
            bool isOne = score == 1 ? true : false;
            bool isTwo = score == 2 ? true : false;
            bool isThree = score == 3 ? true : false;

            if (isThree){
                isOne = true;
                isTwo = true;
            }
            else if (isTwo)
                isOne = true;
            
            parrentObject.gameObject.SetActive(true);
            parrentObject.gameObject.transform.GetChild(0).gameObject.SetActive(isOne);
            parrentObject.gameObject.transform.GetChild(1).gameObject.SetActive(isTwo);
            parrentObject.gameObject.transform.GetChild(2).gameObject.SetActive(isThree);
            SaveScore(score);
        }

        public void SaveScore(int count = 0)
        {
            int currentSceen = 1;

            if (PlayerPrefs.HasKey("Win_count")){
                _view._count.text = "X  "  +  (PlayerPrefs.GetInt("Win_count") + count).ToString();
                PlayerPrefs.SetInt("Win_count", PlayerPrefs.GetInt("Win_count") + count);
            }
            else{
                _view._count.text = "X  " + (count).ToString();
                PlayerPrefs.SetInt("Win_count", 0 + count);
            }

            if (PlayerPrefs.HasKey("Levels")){
                currentSceen = PlayerPrefs.GetInt("Levels");

                string activeScene = SceneManager.GetActiveScene().name[SceneManager.GetActiveScene().name.Length - 1].ToString();

                if (currentSceen == Convert.ToInt32(activeScene))
                             PlayerPrefs.SetInt("Levels", ++currentSceen); 
            }
            else PlayerPrefs.SetInt("Levels", ++currentSceen);

        }
    }  
}