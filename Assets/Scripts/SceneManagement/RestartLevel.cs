using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            RestartCurrentLevel();
        }
    }

    void RestartCurrentLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
