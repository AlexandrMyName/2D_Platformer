using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace PlatformerMVC
{
    public class BulletController
    {
        private BulletView _bulletView;
        public BulletController(BulletView _view) => _bulletView = _view;
        public void Active(bool vol) => _bulletView.gameObject.SetActive(vol);
        
        private void SetVelocity(Vector3 velocity){
            float _angle = Vector3.Angle(Vector3.left, velocity);
            Vector3 _axis = Vector3.Cross(Vector3.left, velocity);
            _bulletView.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
        public void TrowBullet(Vector3 pos, Vector3 velocity){
            _bulletView.transform.position = pos;
            SetVelocity(velocity);
            _bulletView._rb.velocity = Vector2.zero;
            _bulletView._rb.angularVelocity = 0;
            Active(true);
            _bulletView._rb.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
