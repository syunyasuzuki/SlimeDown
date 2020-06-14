using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopEnemy : MonoBehaviour {

    private float timer = 0;
    private bool flag = true;//跳ねる時のフラグ
    public float x, y;
    public object enemy;
    private GameObject player;
    private float jumpcount;


    private int EnemyHP = 0;

    //大きさが変わらない敵の体力を設定
    void Start_Helth(int n)
    {
        EnemyHP = n;
    }
    // Use this for initialization
    void Start () {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "wall")
        //{
        //    flag = !flag;
        //}
        if (col.gameObject.tag == "player")
        {
            HIT();

        }

    }

    void HIT()
    {
        player.GetComponent<Slime_sp1>().Set_Helthpoint(EnemyHP);
        Destroy(this.gameObject);
    }
    void Awake()
    {
        //プレイヤー
        player = GameObject.Find("slime");
        Start_Helth(529);
    }
    // Update is called once per frame


    void Update () {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
        timer += Time.deltaTime;
        Vector3 scale = transform.localScale;
        if (timer > 1.5) {
            timer = 0;
            if (flag == true)
            {               
                Vector2 force = new Vector2(x, y);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える
                jumpcount = 1 + jumpcount;
                //Debug.Log(jumpcount);
                if (jumpcount ==2)
                {
                   
                    //Debug.Log(x);
                    flag = !flag;
                    jumpcount = 0;
                    scale.x = -1;
                }
            }
            if (flag == false)
            {               
                Vector2 force2 = new Vector2(-x, y);  // 力を設定
                rb.AddForce(force2, ForceMode2D.Impulse);          // 力を加える
                jumpcount = 1 + jumpcount;
                //Debug.Log(jumpcount);
                if (jumpcount == 2)
                {                    
                    flag = !flag;
                    jumpcount = 0;
                    scale.x = 1;
                }
            }
           
        }
        transform.localScale = scale;
    }

}

