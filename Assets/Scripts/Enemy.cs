using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody enemiesPreferb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //calling Game object and physics
      
        player = GameObject.Find("Player");
    }

    // enemy follow player!
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemiesPreferb.AddForce(lookDirection * speed);
        //enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    
}
