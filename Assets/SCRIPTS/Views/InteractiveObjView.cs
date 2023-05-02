using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class InteractiveObjView : LevelObjectView
    {
        public Action<BulletView> takeDamage;

        //public void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.tag == "Bullet") takeDamage?.Invoke(collision.GetComponent<BulletView>());
        //}
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                BulletView view = collision.gameObject.GetComponent<BulletView>();
                takeDamage?.Invoke(view);
                view.gameObject.SetActive(false);
               

            }
            if (collision.gameObject.tag == "TrollPlatform")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;


            }
            if (collision.gameObject.tag == "TrollUpp")
            {
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;


            }
        }
    }
}
