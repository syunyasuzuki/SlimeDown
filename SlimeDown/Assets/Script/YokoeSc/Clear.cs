using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {

    //マップ変更の変数
    public static int mp = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        //当たったオブジェクトがプレイヤーの場合
        if(gameObject.name=="Player")
        {
            //マップ変更
            mp += 1;

            SceneManager.LoadScene("GameScene");

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
