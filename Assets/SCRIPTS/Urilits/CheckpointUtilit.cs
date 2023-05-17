using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckpointUtilit 
{
  
    public static void Save(Transform transform)
    {
        PlayerPrefs.SetInt("Checkpoint", 1);
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
    }
    
    public static bool Check(Transform transform)
    {
        if(PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), transform.position.z);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Remove()
    {
        if (PlayerPrefs.HasKey("Checkpoint"))
        {
            PlayerPrefs.SetInt("Checkpoint", 0);
            PlayerPrefs.DeleteKey("x");
            PlayerPrefs.DeleteKey("y");
        }
    }
}
