using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_ctr : MonoBehaviour
{
    [SerializeField] Fade fade = null;

    Demo_cells demo;

    public void OnClick()
    {

    }

    // Use this for initialization
    void Start()
    {
        demo = GetComponent<Demo_cells>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            demo.Change_mode(1);
            fade.FadeIn(2.7f);
        }
    }
}
