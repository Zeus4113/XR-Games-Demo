using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevel : MonoBehaviour
{

    public delegate void PauseLevelDelegate(bool isTrue);
    public static PauseLevelDelegate gamePaused;

    public void Update()
    {
        if (Input.GetButtonDown("Pause") && !SceneManager.GetSceneByName("PauseMenu").isLoaded)
        {
            PauseCurrentLevel(true);
        }

    }

    public void PauseCurrentLevel(bool isTrue)
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        gamePaused?.Invoke(isTrue);
    }

    public void ResumeCurrentLevel(bool isTrue)
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        gamePaused?.Invoke(isTrue);
    }
}
