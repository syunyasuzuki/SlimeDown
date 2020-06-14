using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_ctr : MonoBehaviour
{
    Demo_cells demo;

    [SerializeField] Fade fade = null;

    [SerializeField] Image Clear_Logo;

    [SerializeField] Image Clear_Back;

    [SerializeField] GameObject Click_Title;

    float Alpha;

    float Y;

    // Use this for initialization
    void Start ()
    {
        demo = GetComponent<Demo_cells>();

        demo.Change_mode(1);

        Alpha = 0.0f;

        Clear_Back.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
        Clear_Logo.color = new Color(1.0f, 1.0f, 1.0f, Alpha);

        fade.FadeIn(1.0f, () =>
        {
            Alpha = 1.0f;
            Clear_Back.color = new Color(0.0f, 0.5f, 1.0f, Alpha);
            Clear_Logo.color = new Color(0.0f, 1.0f, 1.0f, Alpha);
            fade.FadeOut(5.0f);
        });
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
