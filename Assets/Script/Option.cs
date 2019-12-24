using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class Option : MonoBehaviour
{
=======
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Text PauseText;

>>>>>>> feature/Battle_Option
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
=======
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
>>>>>>> feature/Battle_Option
    }
}
