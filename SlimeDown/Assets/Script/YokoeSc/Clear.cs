using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {

    public static int mp = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if(gameObject.name=="Player")
        {
            mp += 1;

            SceneManager.LoadScene("Game");

            //if(mp==0)
            //{
            //    SceneManager.LoadScene("Game2");
            //}
            //else if(mp==1)
            //{
            //    SceneManager.LoadScene("Game3");
            //}
            //else
            //{
            //    SceneManager.LoadScene("Game4");
            //}

        }
    }
}
