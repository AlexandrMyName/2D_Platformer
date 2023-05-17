using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    /// <summary>
    /// »спользуетс€, дл€ св€зи от кнопок к игровой логике
    /// </summary>
    public class ButtonPooler : MonoBehaviour
    {

        bool isLeftInput;
        bool isRightInput;
        bool isUpInput;
      
        public bool IsLeftInput { get { return isLeftInput; } }
        public bool IsRightInput { get { return isRightInput; } }
        public bool IsUpInput { get { return isUpInput; } }


        public void IsLeft() => isLeftInput = true;
        public void IsRight() => isRightInput = true;
        public void IsUp() => isUpInput = true;
        //
        public void NoLeft() => isLeftInput = false;
        public void NoRight() => isRightInput = false;
        public void NoUp() => isUpInput = false;
    }
}
