using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
    GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Fade_ctr.GameStrat == true)
        {
            Invoke("SlimeActive", 1.0f);
        }
	}

    void SlimeActive()
    {
        Player.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FadeCon.isFade1 = true;
            FadeCon.isFadeOut1 = true;
            Invoke("Go_GameScene", 2.0f);
        }
    }

    void Go_GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
