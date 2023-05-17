using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace PlatformerMVC
{
    public class InteractiveObjView : LevelObjectView
    {
        public Action<BulletView> takeDamage;
        public Action death;
        public Action nextLevel;

        [Inject]
        public AudioController Audio { get; set; }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "OutWorld")
            {
                death?.Invoke();
                Debug.Log("Invoke");
                Audio.Death();
            }
            if (collision.tag == "NextLevel")
            {
                nextLevel?.Invoke();
                Debug.Log("Invoke");

            }
            if (collision.gameObject.tag == "Enemy_Death")
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
                GetComponent<Collider2D>().isTrigger = true;
                Audio.Death();

            }
            if (collision.gameObject.CompareTag("Checkpoint"))
            {
                CheckpointUtilit.Save(_transform);
                collision.gameObject.SetActive(false);
                Audio.PlayCheckpoint();
            }
        }
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
            if (collision.gameObject.tag == "TrollPlatformDeath")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Collider2D>().isTrigger = true;
                Audio.Death();

            }
            if (collision.gameObject.tag == "Enemy_TrollPlatform")
            {
                collision.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100, ForceMode2D.Impulse);
                //GetComponent<Collider2D>().isTrigger = true;

            }
            if (collision.gameObject.tag == "Enemy")
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
                GetComponent<Collider2D>().isTrigger = true;
                Audio.Death();
                

            }

        }
    }
}
