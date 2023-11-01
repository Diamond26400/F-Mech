using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //calling game object
    private Rigidbody PlayerRb;
    private GameObject FocalPoint;
    public GameObject PoweUPIndicator;

    public bool gainedPowerUP ;
    public float speed = 12.0f;
    public float powerUpStrength = 30000.0f;


    // Start is called before the first frame update
    void Start()
    {
        //calling game object
        PlayerRb = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Rotate-cam");
    }

    // Update is called once per frame
    void Update()
    {
        //player controls & position
        float VerticalInput = Input.GetAxis("Vertical");
        PlayerRb.AddForce(FocalPoint.transform.forward * VerticalInput * speed);
        PoweUPIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        // player collides with power up
        if (other.CompareTag("PowerUp"))
        {
            gainedPowerUP = true;
            Destroy(other.gameObject);
            StartCoroutine(CountDounRoutine());
            PoweUPIndicator.SetActive(true);
        }
    }
    IEnumerator CountDounRoutine()
    {
        //creating personal timer  till energy last
        yield return new WaitForSeconds(7);
        gainedPowerUP = false;
        PoweUPIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gainedPowerUP)
        {
            //Getting enemy rigid body to collide with player
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            // implementing rigid body & other
            Debug.Log("collide with" + collision.gameObject.name + " with power up set to " + gainedPowerUP);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

}
