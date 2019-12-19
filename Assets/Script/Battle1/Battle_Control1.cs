using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle_Control1 : MonoBehaviour
{
    public Player my_player;
    public Player enemy_player;
    public Text Resulttext;
    public CountDownTimer timer;

    //効果音
    public AudioClip Scene_move_sound;
    public AudioClip my_deadly_skill_sound;
    public AudioClip enemy_deadly_skill_sound;
    AudioSource AudioSource;

    public void Start()
    {
        Time.timeScale = 1;

        AudioSource = GetComponent<AudioSource>();

        Player_Select();
        EnemyPlayer_Select();
        Skill_power_Select();
        StartCoroutine(Battle_Start()); 
    }    

    public void Update()
    {
        if (timer.Zero_totaltime() || my_player.HP == 0 || enemy_player.HP == 0 )
        {
            DisplayResult();
            Time.timeScale *= 0f;
        }

        if (Input.GetMouseButtonDown(0) && (timer.Zero_totaltime() || my_player.HP <= 0 || enemy_player.HP <= 0))
        {
            global::Player_Select.MyPlayer_number = 0;
            MoveScene();
        }

        //必殺スキル発動
        if (
            Input.GetKeyUp(KeyCode.Return) 
            && my_player.deadly_gauge == my_player.max_deadly_gauge
            && !timer.Zero_totaltime()
            && my_player.HP > 0
           )
        {
            switch(Skill_Select.skill_select_number)
            {
                case 0:
                    enemy_player.HP -= 20;
                    my_player.mass_scale *= 1.2f;
                    break;

                case 1:
                    my_player.HP += 10;
                    break;

                case 2:
                    enemy_player.HP -= 10;
                    my_player.HP += 5;
                    break;

                default:
                    my_player.HP += 10;                                        
                    break;
            }

            my_player.deadly_gauge -= my_player.max_deadly_gauge;
            my_player.SetScore();
            enemy_player.SetScore();

            //効果音を鳴らす
            AudioSource.PlayOneShot(my_deadly_skill_sound);

            Debug.Log("必殺スキル発動!!");

        }

        //相手の必殺スキル発動
        if(enemy_player.deadly_gauge == enemy_player.max_deadly_gauge 
            && !timer.Zero_totaltime()
            && enemy_player.HP > 0)
        {
            my_player.HP -= 10;
            enemy_player.deadly_gauge -= enemy_player.max_deadly_gauge;
            my_player.SetScore();
            enemy_player.SetScore();

            //効果音を鳴らす
            AudioSource.PlayOneShot(enemy_deadly_skill_sound);

            Debug.Log("相手が必殺スキル発動!!");
        }
    }

    public void DisplayResult()
    {
        if (My_player_win())
        {
            Resulttext.text = string.Format("You Win!!");
        }

        if (Enemy_player_win())
        {
            Resulttext.text = string.Format("You Lose!!");
        }

        if (Draw())
        {
            Resulttext.text = string.Format("Draw!!");
        }
    }

    public bool My_player_win()
    {
        return my_player.HP > enemy_player.HP;
    }

    public bool Enemy_player_win()
    {
        return enemy_player.HP > my_player.HP;
    }

    public bool Draw()
    {
        return my_player.HP == enemy_player.HP;
    }

    public void MoveScene()
    {
        //衝突音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("TitleScene");
    }

    public IEnumerator Battle_Start()
    {
        Resulttext.text = string.Format("3");
        yield return new WaitForSeconds(0.5f);

        Resulttext.text = string.Format("2");
        yield return new WaitForSeconds(0.5f);

        Resulttext.text = string.Format("1");
        yield return new WaitForSeconds(0.5f);

        Resulttext.text = string.Format("Start!!");        
        yield return new WaitForSeconds(0.5f);

        Resulttext.text = null;
    }

    public void Player_Select()
    {
        switch (global::Player_Select.MyPlayer_number)
        {
            case 0:
                //ステータスの設定
                my_player.HP = 100;
                my_player.size_scale = 0.8f;
                my_player.mass_scale = 0.9f;
                my_player.LightShift_speed_scale = 4;
                my_player.add_collide_HP = 15;

                Debug.Log("プレイヤー0が選択されました");
                break;

            case 1:
                my_player.HP = 150;
                my_player.size_scale = 0.9f;
                my_player.mass_scale = 1f;
                my_player.LightShift_speed_scale = 3.5f;
                my_player.add_collide_HP = 12;

                Debug.Log("プレイヤー1が選択されました");
                break;

            case 2:
                my_player.HP = 200;
                my_player.size_scale = 1f;
                my_player.mass_scale = 1.1f;
                my_player.LightShift_speed_scale = 3;
                my_player.add_collide_HP = 10;

                Debug.Log("プレイヤー2が選択されました");
                break;

            default:
                my_player.HP = Random.Range(100,300);
                my_player.size_scale = Random.Range(1f, 2f);
                my_player.mass_scale = Random.Range(1f, 5f);
                my_player.LightShift_speed_scale = Random.Range(2f, 5f);
                my_player.add_collide_HP = Random.Range(5, 15);

                Debug.Log("プレイヤー3が選択されました");
                break;

        }

        my_player.max_HP = my_player.HP;
        my_player.SetScore();
    }

    public void EnemyPlayer_Select()
    {
        switch (global::Player_Select.Enemy_number)
        {
            case 0:
                enemy_player.HP = 100;
                Debug.Log("相手プレイヤー0が選択されました");
                break;

            case 1:
                enemy_player.HP = 150;
                Debug.Log("相手プレイヤー1が選択されました");
                break;

            case 2:
                enemy_player.HP = 200;
                Debug.Log("相手プレイヤー2が選択されました");
                break;

            case 3:
                enemy_player.HP = 250;
                Debug.Log("相手プレイヤー3が選択されました");
                break;

        }

        enemy_player.max_HP = enemy_player.HP;
        enemy_player.SetScore();

    }

    public void Skill_power_Select()
    {
        switch (Skill_Select.skill_select_number)
        {
            case 0:
                //アタックタイプ
                my_player.mass_scale *= 5;
                my_player.LightShift_speed_scale *= 1.5f;
                my_player.size_scale *= 2;
                my_player.SetScore();
                Debug.Log("アタックタイプが選択されました");
                break;

            case 1:
                //ディフェンスタイプ
                my_player.size_scale /= 1.5f;
                my_player.mass_scale /= 2;
                my_player.add_collide_HP /= 2;
                my_player.LightShift_speed_scale /= 1.5f;
                my_player.SetScore();
                Debug.Log("ディフェンスタイプが選択されました");
                break;

            case 2:
                //テクニックタイプ
                my_player.RightShift_mass_scale *= 2;
                my_player.RightShift_size_scale *= 2;
                my_player.add_collide_HP += 5;
                my_player.charge_deadly_gauge *= 2;
                my_player.SetScore();
                Debug.Log("テクニックタイプが選択されました");
                break;

            default:
                //バランスタイプ
                my_player.SetScore();
                Debug.Log("バランスタイプが選択されました");
                break;
        }
    }

}
