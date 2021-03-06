﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pointer_ctr : MonoBehaviour
{
    Animator animator;

    Vector3 screenPoint;
    float pointerRotate;

    float P_Position_x;
    float P_Position_y;
    //public float Speed;
    //float pointer_move_x;
    //float pointer_move_y;

    float Red;
    float Green;
    float Brue;
    float Alpha;
    float Color_Speed = 1.0f;

    bool touch_E;           //敵に触れているか判定する変数
    bool gradation_switch;  //カーソルの色を点滅させたいときに使う変数

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //pointer_move_x = Input.GetAxisRaw("Horizontal");
        //pointer_move_y = Input.GetAxisRaw("Vertical");

        //マウスカーソルに追従させるプログラム
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        P_Position_x = Input.mousePosition.x;
        P_Position_y = Input.mousePosition.y;
        Vector3 a = new Vector3(P_Position_x, P_Position_y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);

        //キー又は、ジョイスティックが未入力の場合ポインターを非表示
        //if (pointer_move_x == 0.0f && pointer_move_y == 0.0f && touch_E == false)
        //{
        //    Alpha = 0.0f;
        //    gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha);
        //}
        //else
        //{
        //    Alpha = 1.0f;
        //    gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Alpha);
        //    PointerMove_J();
        //}

        //敵に触れている時、Enemytouchメソッドを呼び出す
        if (touch_E == true)
        {
            Enemytouch2();
        }
        else
        {
            Enemyleave();
        }
	}

    //キー又は、ジョイスティックが入力されたら実行されるメソッド
    //public void PointerMove_J()
    //{
    //    pointer_move_x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed;
    //    pointer_move_y = Input.GetAxisRaw("Vertical") * Time.deltaTime * Speed;
    //    transform.position += new Vector3(pointer_move_x, pointer_move_y, 0.0f);
    //}

    //敵に触れているかどうか
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            touch_E = true;
        }
    }

    //敵から離れたかどうか
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag== "Enemy")
        {
            touch_E = false;
        }
    }

    //敵に触れてる間実行するメソッド(食べられない敵)
    public void Enemytouch()
    {
        //敵に触れたら45度回転
        pointerRotate = Mathf.Clamp(pointerRotate + Time.deltaTime * 250, 0, 45);
        transform.eulerAngles = new Vector3(0, 0, pointerRotate);

        //lock-onアニメーション起動
        animator.SetFloat("lock-on", Red);

        //カーソルを赤く点滅させる
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Red, 0.0f, 0.0f);
        if (gradation_switch == true)
        {
            Red += Color_Speed * Time.deltaTime;
            if (Red >= 1.0f)
            {
                gradation_switch = false;
            }
        }
        if (gradation_switch == false)
        {
            Red -= Color_Speed * Time.deltaTime;
            if (Red <= 0.4f)
            {
                gradation_switch = true;
            }
        }
    }

    //敵に触れてる間実行するメソッド(食べられる敵)
    public void Enemytouch2()
    {
        //敵に触れたら45度回転
        pointerRotate = Mathf.Clamp(pointerRotate + Time.deltaTime * 250, 0, 45);
        transform.eulerAngles = new Vector3(0, 0, pointerRotate);

        //lock-onアニメーション起動
        animator.SetFloat("lock-on", Green);

        //カーソルを青く点滅させる
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, Green, 1.0f);
        if (gradation_switch == true)
        {
            Green += Color_Speed * Time.deltaTime;
            if (Green >= 0.6f)
            {
                gradation_switch = false;
            }
        }
        if (gradation_switch == false)
        {
            Green -= Color_Speed * Time.deltaTime;
            if (Green <= 0.0f)
            {
                gradation_switch = true;
            }
        }

        //敵にとびかかる
        if (Input.GetMouseButtonDown(0))
        {
            
            Color_Speed = 10.0f;
            animator.SetFloat("Attack", Color_Speed);
        }

        //左クリックゲームスタート
        if (SceneManager.GetActiveScene().name == "TitleScene" && Input.GetMouseButtonDown(0))
        {
            Color_Speed = 10.0f;
            animator.SetFloat("Attack", Color_Speed);
            Start_ctr.Start_Check = true;
            Fade_ctr.GameStrat = true;
        }
        else
        {
            Fade_ctr.GameStrat = false;
        }

        //左クリックタイトルに戻る
        if (SceneManager.GetActiveScene().name == "ClearScene" && Input.GetMouseButtonDown(0))
        {
            FadeCon.isFade1 = true;
            FadeCon.isFadeOut1 = true;
            Invoke("Go_Title", 1.5f);
        }
    }

    //敵から離れたとき実行するメソッド
    public void Enemyleave()
    {
        Color_Speed = 1.0f;

        //アニメーションを止める
        animator.SetFloat("lock-on", 0.0f);
        animator.SetFloat("Attack", 0.0f);

        //敵から離れたら45度戻す
        pointerRotate = Mathf.Clamp(pointerRotate - Time.deltaTime * 200, 0, 45);
        transform.eulerAngles = new Vector3(0, 0, pointerRotate);

        //色を白に戻す
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void Go_Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
