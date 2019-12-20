using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Player のステータス
    public int HP;
    public int max_HP;
    public float size_scale = 1;
    public float mass_scale = 1;
    public float LightShift_speed_scale = 2;
    public float RightShift_size_scale = 2;
    public float RightShift_mass_scale = 3;
    public float affect_timescale = 3;
    public int add_collide_HP = 10;

    //必殺ゲージ
    public float deadly_gauge = 0;
    public float charge_deadly_gauge = 1;
    public float max_deadly_gauge = 10;

    //スコアの定義
    public Text statusText; //Text用変数
    
    //ジャストアクション判定//

    //マイサブユニット
    public Partner myPartner;

    //物理系
    public float move_speed = 10f;    
    public GameObject mygameObject;
    public GameObject collide_Enter_effect;
    public CountDownTimer timer;
    public Rigidbody2D rb2d;

    //効果音
    public AudioClip collide_sound;
    public AudioClip enemy_collide_sound;
    public AudioClip Item_get_sound;
    public AudioClip deadly_skill_sound;
    AudioSource AudioSource;

    // Start is called before the first frame update
    public void Start()
    {
        //最大HPの定義
        max_HP = HP;

        //Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();

        //サイズ,質量の倍率を変える
        transform.localScale *= size_scale;
        rb2d.mass *= mass_scale;

        SetScore();   //初期スコアを代入して表示

        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        control_move();

        //右Shiftキーが押されたら
        if (Input.GetKeyDown(KeyCode.RightShift) && !timer.Zero_totaltime() && HP > 0)
        {
            rb2d.velocity = new Vector2(0, 0);

            //2倍の大きさ、重さになる
            transform.localScale *= RightShift_size_scale;

            rb2d.mass *= RightShift_mass_scale;

            Time.timeScale /= affect_timescale;

            //必殺ゲージ減少
            if(deadly_gauge > 0)
            {
                deadly_gauge -= charge_deadly_gauge;
                SetScore();
            }            

/*            if (just_action_frag == true)
            {
                just_action();
                Debug.Log("ジャストアクション実行");
            }
*/
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            rb2d.velocity = new Vector2(0, 0);
        }

        //右Shiftキーが離されたら
        if (Input.GetKeyUp(KeyCode.RightShift) && !timer.Zero_totaltime() && HP > 0)
        {
            //半分の大きさ、重さになる
            transform.localScale /= RightShift_size_scale;

            rb2d.mass /= RightShift_mass_scale;

            Time.timeScale *= affect_timescale;
        }        
        
    }

    //衝突侵入判定
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {        
        //エフェクトの生成
//      Instantiate(collide_Enter_effect, collision.transform.position, Quaternion.identity);

        //必殺ゲージ蓄積
        if (collision.gameObject.tag != "Wall" && deadly_gauge < max_deadly_gauge)
        {
            deadly_gauge += charge_deadly_gauge;

            if (deadly_gauge > max_deadly_gauge)
            {
                deadly_gauge = max_deadly_gauge;
            }

            SetScore();
        }            

        if (
            collision.gameObject.tag != "Wall" &&
           !(
          (mygameObject.tag == "Player" && collision.gameObject.tag == "Enemy_Partner") &&
          (mygameObject.tag == "Enemy_Player" && collision.gameObject.tag == "Partner")
            )
          )

        {
            //衝突音を鳴らす
            AudioSource.PlayOneShot(collide_sound);
        }        


        //スコアの追加
        if (mygameObject.tag == "Player" && collision.gameObject.tag == "Enemy_Partner")
        {

            //衝突音を鳴らす
            AudioSource.PlayOneShot(enemy_collide_sound);

            HP -= add_collide_HP;

            if(HP < 0) { HP = 0; }

            SetScore();
        }

        if (mygameObject.tag == "Enemy_Player" && collision.gameObject.tag == "Partner")
        {

            //衝突音を鳴らす
            AudioSource.PlayOneShot(enemy_collide_sound);

            HP -= add_collide_HP;

            if (HP < 0) { HP = 0; }

            SetScore();
        }
        
        //
        if(collision.gameObject.tag == "size_minus_item")
        {            
            if(size_scale <= 1.2 && size_scale >= 0.8) 
            {
                size_scale -= 0.1f;
                transform.localScale *= size_scale;
            }

            //アイテム獲得音を鳴らす
            AudioSource.PlayOneShot(Item_get_sound);
            SetScore();
        }

        if (collision.gameObject.tag == "weight_plus_item" && mass_scale <= 99)
        {            
            if(mass_scale >= 1 && mass_scale <= 10)
            {
                mass_scale++;
                rb2d.mass *= mass_scale;
            }

            //アイテム獲得音を鳴らす
            AudioSource.PlayOneShot(Item_get_sound);
            SetScore();
        }

        if (collision.gameObject.tag == "speed_plus_item" && LightShift_speed_scale <= 5)
        {
            LightShift_speed_scale ++;

            //アイテム獲得音を鳴らす
            AudioSource.PlayOneShot(Item_get_sound);
            SetScore();
        }
    }

    public void SetScore()
    {
        statusText.text  = string.Format("HP:{0}/{1}\n"      , HP                          , max_HP);
        statusText.text += string.Format("Gauge:{0}/{1}\n\n" , deadly_gauge                , max_deadly_gauge);
        statusText.text += string.Format("Defense:{0}\n"     , 100 / add_collide_HP);
        statusText.text += string.Format("Size:{0:F0}\n"     , size_scale * 10);
        statusText.text += string.Format("Mass:{0:F0}\n"     , mass_scale * 10);
        statusText.text += string.Format("Speed:{0:F0}"      , LightShift_speed_scale * 10);        
    }

    public virtual void control_move()
    {
        //左キーが押されたら
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-move_speed, 0);

            //左を向く
            if (transform.localScale.x > 0)

                transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z);

            speed_double();
        }

        //右キーが押されたら
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(move_speed, 0);

            //右を向く
            if (transform.localScale.x < 0)

                transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z);

            speed_double();
        }

        //上キーが押されたら
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //上に移動
            rb2d.velocity = new Vector2(0, move_speed);
            speed_double();
        }

        //下キーが押されたら
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //下に移動
            rb2d.velocity = new Vector2(0, -move_speed);
            speed_double();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //左上に移動
            rb2d.velocity = new Vector2(-move_speed / Mathf.Sqrt(2), move_speed / Mathf.Sqrt(2));
            speed_double();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            //右上に移動
            rb2d.velocity = new Vector2(move_speed / Mathf.Sqrt(2), move_speed / Mathf.Sqrt(2));
            speed_double();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //左下に移動
            rb2d.velocity = new Vector2(-move_speed / Mathf.Sqrt(2), -move_speed / Mathf.Sqrt(2));
            speed_double();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            //右下に移動
            rb2d.velocity = new Vector2(move_speed / Mathf.Sqrt(2), -move_speed / Mathf.Sqrt(2));
            speed_double();
        }
    }
/*    
    public void just_action()
    {
        if(HP > 0)
        {
            HP += 10;
        }            
            SetScore();
    }
*/

    public void speed_double()
    {
        //左Shiftキーが押されたら
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //速度を倍加する
            rb2d.velocity = new Vector2(LightShift_speed_scale * rb2d.velocity.x , LightShift_speed_scale * rb2d.velocity.y);
        }
    }


}