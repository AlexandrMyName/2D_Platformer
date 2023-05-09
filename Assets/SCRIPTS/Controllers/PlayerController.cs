using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace PlatformerMVC
{
    public class PlayerController
    {
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


        [Inject]
        private ButtonPooler _mobile;

        [Inject]
        public AudioController Audio { get; set; }


        private float health = 100f;
        public PlayerController(InteractiveObjView playerView, ContactPooler _contactPooler){

            _playerView = playerView;
            _rb = _playerView._rb;
            _poolContacts = _contactPooler;
            playerView.takeDamage += TakeDamage;
            _playerView._healthBar.maxValue = 100f;


            if (PlayerPrefs.HasKey("Current_color"))
            {
                int color = PlayerPrefs.GetInt("Current_color");

                switch (color){
                    case 0: playerView._sprite.color = Color.red;
                        break;
                    case 1: playerView._sprite.color = Color.green;
                        break;
                    case 2: playerView._sprite.color = Color.blue;
                        break;  
                }    
            }
        }
      
        private void TakeDamage(BulletView view)
        {
            health -= view.DamagePoint;
          
            _playerView._healthBar.value = health;

            if (health <= 0)
            {
                health = 0;
                _playerView._healthBar.gameObject.SetActive(false);
                _playerView._rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
                _playerView._collider2D.isTrigger = true;
            }
        }
        public void Update(){

            _playerAnimator?.Update();
            _poolContacts?.Update();
            _xInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xInput) > _moveTrashhold;
            _yVelocity = _rb.velocity.y;
            
          
            if ((_isMoving || _mobile.IsLeftInput || _mobile.IsRightInput) && (!_poolContacts.IsLeftContact && !_poolContacts.IsRightContact)) MoveTowards();
            else 
            {
                if((_poolContacts.IsLeftContact || _poolContacts.IsRightContact) && _poolContacts.IsGround)
                    _xVelocity = _xVelocity = Time.fixedDeltaTime * _moveSpeed * (_xInput < 0 ? -1 : 1);
                else

                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity,_rb.velocity.y);
            }
            if (_poolContacts.IsGround){

                if (_mobile.IsLeftInput || _mobile.IsRightInput){

                        _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Run , true, _animationSpeed);
                }
                else _playerAnimator.StartAnimation(_playerView._sprite, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);

                if ((_isJump || Input.GetKeyDown(KeyCode.Space) || _mobile.IsUpInput)) //START Jump
                {
                    Audio.PlayJump();
                    _rb.velocity = new Vector2(_xVelocity, 0);
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTrashhold)
                    _playerAnimator.StartAnimation(_playerView._sprite, AnimationState.Jump, false, _animationSpeed);
            }
        }


        private void MoveTowards()
        {
            if (_mobile.IsLeftInput || _mobile.IsRightInput)
            {
                if (_mobile.IsRightInput){
                    _playerView._transform.localScale = _rightScale;
                   
                    _xVelocity = Time.fixedDeltaTime * _moveSpeed * 1;
                }
                else{
                    _playerView._transform.localScale = _leftScale;
                    
                    _xVelocity = Time.fixedDeltaTime * _moveSpeed * -1;
                }

                _rb.velocity = new Vector2(_xVelocity, _yVelocity);

                return;
            }
            else{
                _xVelocity = Time.fixedDeltaTime * _moveSpeed * (_xInput < 0 ? -1 : 1);
                _rb.velocity = new Vector2(_xVelocity, _yVelocity);
                _playerView._transform.localScale = _xInput < 0 ? _leftScale : _rightScale;
            }
        }
      
    }
}
