using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class EnemyMoving : MonoBehaviour
    {

        [SerializeField] float speed;
        


        void Start()
        {
            Destroy(gameObject,100f);
        }

     
        void Update()
        {
            transform.position +=  (-Vector3.right * speed) * Time.deltaTime ;
        }
    }
}
