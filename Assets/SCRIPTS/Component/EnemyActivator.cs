using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{

    [SerializeField] private  GameObject _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _enemy.SetActive(true);
        }
    }
}
