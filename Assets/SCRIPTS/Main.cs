using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformerMVC
{


    public class Main : MonoBehaviour
    {
        [SerializeField] LevelObjectView _playerView;
        [SerializeField] private AnimationConfig _config;
        private SpriteAnimatorController _playerAnimator;

        private void Awake()
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimatorCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Idle, true, 10f);
        }
        private void Update()
        {
            _playerAnimator?.Update();
        }
    }

}
