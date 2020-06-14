using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime_sp1 : MonoBehaviour {

    //現在の体力
    private int Helthpoint;

    //体力の読み取り
    public int Read_helthpoint(){
        return Helthpoint;
    }

    //体力を変える(増減値)
    public void Set_Helthpoint(int n){
        Helthpoint += n;
        if (Helthpoint <= 0){
            //死亡
        }
    }

    SpriteRenderer sr;
    BoxCollider2D bo2;
    Rigidbody2D rid2;
    [SerializeField] GameObject Air;

    //現在のアニメーション(0=通常)
    private int Animation_n = 0;
    //現在のスプライト番号
    private int Animation_c = 0;
    //各アニメーションの数
    [SerializeField]int[] Max_animation;
    //アニメーションのためのカウント
    private int Animation_t = 0;

    private void Count_ani(int n){
        Animation_c++;
        if (Max_animation[n] == Animation_c){
            Animation_c = 0;
        }
    }
    //カウント加算
    private void Count_time(){
        Animation_t++;
    }
    //カウントクリア
    private void Clear_time(){
        Animation_t = 0;
    }
    //フレーム毎のアニメーション処理
    private void Animation_task(){
        Count_time();
        switch (Animation_n){
            case 0:
                A_normal();
                break;
        }
    }

    //細胞たち
    [SerializeField] Sprite[] normal;//通常状態
    [SerializeField] byte[] normal_t;//通常状態のアニメーション時間

    //通常状態
    private void A_normal(){
        if (Animation_t == normal_t[Animation_c]){
            Clear_time();
            Count_ani(Animation_n);
            sr.sprite = normal[Animation_c];
        }
    }

    //操作軸(0=左、1=右、2=伸び、3=しゃがみ、4=ジャンプ)
    private int[] control = new int[5];

    //移動する力
    [SerializeField] int Move_walk = 100;
    [SerializeField] int Move_dash = 300;
    private int move_now = 100;
    //ジャンプ力
    [SerializeField] int Jump_force = 500;
    //攻撃(突進)の力
    [SerializeField] int Atk_force = 1000;
    //ジャンプした
    private int jump_was = 0;
    //攻撃した
    private int atk_was = 0;

    //フレーム毎の操作処理
    private void Control_task(){
        for(int lu = 0; lu < control.Length; lu++){
            control[lu] = 0;
        }
        //キー入力
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { control[0] = 1; }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { control[1] = 1; }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { control[2] = 1; }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { control[3] = 1; }
        if (Input.GetKeyDown(KeyCode.Space)) { control[4] = 1; }
        //しゃがみ
        move_now = Move_walk;
        if (control[3] == 1) { move_now = Move_dash; }
        //左移動
        if (control[0] == 1 && control[1] != 1 && Mathf.Abs(rid2.velocity.x) <= 3.0f) { rid2.AddForce(Vector2.left * move_now); }
        //右移動
        if (control[1] == 1 && control[0] != 1 && Mathf.Abs(rid2.velocity.x) <= 3.0f) { rid2.AddForce(Vector2.right * move_now); }
        //伸び
        if (control[0] != 1 && control[1] != 1 || control[2] == 1) { }
        //ジャンプ
        if (control[4] == 1 && jump_was == 0){
            rid2.AddForce(Vector2.up * Jump_force);
            jump_was = 1;
        }
        if (rid2.velocity.y == 0){
            jump_was = atk_was = 0;
        }
    }

    //攻撃指示を受ける
    public void Atk_(float xp,float yp){
        if (atk_was == 0){
            rid2.AddForce(new Vector2(-xp, -yp) * Atk_force);
            atk_was = 1;
        }
    }

    //ジャンプリセット
    private void Reset_jump(){
        jump_was = 0;
    }
    //攻撃リセット
    private void Reset_atk(){
        atk_was = 0;
    }


    //中心位置
    private float local_px = 0;
    private float local_py = 0;

    //現在の中心点の位置を変える
    private void Set_controlpoints(float nx,float ny){
        local_px = nx;
        local_py = ny;
    }

    void Awake()
    {
        gameObject.name = "slime";
        GameObject cam = GameObject.Find("Main Camera");
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            cam.GetComponent<camera_2c>().Set_cam();
        }
        sr = GetComponent<SpriteRenderer>();
        bo2 = GetComponent<BoxCollider2D>();
        rid2 = GetComponent<Rigidbody2D>();
    }

    void Start () {
		
	}
	
	void Update () {
        Control_task();
        Animation_task();
        
	}




    //デバッグ
    private void Debug_control(){
        //体力を10増やす
        if (Input.GetKeyDown(KeyCode.U)) { Set_Helthpoint(10); }
        //体力を50増やす
        if (Input.GetKeyDown(KeyCode.I)) { Set_Helthpoint(50); }
        //体力を100増やす
        if (Input.GetKeyDown(KeyCode.O)) { Set_Helthpoint(100); }
    }

}
