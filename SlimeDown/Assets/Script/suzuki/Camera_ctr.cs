using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ctr : MonoBehaviour
{
    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
