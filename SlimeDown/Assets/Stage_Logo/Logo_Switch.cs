using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Switch : MonoBehaviour
{
    public GameObject Stage_Logo1;
    public GameObject Stage_Logo2;
    public GameObject Stage_Logo3;
    public GameObject Stage_Logo4;

    float Alpha1;
    float Alpha2;
    float Alpha3;
    float Alpha4;

    // Use this for initialization
    void Start ()
    {
        Alpha1 = 0.0f;
        Alpha2 = 0.0f;
        Alpha3 = 0.0f;
        Alpha4 = 0.0f;

        Stage_Logo1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha1);
        Stage_Logo2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha2);
        Stage_Logo3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha3);
        Stage_Logo4.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha4);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Clear.mp == 0)
        {
            Alpha1 = 1.0f;
            Stage_Logo1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha1);
        }
        else if (Clear.mp == 1)
        {
            Alpha2 = 1.0f;
            Stage_Logo2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha2);
        }
        else if (Clear.mp == 2)
        {
            Alpha3 = 1.0f;
            Stage_Logo3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha3);
        }
        else if (Clear.mp == 3)
        {
            Alpha4 = 1.0f;
            Stage_Logo4.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha4);
        }

    }
}
