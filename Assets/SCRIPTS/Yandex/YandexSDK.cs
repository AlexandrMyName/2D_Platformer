using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PlatformerMVC
{
    public class YandexSDK : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void ShowAdv();




        private void Start()
        {

#if !UNITY_EDITOR
            ShowAdd();
#endif
        }

        public void ShowAdd(){

            Time.timeScale = 0.0f;
            ShowAdv();
        }
        public void AdvClosed() => Time.timeScale = 1.0f;
        
        

    }
}
