using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private float currentScore;
    [SerializeField] private GameObject scoreText;

    private int tickAmount;
    private int collectedTally;
    private bool m_gameOver;

    public delegate void GameEnd(bool isTrue);
    public static event GameEnd FailedState;

    void Start()
    {
        playerReference.GetComponent<CharacterMovement>().Init();


        PickupTrigger.IncreaseScore += UpdateScore;
        GameEndTrigger.CompleteState += PauseTimer;
        PauseLevel.gamePaused += PauseTimer;

        m_gameOver = false;
        tickAmount = -1;
        collectedTally = 0;
        UpdateScore(15);
        StartCoroutine(TickScore());
    }

    void Update()
    {
        playerReference.GetComponent<CharacterMovement>().Run();

    }

    void UpdateScore(int score)
    {
        if (!m_gameOver)
        {
            collectedTally++;
            currentScore += score;
            TMP_Text myText = scoreText.GetComponentInChildren<TMP_Text>();
            myText.text = "O2 Remaining: " + currentScore.ToString();
        }
    }

    void ResetScore()
    {
        currentScore = 0;
    }

    private IEnumerator TickScore()
    {
        while(currentScore > 0)
        {
            UpdateScore(tickAmount);
            yield return new WaitForSeconds(0.25f);
        }

        GameOver(true);
        yield return null;
    }

    private void GameOver(bool isTrue)
    {
        m_gameOver = isTrue;
        FailedState?.Invoke(isTrue);
        Debug.Log("Game Over!");
        SceneManager.LoadScene("LevelFailed", LoadSceneMode.Additive);
    }

    private void PauseTimer(bool isTrue)
    {
        if (isTrue)
        {
            tickAmount = 0;
        }
        else if (!isTrue)
        {
            tickAmount = -1;
        }
    }
}
