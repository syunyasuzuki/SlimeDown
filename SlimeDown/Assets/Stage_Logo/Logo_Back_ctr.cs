using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Back_ctr : MonoBehaviour
{
    float alpha;
    float Red;
    float Green;
    float Bure;

    float scale_x;
    float scale_y;

    public static bool Stage_Check;

	// Use this for initialization
	void Start ()
    {
        Stage_Check = false;
        alpha = 0.0f;
        scale_x = 0.0f;
        scale_y = 0.1f;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        transform.localScale = new Vector2(scale_x, scale_y);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Stage_Check = true;
        }

        if (Stage_Check == true)
        {
            Logo_Back_Open();
        }

        if (Stage_Check == false)
        {
            Logo_Back_Close();
        }
    }

    void Logo_Back_Open()
    {
        alpha = 0.5f;
        if (scale_x <= 9.0f)
        {
            scale_x += Time.deltaTime * 30.0f;
        }

        if (scale_x >= 9.0f && scale_y <= 0.8f)
        {
            scale_y += Time.deltaTime * 5.0f;
        }

        if (scale_x >= 9.0f && scale_y >= 0.7f)
        {
            Stage_Logo_ctr.Logo_Back_Check = true;
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        transform.localScale = new Vector2(scale_x, scale_y);
    }

    void Logo_Back_Close()
    {
        
        if (scale_y >= 0.11f)
        {
            scale_y -= Time.deltaTime * 5.0f;
        }
        if(scale_y <= 0.11f && scale_x >= -0.1f)
        {
            scale_x -= Time.deltaTime * 30.0f;
        }
        if (scale_y <= 0.11f && scale_x <= -0.1f)
        {
            alpha = 0.0f;
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        transform.localScale = new Vector2(scale_x, scale_y);
    }
}
