using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformerMVC
{
    public enum AnimationState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }


    [CreateAssetMenu(fileName = "SpriteAnimator_Config",menuName = "CONFIGS/Animation")]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public AnimationState track;
            public List <Sprite> sprites;

        }
        public List<SpriteSequence> sequences = new List<SpriteSequence>();
    }


}