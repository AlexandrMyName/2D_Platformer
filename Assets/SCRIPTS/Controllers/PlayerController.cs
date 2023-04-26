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

        private Rigidbody2D _rb;
        private ContactPooler _poolContacts;


        #region player_Movemant_LocalCnf

        private float _xInput;


        private float _animationSpeed = 25f;
        private float _moveSpeed = 170f;
        private float _jumpForce = 7f;
        private float _yVelocity = 0;
        private float _xVelocity = 0;
        private float _jumpTrashhold = 0.1f;
        private float _moveTrashhold = 0.3f;

        private bool _isMoving;
        private bool _isJump;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        #endregion

        public PlayerController(LevelObjectView playerView, ContactPooler _contactPooler)
        {
            _playerView = playerView;
            _rb = _playerView._rb;
            _poolContacts = _contactPooler;
        }

        public void Update(){

            _playerAnimator?.Update();
            _poolContacts?.Update();
            _xInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xInput) > _moveTrashhold;
            _yVelocity = _rb.velocity.y;
           

            if (_isMoving) MoveTowards();
            else 
            {
                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity,_rb.velocity.y);
            }
            if (_poolContacts.IsGround){
                _playerAnimator.StartAnimation(_playerView._sprite, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);

                if ((_isJump || Input.GetKeyDown(KeyCode.Space)) && _yVelocity == 0) //START Jump
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTrashhold)
                    _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Jump, false, _animationSpeed);

                if ((_poolContacts.IsLeftContact || _poolContacts.IsRightContact) && _isMoving)
                {
                    _xVelocity = 0;
                    _rb.velocity = new Vector2(_xVelocity, _rb.velocity.y);
                }
            }
        }


        private void MoveTowards()
        {

            _xVelocity = Time.fixedDeltaTime * _moveSpeed * (_xInput < 0 ? -1 : 1);
            _rb.velocity = new Vector2(_xVelocity,_yVelocity);
            _playerView._transform.localScale = _xInput < 0 ? _leftScale : _rightScale;
        }
      
    }
}
