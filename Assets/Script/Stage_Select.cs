using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Select : MonoBehaviour
{
    //効果音
    public AudioClip Scene_move_sound;
    AudioSource AudioSource;

    //ステージ番号
    public int stage_select_number;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {stage_select_number = 0;}

        if (Input.GetKeyDown(KeyCode.DownArrow)) {stage_select_number = 1;}

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {stage_select_number = 2;}

        if (Input.GetKeyDown(KeyCode.RightArrow)) {stage_select_number = 3;}

        if (Input.GetMouseButtonDown(0)) { MoveScene_1() ;}

        if (Input.GetMouseButtonDown(1)) { MoveScene_2() ;}
    }

    public void MoveScene_1()
    {
        //効果音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("Battle1_Scene");
    }

    public void MoveScene_2()
    {
        //効果音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        SceneManager.LoadScene("Battle2_Scene");
    }
}
