using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Select : MonoBehaviour
{
    public static int MyPlayer_number;
    public static int Enemy_number;

    //効果音
    public AudioClip Scene_move_sound;
    AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MyPlayer_number = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MyPlayer_number = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MyPlayer_number = 2;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MyPlayer_number = 3;
        }


        if (Input.GetMouseButtonDown(0))
        {
//          MyPlayer_number = Random.Range(0, 3);
            Enemy_number = Random.Range(0, 3);
            MoveScene();
        }
    }

    public void MoveScene()
    {
        //効果音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("SkillSelectScene");
    }
}
