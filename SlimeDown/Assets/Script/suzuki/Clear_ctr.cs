using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_ctr : MonoBehaviour
{
    Demo_cells demo;

    [SerializeField] Fade fade = null;

    [SerializeField] Image Clear_Logo;
    [SerializeField] Image Clear_Logo_frame;

    [SerializeField] Image Clear_Back;
    [SerializeField] Image Clear_Back_frame;

    [SerializeField] GameObject Click_Title;

    float Image_Alpha;
    float Object_Alpha;

    float Y = 150.0f;

    bool Clear_Check;

    // Use this for initialization
    void Start ()
    {
        Clear_Check = false;

        demo = GetComponent<Demo_cells>();

        demo.Change_mode(1);

        Image_Alpha = 0.0f;
        Object_Alpha = 0.0f;

        Clear_Back.color = new Color(1.0f, 1.0f, 1.0f, Image_Alpha);
        Clear_Logo.color = new Color(1.0f, 1.0f, 1.0f, Image_Alpha);

        Click_Title.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Object_Alpha);

        fade.FadeIn(1.0f, () =>
        {
            Image_Alpha = 1.0f;
            Clear_Back.color = new Color(0.0f, 0.5f, 1.0f, Image_Alpha);
            Clear_Logo.color = new Color(0.0f, 1.0f, 1.0f, Image_Alpha);
            fade.FadeOut(5.0f, () =>
            {
                Clear_Check = true;
            });
        });
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Clear_Check == true)
        {
            if (Clear_Logo.rectTransform.localPosition.y <= 90 && Clear_Back.rectTransform.localPosition.y <= 90)
            {
                Clear_Logo.rectTransform.localPosition += new Vector3(0, Y, 0) * Time.deltaTime;
                Clear_Logo_frame.rectTransform.localPosition += new Vector3(0, Y, 0) * Time.deltaTime;
                Clear_Back.rectTransform.localPosition += new Vector3(0, Y, 0) * Time.deltaTime;
                Clear_Back_frame.rectTransform.localPosition += new Vector3(0, Y, 0) * Time.deltaTime;
            }
            else
            {
                Object_Alpha += 5.0f * Time.deltaTime;
                Click_Title.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Object_Alpha);
                if (Object_Alpha >= 1.0f)
                {
                    Clear_Check = false;
                }
            }
        }
    }
}
