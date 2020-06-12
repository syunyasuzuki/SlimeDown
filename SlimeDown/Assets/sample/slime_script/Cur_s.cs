using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cur_s : MonoBehaviour {

    [SerializeField] GameObject Parent_;

    [SerializeField] bool Key_or_Mouse = true;
    public void Set_cursor_mode(bool b){
        //true = key , false = mouse
        Key_or_Mouse = b;
    }

    Vector2 cont = new Vector2(0, 0);

    public Vector2 Get_vec(){
        return cont;
    }

    [SerializeField] float Cur_range = 2.0f;

    Transform trans;
    SpriteRenderer spr;


    void Awake(){
        trans = GetComponent<Transform>();
        spr = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

	void Update () {
        if (Key_or_Mouse == true) { Updtask_k(); }
        else { Updtask_m(); }
	}

    void Updtask_k(){
        cont = Vector2.zero;
        cont.x = Input.GetAxis("Horizontal");
        cont.y = Input.GetAxis("Vertical");
        float sss = Mathf.Atan2(cont.y, cont.x);
        trans.position = new Vector3(Parent_.transform.position.x + Cur_range* Mathf.Cos(sss), Parent_.transform.position.y + Cur_range * Mathf.Sin(sss));
        if (cont.x == 0 && cont.y == 0){
            spr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else{
            Vector2 vec2 = cont.normalized;
            spr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    void Updtask_m(){
        Vector3 subv3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float sss = Mathf.Atan2(subv3.y, subv3.x);
        float subs = Mathf.Sqrt(Mathf.Pow(Parent_.transform.position.x - subv3.x, 2) + Mathf.Pow(Parent_.transform.position.y - trans.position.y, 2));
        if (subs > Cur_range){
            trans.position = new Vector3(Parent_.transform.position.x + Cur_range * Mathf.Cos(sss), Parent_.transform.position.y + Cur_range * Mathf.Sin(sss));
        }
        else{
            trans.position = new Vector3(Parent_.transform.position.x + subs * Mathf.Cos(sss), Parent_.transform.position.y + subs * Mathf.Sin(sss));
        }
        if (Input.GetMouseButtonDown(0)) { Parent_.GetComponent<Slime_sp1>().Atk_(Parent_.transform.position.x - transform.position.x, Parent_.transform.position.y - transform.position.y); }
        //trans.position = new Vector3(subv3.x, subv3.y, 0.0f);
    }
}
