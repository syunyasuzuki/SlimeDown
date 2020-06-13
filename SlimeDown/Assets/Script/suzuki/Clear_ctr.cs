using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear_ctr : MonoBehaviour
{
    Demo_cells demo;

    // Use this for initialization
    void Start ()
    {
        demo = GetComponent<Demo_cells>();

        demo.Change_mode(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
