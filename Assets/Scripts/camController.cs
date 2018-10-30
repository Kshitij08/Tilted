using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + 3, transform.position.z);
	}
}
