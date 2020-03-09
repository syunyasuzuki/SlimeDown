using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluffyEnemy : MonoBehaviour
{
    private bool turn, up, down; //ターン,up,downフラグ
    public float x_up, y_up, x_down, y_down;
    private float timer = 0; //タイマー
    public float clock;

    // Use this for initialization
    void Start()
    {
        up = true;
        down = false;
        turn = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            turn = !turn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 now = rb.position; //敵の座標を取得
        timer += Time.deltaTime;
        if (turn == true)
        {
            if (up == true)
            {
                now += new Vector2(x_up, y_up);  // 前に少しずつ移動するように加算
                rb.position = now; // 値を設定
                if (timer > clock)
                {
                    up = false;
                    down = true;
                    timer = 0;
                }
            }
            if (down == true)
            {
                now += new Vector2(x_down, y_down);  // 前に少しずつ移動するように加算
                rb.position = now; // 値を設定
                if (timer > clock)
                {
                    up = true;
                    down = false;
                    timer = 0;
                }
            }
        }
        if (turn == false)
        {
            if (up == true)
            {
                now -= new Vector2(x_up, y_up);  // 前に少しずつ移動するように加算
                rb.position = now; // 値を設定
                if (timer > clock)
                {
                    up = false;
                    down = true;
                    timer = 0;
                }
            }
            if (down == true)
            {
                now -= new Vector2(x_down, y_down);  // 前に少しずつ移動するように加算
                rb.position = now; // 値を設定
                if (timer > clock)
                {
                    up = true;
                    down = false;
                    timer = 0;
                }
            }
        }

    }
}
