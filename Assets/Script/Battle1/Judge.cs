using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class Judge : MonoBehaviour
{
    public Player my_player;
    public Player enemy_player;
    public CountDownTimer timer;

    public void MoveScene()
    {
        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("ResultScene");
    }

    public void Update()
    {
        if (my_player.HP == 0 || enemy_player.HP == 0 || timer.Zero_totaltime())
        {
            MoveScene();
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
}
