using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partypeople : MonoBehaviour {

    Camera cam;

    [SerializeField] int Min_set_spd = 10;
    [SerializeField] int Max_set_spd = 20;

    int count = 0;
    int wuwf = 0;

    void Awake(){
        cam = GetComponent<Camera>();
        wuwf_set();
    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if (count == wuwf){
            count = 0;
            wuwf_set();
            Change_color();
        }
	}

    void wuwf_set(){
        wuwf = Random.Range(Min_set_spd, Max_set_spd);
    }

    void Change_color(){
        cam.backgroundColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
