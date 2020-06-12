using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour {

    SpriteRenderer sr;

    //残る時間
    [SerializeField] int Air_Residual = 20;
    [SerializeField] Sprite air1;
    [SerializeField] Sprite air2;

    //1フレームで減らすa値
    private float pf_residual = 0;
    //処理軽減用(0=処理しない)
    private byte job = 0;
    //ジャンプ処理
    public void Jump_air(float px,float py){
        sr.sprite = air2;
        transform.position = new Vector3(px, py, 0.0f);
        sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        job = 1;
    }
    //攻撃(突進)
    public void Atak_air(float px,float py){
        sr.sprite = air1;
        transform.position = new Vector3(px, py, 0.0f);
        sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        job = 1;
    }

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        pf_residual = 1.00f / 20;
    }
	
	void Update () {
        if (job != 0){
            sr.color = new Color(1.0f, 1.0f, 1.0f, sr.color.a - pf_residual);
            if (sr.color.a <= 0.0f){
                job = 0;
            }
        }
	}
}
