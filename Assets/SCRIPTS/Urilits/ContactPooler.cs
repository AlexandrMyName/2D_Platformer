using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler
    {
        private Collider2D _collider;
        private ContactPoint2D[] _points = new ContactPoint2D[5];
        private int counter;
        private float _treshold = 0.2f;

        public bool IsGround { get; private set; }
        public bool IsLeftContact { get; private set; }
        public bool IsRightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider = collider;
        }
      
        public void Update()
        {
            IsGround = false;
            IsLeftContact = false;
            IsRightContact = false;
            counter = _collider.GetContacts(_points);

            for(int i = 0; i < counter; i++)
            {
                if (_points[i].normal.y > _treshold) IsGround = true;
                if (_points[i].normal.x > _treshold) IsRightContact = true;
                if (_points[i].normal.x < -_treshold) IsLeftContact = true;

            }
        }
    }
}
