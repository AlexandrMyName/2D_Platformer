using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlatformerMVC
{
    public class CannonController 
    {
        private Transform _muzzle;
        private Transform _target;

        private Vector3 _direction;
        private Vector3 _axis;
        private float _angle;

        public CannonController (Transform muzzle, Transform target){

            _muzzle = muzzle;
            _target = target;   
        }

        public void Update()
        {
            _direction = _target.position - _muzzle.position;
            _angle = Vector3.Angle(Vector3.up, _direction);
            _axis = Vector3.Cross(Vector3.up, _direction);
            _muzzle.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}
