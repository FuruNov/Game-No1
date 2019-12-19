using UnityEngine;
using UnityEngine.SceneManagement;

public class To_battlescene : MonoBehaviour
{
    public void MoveScene()
    {
        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("BattleScene");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveScene();
        }
    }
}
