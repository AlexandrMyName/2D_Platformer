using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class LevelController
    {
        private LevelView _levelView;
        private LevelModel _levelModel;

        public LevelController(LevelView levelView){
            _levelView = levelView;
            _levelModel = new LevelModel();
        }

        public void SceneLoad(int level){
            if (!_levelModel.CheckLevel(level)){
                if(Languege.current == "ru")
                _levelView._error.text = "Уровень пока не доступен! Вам доступны уровни до " + PlayerPrefs.GetInt("Levels") + " уровня";
                         else _levelView._error.text = "The level is not yet available! You have levels up to " + PlayerPrefs.GetInt("Levels") + " level";
            }
        }

        public void ShowScreen() => _levelView._panel.SetActive(true);
        
    }
}
