using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Logo_ctr : MonoBehaviour
{
    float x = 10.0f;

    public static bool Logo_Back_Check;

    // Use this for initialization
    void Start()
    {
        x = 10.0f;
        transform.position = new Vector3(-1.5f + x, -4.5f, 0.0f);
        Logo_Back_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Logo_Back_Check == true)
        {
            if (x >= 0.4f || x <= -0.4f)
            {
                x -= Time.deltaTime * 15.0f;
            }
            else
            {
                x -= Time.deltaTime * 1.0f;
            }

            if (x <= -10.0f)
            {
                Logo_Back_Check = false;
                Logo_Back_ctr.Stage_Check = false;
            }
            transform.position = new Vector3(-1.5f + x, -4.5f, 0.0f);
        }
    }
}
