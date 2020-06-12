using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_ctr : MonoBehaviour
{
    [SerializeField] Fade fade = null;

    Demo_cells demo;

    public static bool GameStrat;

    public void OnClick()
    {

    }

    // Use this for initialization
    void Start()
    {
        demo = GetComponent<Demo_cells>();
        GameStrat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStrat == true)
        {
            demo.Change_mode(1);
            fade.FadeIn(2.7f);
        }
    }
}
