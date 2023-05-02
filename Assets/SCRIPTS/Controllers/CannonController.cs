using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class CannonController 
    {
        private Transform _muzzle;
        private Transform _target;

        private Vector3 _direction;
        private Vector3 _axis;
        private float _angle;
       
        private EmmiterController _emmitor;
        public CannonController (CannonView _view, Transform target){

            _muzzle = _view._muzzleTransform;
            _target = target;
            _emmitor = new EmmiterController(_view._bullets, _view._emmiterTransform);
        }

        public void Update()
        {
            _emmitor.Update();

            _direction = _target.position - _muzzle.position;
            _angle = Vector3.Angle(Vector3.up, _direction);
            _axis = Vector3.Cross(Vector3.up, _direction);
            _muzzle.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}
