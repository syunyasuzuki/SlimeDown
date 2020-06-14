using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_2c : MonoBehaviour {

    private GameObject slime;
    private byte cp = 0;

    public void Set_cam(){
        cp = 1;
        slime = GameObject.Find("slime");
    }



	
	// Update is called once per frame
	void Update () {
        if (cp == 1){
            transform.position = new Vector3(slime.transform.position.x, slime.transform.position.y, transform.position.z);
        }
        if (transform.position.y < -55.5f) { transform.position = new Vector3(transform.position.x, -55.5f, transform.position.z); }
        if (transform.position.y > -4.5f) { transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z); }
        if (transform.position.x < -1.5) { transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z); }
        if (transform.position.x > 2.5f) { transform.position = new Vector3(2.5f, transform.position.y, transform.position.z); }
	}
}
