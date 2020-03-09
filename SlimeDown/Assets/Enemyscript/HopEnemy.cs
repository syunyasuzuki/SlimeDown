using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopEnemy : MonoBehaviour
{

    //private float up = 0;
    //private float down = 0;
    private float timer = 0;
    private bool flag = true;//跳ねる時のフラグ
    public float x, y;
    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            flag = !flag;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5)
        {
            timer = 0;
            if (flag == true)
            {
                Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
                Vector2 force = new Vector2(x, y);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える
            }
            if (flag == false)
            {

                Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
                Vector2 force = new Vector2(-x, y);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える
            }
        }


    }
}
