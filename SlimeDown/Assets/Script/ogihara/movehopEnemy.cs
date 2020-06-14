using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movehopEnemy : MonoBehaviour {

    private bool turn = true;
    private bool turn_jump;
    private float speed;
    public float x, y,jump_x,jump_y;
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
    void Start()
    {

    }
    void Hit()
    {
        player.GetComponent<Slime_sp1>().Set_Helthpoint(EnemyHP);
        //自分が死ぬ処理
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //    if (other.gameObject.tag == "wall")
        //    {
        //        turn = !turn;
        //    }
        if (other.gameObject.tag == "Player")
        {
            Hit();
        }
        //    if (other.gameObject.tag == "cliff")
        //    {
        //        turn = !turn;
        //    }
    }
    void Awake()
    {
        player = GameObject.Find("slime");
        Start_Helth(529);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 now = rb.position; //敵の座標を取得
        Vector3 scale = transform.localScale;
        timer += Time.deltaTime;
        if (turn == true)
        {
            now += new Vector2(x, y);  // 前に少しずつ移動するように加算
            rb.position = now; // 値を設定            
            if (timer > 3)
            {
                Vector2 force = new Vector2(-jump_x, jump_y);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える                
                    turn = !turn;
                    timer = 0;
                scale.x = -1;
            }
        }
        if (turn == false)
        {
            now -= new Vector2(x, y);
            rb.position = now;
            if (timer > 3)
            {
                Vector2 force = new Vector2(jump_x, jump_y);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える
                    turn = !turn;
                    timer = 0;
                scale.x = 1;
            }
        }
        transform.localScale = scale;

    }
}
