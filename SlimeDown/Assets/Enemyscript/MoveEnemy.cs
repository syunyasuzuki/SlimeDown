using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    private bool turn = true;
    private float speed;
    public float x, y;

    // Use this for initialization
    void Start()
    {

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
        Vector2 now = rb.position; //敵の座標を座標を取得
        if (turn == true)
        {
            now += new Vector2(x, y);  // 前に少しずつ移動するように加算
            rb.position = now; // 値を設定
        }
        if (turn == false)
        {
            now -= new Vector2(x, y);
            rb.position = now;
        }

    }
}
