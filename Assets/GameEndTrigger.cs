using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public delegate void GameEnd();
    public static event GameEnd CompleteState;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndGame();
        }
    }

    void EndGame()
    {
        CompleteState?.Invoke();
        SceneManager.LoadScene("LevelComplete", LoadSceneMode.Additive);
    }
}
