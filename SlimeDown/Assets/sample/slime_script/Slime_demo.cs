using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_demo : MonoBehaviour {

    [SerializeField] Sprite S_normal;
    [SerializeField] Sprite S_attack;
    [SerializeField] Sprite S_jump;

    [SerializeField] GameObject S_cell;

    [SerializeField] float Spd = 20.0f;

    float x;
    byte down;
    byte up;

    byte jump_ready;
    byte ani_num = 0;


    int s_h = 0;

    byte now_mode = 1;

    Rigidbody2D rid2;
    Transform trans;
    SpriteRenderer spr;

    Vector3 scale;

    void Awake(){
        rid2 = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        spr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = down = up = 0;
        x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.DownArrow)) down = 1;
        Jump_m();
        if (down == 1) { Down_mode();if(jump_ready==0)rid2.AddForce(Vector2.down * 60); }
        else { Normal_mode(); }
        if (x != 0 && Mathf.Abs(rid2.velocity.x) <= 3.0f * now_mode){
            rid2.AddForce(Vector2.right * x * Spd * now_mode);
        }
        Debug_c();
	}

    void Undatetask(){
        
    }

    void Debug_c(){
        if (Input.GetKeyDown(KeyCode.H)) { trans.position = new Vector3(0.0f, 0.0f, 0.0f); }
    }

    void Jump_m(){
        if (jump_ready == 1 && now_mode != 2){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { Set_sprite(2); rid2.AddForce(Vector2.up * 300); }
        }
        if (jump_ready == 2 && rid2.velocity.y < 3.0f){
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(1)) { Set_sprite(0); rid2.AddForce(Vector2.up * 20); }
        }
    }

    void Down_mode(){
        if (now_mode != 2){
            Set_sprite(0);
            trans.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            trans.position = new Vector3(trans.position.x, trans.position.y - 0.25f, trans.position.z);
            //col2.size = new Vector2(1.0f, 0.5f);
            //col2.offset = new Vector2(0.0f, -0.25f);
            now_mode = 2;
        }
    }

    void Normal_mode(){
        if (now_mode != 1 && s_h == 0){
            Set_sprite(0);
            trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            trans.position = new Vector3(trans.position.x, trans.position.y + 0.25f, trans.position.z);
            //col2.size = new Vector2(1.0f, 1.0f);
            //col2.offset = new Vector2(0.0f, 0.0f);
            now_mode = 1;
        }
    }

    void Set_sprite(byte b){
        if (ani_num != b){
            ani_num = b;
            switch (b){
                case 1:
                    spr.sprite = S_attack;
                    break;
                case 2:
                    spr.sprite = S_jump;
                    break;
                default:
                    spr.sprite = S_normal;
                    break;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col){
        switch (col.gameObject.tag){
            case "yuka":
                if (jump_ready != 2) jump_ready = 1;
                break;
            case "kabe":
                jump_ready = 2;
                break;
            case "tenjo":
                s_h = 1;
                break;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "tenjo"){
            s_h = 0;
        }
        jump_ready = 0;
    }

    void OnTriggerStay2D(Collider2D col){
        //Not script
    }

    void OnTiggerExit2D(Collider2D col){
        //Not script
    }
}
