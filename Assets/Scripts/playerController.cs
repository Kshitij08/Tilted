using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public GameObject player;
    public Rigidbody rb;
    public GameObject cam;

    public float speed = 100f;


    void Start () {
		
	}
    
	
	void Update () {

        Vector3 movement = Vector3.zero;
        movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
        rb.AddForce(movement * speed * Time.deltaTime);

        

        
    }
}
