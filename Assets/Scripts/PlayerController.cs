using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private GameObject FocalPoint;
    public float speed = 12.0f;
    public bool gainedPowerUP = false;
    private float powerUpStrength = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Rotate-cam");
    }

    // Update is called once per frame
    void Update()
    {
        
        float VerticalInput = Input.GetAxis("Vertical");
       PlayerRb.AddForce(FocalPoint.transform.forward * VerticalInput * speed );
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            gainedPowerUP = true;
            Destroy(other.gameObject);
            StartCoroutine(CountDounRoutine());
        }
    }
    IEnumerator CountDounRoutine()
    {
        yield return new WaitForSeconds(7);
              gainedPowerUP = false;

}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gainedPowerUP)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("collide with" + collision.gameObject.name + " with power up set to " + gainedPowerUP);

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
    
}
