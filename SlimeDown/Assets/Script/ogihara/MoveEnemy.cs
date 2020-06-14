using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    private bool turn = true;
    private float speed;
    public float x, y;
    private GameObject player;
    public float movecout;
    private float timer;

    private int EnemyHP = 0;

    //大きさが変わらない敵の体力を設定
    void Start_Helth(int n)
    {
        EnemyHP = n;
    }

    // Use this for initialization
    void Start ()
    {
        
	}
    void Hit()
    {
        //Set_Helthpoint(EnemyHP);//プレイヤー側に自分の体力を渡す
        //自分が死ぬ処理

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "wall")
        {
            turn = !turn;
        }
        if(other.gameObject.tag == "player")
        {
            Hit();
        }
        if(other.gameObject.tag== "cliff")
        {
            turn = !turn;
        }
    }
    void Awake()
    {
        //プレイヤー
        //player=GameObject.Find("");
        Start_Helth(529);
    }

    // Update is called once per frame
    void Update () {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 now = rb.position; //敵の座標を取得
        timer += Time.deltaTime;
		if(turn == true)
        {
            now += new Vector2(x, y);  // 前に少しずつ移動するように加算
            rb.position = now; // 値を設定            
            if (timer>5)
            {                                       
             turn = !turn;
             timer = 0;
            }
        }
        if(turn == false)
        {
            now -= new Vector2(x, y);
            rb.position = now;           
            if (timer > 5)
            {                        
             turn = !turn;
             timer = 0;
            }
        }

    }
}
