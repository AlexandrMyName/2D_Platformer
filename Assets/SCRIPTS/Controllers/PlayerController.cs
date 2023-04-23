using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace PlatformerMVC
{
    public class PlayerController
    {
        [Inject(Id = "Player_Configs")]
        private AnimationConfig _animationPlayerConfig;
        [Inject(Id = "Player_Configs")]
        private SpriteAnimatorController _playerAnimator;

        private LevelObjectView _playerView;

        #region player_Movemant_LocalCnf

        private float _xInput;
        private float _groundLevel = 0.5f;
        private float _g = -9.8f;

        private float _animationSpeed = 25f;
        private float _moveSpeed = 3f;
        private float _jumpForce = 6f;
        private float _yVelocity;
        private float _jumpTrashhold = 0.1f;
        private float _moveTrashhold = 0.3f;

        private bool _isMoving;
        private bool _isJump;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        #endregion

        public PlayerController(LevelObjectView playerView) =>_playerView = playerView;

        public void Awake(){

            _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Idle, true, 15f);
        }
        public void Update(){

            _playerAnimator?.Update();

            _xInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xInput) > _moveTrashhold;

            if (_isMoving) MoveTowards();
 
            if (IsGround()){

                _playerAnimator.StartAnimation(_playerView._sprite, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);


                if ((_isJump || Input.GetKeyDown(KeyCode.Space)) && _yVelocity <= 0 ) //START Jump
                    _yVelocity = _jumpForce;
                
                else if (_yVelocity < 0){ //END Jump

                    _yVelocity = 0;
                    _playerView._transform.position = new Vector3(_playerView._transform.position.x, _groundLevel, _playerView._transform.position.z);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTrashhold)
                    _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Jump, false, _animationSpeed);
                
                _yVelocity += _g * Time.deltaTime;
                _playerView._transform.position += Vector3.up * (_yVelocity * Time.deltaTime);
            }
        }


        private void MoveTowards()
        {
            _playerView._transform.position += Vector3.right * (Time.deltaTime * _moveSpeed * (_xInput < 0 ? -1 : 1));
            _playerView._transform.localScale = _xInput < 0 ? _leftScale : _rightScale;
        }
        private bool IsGround() => _playerView._transform.position.y <= _groundLevel && _yVelocity <= 0;
    }
}
