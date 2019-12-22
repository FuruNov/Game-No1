using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Text PauseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            PauseText.text = string.Format("Pause");
            Time.timeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseText.text = string.Format("");
            Time.timeScale = 1.0f;
        }
    }
}
