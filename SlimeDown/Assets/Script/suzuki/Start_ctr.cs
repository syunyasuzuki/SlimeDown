using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_ctr : MonoBehaviour
{
    float Alpha;

    public static bool Start_Check;

	// Use this for initialization
	void Start ()
    {
        Alpha = 1.0f;
        Start_Check = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Start_Check == true)
        {
            Alpha -= 1.0f * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha);
            if (Alpha <= 0.0f)
            {
                Start_Check = false;
                transform.position = new Vector3(100.0f, 0.0f, 0.0f);
            }
        }
	}
}
