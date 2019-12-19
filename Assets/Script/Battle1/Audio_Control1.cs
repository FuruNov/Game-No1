using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Control1 : MonoBehaviour
{
    public AudioSource BattleAudioSource;
    public Player my_player;
    public Player enemy_player;
    public CountDownTimer timer;
    public Battle_Control1 Battle_Control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Zero_totaltime() || my_player.HP == 0 || enemy_player.HP == 0)
        {
            if (Battle_Control.My_player_win()) 
            {
                BattleAudioSource.pitch = 1.05f;
            }

            if (Battle_Control.Enemy_player_win())
            {
                BattleAudioSource.pitch = 0.95f;
            }
        }
    }

}
