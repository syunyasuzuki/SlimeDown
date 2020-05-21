using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Logo_ctr : MonoBehaviour
{
    float x = 5.0f;

    public static bool Logo_Back_Check;

	// Use this for initialization
	void Start ()
    {
        Logo_Back_Check = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Logo_Back_Check == true)
        {
            if (x >= 0.4f || x <= -0.4f)
            {
                x -= Time.deltaTime * 8.0f;
            }
            else
            {
                x -= Time.deltaTime * 0.8f;
            }
            
            if (x <= -5.0f)
            {
                Logo_Back_Check = false;
                Logo_Back_ctr.Stage_Check = false;
                x = 5.0f;
            }
            transform.position = new Vector3(x, 0.0f, 0.0f);
        }
	}
}
