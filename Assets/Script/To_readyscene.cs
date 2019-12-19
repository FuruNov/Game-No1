using UnityEngine;
using UnityEngine.SceneManagement;

public class To_readyscene : MonoBehaviour
{
    //効果音
    public AudioClip Scene_move_sound;    
    AudioSource AudioSource;

    public void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void MoveScene()
    {
        //衝突音を鳴らす
        AudioSource.PlayOneShot(Scene_move_sound);

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("ReadyScene");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveScene();
        }
    }
}
