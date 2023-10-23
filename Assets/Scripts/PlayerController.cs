using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private GameObject FocalPoint;
    public float speed = 12.0f;
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
}
