using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class YandexSDK : MonoBehaviour
    {
        [Inject(Id = "All_Sounds")]
        GameObject _sounds;

        [DllImport("__Internal")]
        private static extern void ShowAdv();




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
        }
    }
}
