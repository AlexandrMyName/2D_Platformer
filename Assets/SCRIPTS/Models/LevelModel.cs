using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class LevelModel 
    {
        public bool CheckLevel(int level)
        {
            if (PlayerPrefs.HasKey("Levels"))
                if (PlayerPrefs.GetInt("Levels") >= level){

                        CheckpointUtilit.Remove();
                        SceneManager.LoadScene("Level_" + level);
                }
            return false;
        }
    }
}
