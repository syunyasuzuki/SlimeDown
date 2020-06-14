using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Ist;
using UnityEngine.SceneManagement;


public class Demo_cells : MonoBehaviour
{


    public struct Range
    {
        public int begin;
        public int end;
    }

    [SerializeField] GameObject bob;
    private Vector3 trans;

    public int m_num_draw = 1024;//最初の細胞の数

    //これが神だぞ
    //↓↓↓↓↓崇めよ↓↓↓↓↓

    BatchRenderer m_renderer;//神

    //↑↑↑↑↑讃えよ↑↑↑↑↑

    Vector3[] m_instance_t;//各細胞の位置を保存する
    Color[] m_instance_color;//各細胞の色を保存する
    Collider[] m_collider;//コライダーを読み込む
    Rigidbody[] m_rigidbody;//物理演算を読み込む
    //Vector4[] m_instance_uv;//各細胞のUV(画像のカットなど)の座標を保存する
    float[] m_instance_time;//各細胞の速度
    float[] m_fall_time;//落下している時間
    float[] m_def_p;//デフォルト位置
    int[] m_number;//細胞の番号
    float m_time;//ゲームを起動してから経過した時間(正直いらない)
    int m_num_active_tasks;//
    int player_mode = 0;

    //ランダムの短縮
    public float R(float v = 1.0f)
    {
        return Random.Range(-v, v);
    }

    //Startに似てるやつ(Startより呼び出しが先)
    void Awake()
    {
        m_renderer = GetComponent<BatchRenderer>();
        int num = m_renderer.GetMaxInstanceCount();
        m_instance_t = new Vector3[num];
        m_instance_color = new Color[num];
        m_collider = new Collider[num];
        //m_instance_uv = new Vector4[num];
        m_instance_time = new float[num];
        m_fall_time = new float[num];
        m_def_p = new float[num];
        m_number = new int[num];

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            for (int i = 0; i < num; ++i)
            {
                m_instance_t[i] = new Vector3(R(4.4f), Random.Range(-0.4f, 3.4f), 0.0f);
                m_instance_color[i] = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                m_instance_time[i] = Random.Range(0.01f, 0.03f);
                m_def_p[i] = m_instance_t[i].x;
                m_number[i] = i;
            }
        }
        else if (SceneManager.GetActiveScene().name == "ClearScene")
        {
            for (int i = 0; i < num; ++i)
            {
                m_instance_t[i] = new Vector3(R(8.2f), Random.Range(5.2f, 17.2f), 0.0f);
                m_instance_color[i] = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                m_instance_time[i] = Random.Range(0.01f, 0.03f);
                m_def_p[i] = m_instance_t[i].x;
                m_number[i] = i;
            }

        }
    }

    void Update()
    {
        m_num_draw = Mathf.Min(m_num_draw, m_instance_t.Length);
        m_time = Time.realtimeSinceStartup;
        int num = m_num_draw;
        {
            Interlocked.Increment(ref m_num_active_tasks);
            UpdateTask(new Range { begin = 0, end = num });
        }
        m_renderer.Flush();
    }

    //加速度計算(return)
    float Fall_object(float f, float t)
    {
        return f * t;
    }

    //モード切替
    public void Change_mode(int x)
    {
        player_mode = x;
        switch (player_mode)
        {
            case 0:
                //液状
                break;
            case 1:
                //滝
                break;
            case 2:
                //固体化
                trans = bob.transform.position;
                float a = m_num_draw / 552;
                int sidex = Mathf.FloorToInt(23 * Mathf.Sqrt(a));
                int sidey = Mathf.FloorToInt(24 * Mathf.Sqrt(a));
                //if (m_instance_t.Length < sidex * sidey) { sidey = Mathf.FloorToInt(24 * Mathf.Sqrt(a)); }
                transform.localScale = new Vector3(0.04f * sidex, 0.04f * sidey, 1.0f);
                float sidex2 = transform.localScale.x / sidex;
                float sidey2 = transform.localScale.y / sidey;
                for (int i = 0; i < m_instance_t.Length; i++)
                {
                    m_instance_t[i] = new Vector3(trans.x - transform.localScale.x / 2.0f + (i % sidex * sidex2), trans.y - transform.localScale.y / 2.0f + (i % sidey * sidey2), m_instance_t[i].z);
                    m_def_p[i] = m_instance_t[i].x;
                }
                break;
        }
        //Debug.Log(x);
    }

    //1回に処理するもの
    void UpdateTask(System.Object arg)
    {
        Range r = (Range)arg;
        int num = r.end - r.begin;
        /*
        Texture tex = m_renderer.m_material.mainTexture;
        for (int i = r.begin; i < r.end; ++i){
            float time = m_instance_time[i] + m_time;
            float e = 0.75f + Mathf.Sin(time * 10.0f) * 0.25f;
            int a = (int)(time * 5.0f) % 16;
            m_instance_color[i] = new Color(1.0f, 1.0f, 1.0f, e);
            m_instance_uv[i] = BatchRendererUtil.ComputeUVOffset(tex, new Rect(32 * (a % 4), 32 * (a / 4), 32, 32));
        }
        */
        switch (player_mode)
        {
            case 0:
                //液状
                //trans = bob.transform.position;
                //for (int i = r.begin; i < r.end; i++){
                //    Vector2 top0 = new Vector2(Mathf.Pow(trans.x - m_instance_t[i].x, 2), Mathf.Pow(trans.y - m_instance_t[i].y, 2));
                //    float top1 = Mathf.Sqrt(top0.x + top0.y);
                //    Vector2 top2 = top0.normalized;
                //    int px = trans.x < m_instance_t[i].x ? -1 : 1;
                //    int py = trans.y < m_instance_t[i].y ? -1 : 1;
                //    if (top1 < 3.0f){
                //        m_instance_t[i] = new Vector3(m_instance_t[i].x + top2.x * 0.04f * px, m_instance_t[i].y + top2.y * 0.04f * py, 0.0f);
                //    }
                //}
                break;
            case 1:
                //滝
                if (SceneManager.GetActiveScene().name == "TitleScene")
                {
                    trans = bob.transform.position;
                    for (int i = r.begin; i < r.end; i++)
                    {
                        m_fall_time[i] += 2.5f * Time.deltaTime;
                        float pointy = m_instance_t[i].y - m_instance_time[i] * m_fall_time[i];
                        float pointx = m_instance_t[i].x;
                        //float pointx = m_instance_t[i].x + ((trans.x - m_instance_t[i].x) * 0.01f);
                        //if (pointy < -5.0f) { pointy = 5.0f; m_fall_time[i] = 0; pointx = m_def_p[i]; }
                        m_instance_t[i] = new Vector3(pointx, pointy, 1.0f);
                    }
                }
                if (SceneManager.GetActiveScene().name == "ClearScene")
                {
                    trans = bob.transform.position;
                    for (int i = r.begin; i < r.end; i++)
                    {
                        m_fall_time[i] += 4.0f * Time.deltaTime;
                        float pointy = m_instance_t[i].y - m_instance_time[i] * m_fall_time[i];
                        float pointx = m_instance_t[i].x;
                        //float pointx = m_instance_t[i].x + ((trans.x - m_instance_t[i].x) * 0.01f);
                        //if (pointy < -5.0f) { pointy = 5.0f; m_fall_time[i] = 0; pointx = m_def_p[i]; }
                        m_instance_t[i] = new Vector3(pointx, pointy, 1.0f);
                    }
                }
                break;
            case 2:
                //固体化
                break;
            default:
                break;
        }
        {
            int reserved_index;
            int reserved_num;
            BatchRenderer.InstanceData data = m_renderer.ReserveInstance(num, out reserved_index, out reserved_num);
            System.Array.Copy(m_instance_t, r.begin, data.translation, reserved_index, reserved_num);
            System.Array.Copy(m_instance_color, r.begin, data.color, reserved_index, reserved_num);
            //System.Array.Copy(m_instance_uv, r.begin, data.uv_offset, reserved_index, reserved_num);
        }
        Interlocked.Decrement(ref m_num_active_tasks);
    }
}
