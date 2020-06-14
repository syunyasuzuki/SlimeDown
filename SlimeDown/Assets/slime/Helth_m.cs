using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helth_m : MonoBehaviour {

    private int helthpoints = 0;
    private GameObject slime;



    //あわけ
    void Awake(){
        DontDestroyOnLoad(this);
        slime = GameObject.Find("slime");
        gameObject.name = "helth_box";
    }
    //体力を保存
    private void Take_helth(){
        helthpoints = slime.GetComponent<Slime_sp1>().Read_helthpoint();
    }
    //体力を教える
    public int Read_health(){
        return helthpoints;
    }
    //死-Die-
    public void Death_this_obj(){
        Destroy(gameObject);
    }


    void Update(){
        Take_helth();
    }
}
