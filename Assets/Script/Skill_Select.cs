using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_Select : MonoBehaviour
{
    //効果音
    public AudioClip Scene_move_sound;
    AudioSource AudioSource;

    //スキル番号
    public static int skill_select_number = -1;

    //スキル選択フラグ
    private bool[] skill_select_frag;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        //スキル選択をリセット
        skill_select_number = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            skill_select_number = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            skill_select_number = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            skill_select_number = 2;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            skill_select_number = 3;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MoveScene();
        }
    }

    public void MoveScene()
    {
        //効果音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("StageSelectScene");
    }

}
