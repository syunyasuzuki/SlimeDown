using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {

    string player;

    //マップ変更の変数
    public static int mp = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        player = col.gameObject.name;

        //当たったオブジェクトがプレイヤーの場合
        if (player == "slime" && mp < 3)
        {   
            FadeCon.isFade1 = true;
            FadeCon.isFadeOut1 = true;

            Invoke("LS", 1.5f);
        }

        //今がステージ４でプレイヤーが触れたとき
        if (player == "slime" && mp == 3)
        {
            FadeCon.isFade2 = true;
            FadeCon.isFadeOut2 = true;

            Invoke("Go_ClearScene", 2.0f);
        }
    }

    void LS()
    {
        //マップ変更
        mp += 1;
        SceneManager.LoadScene("GameScene");
    }

    void Go_ClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
