using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class EmmiterController
    {
        private  List <BulletController> _bulletControllers = new List <BulletController> ();
        private Transform _tr;
        private int _index;
        private float _timeTillNextBullet;
        private float _startSpeed = 9;
        private float _delay = 3;

        public EmmiterController(List<BulletView> bullets, Transform emmiterT)
        {
            _tr = emmiterT;
            foreach(BulletView view in bullets)
            {
                _bulletControllers.Add(new BulletController(view));
            }
        }
        public void Update()
        {
            if(_timeTillNextBullet > 0)
            {
                _bulletControllers[_index].Active(false);
                _timeTillNextBullet-= Time.deltaTime;

            }
            else
            {
                _timeTillNextBullet = _delay;
                _bulletControllers[_index].TrowBullet(_tr.position, _tr.up * _startSpeed);
                _index++;
                if(_index >= _bulletControllers.Count)
                    _index = 0;
            }
        }
    }
}
