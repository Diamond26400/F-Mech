using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 25.0f;
    public Transform playerTransform;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Shoot();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy and the bullet
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        // Spawn a bullet at the player's position
        // Assuming the playerTransform is assigned in the inspector
        Instantiate(this, playerTransform.position, playerTransform.rotation);
    }
}

