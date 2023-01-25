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

    public delegate void GameEnd();
    public static event GameEnd FailedState;

    void Start()
    {
        playerReference.GetComponent<CharacterMovement>().Init();
        PickupTrigger.IncreaseScore += UpdateScore;
        GameEndTrigger.CompleteState += GameComplete;

        tickAmount = -1;
        collectedTally = 0;
        UpdateScore(35);
        StartCoroutine(TickScore());
    }

    void Update()
    {
        playerReference.GetComponent<CharacterMovement>().Run();

    }

    void UpdateScore(int score)
    {
        collectedTally++;
        currentScore += score;
        TMP_Text myText = scoreText.GetComponentInChildren<TMP_Text>();
        myText.text = "O2 Remaining: " + currentScore.ToString();
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

        GameOver();
        yield return null;
    }

    private void GameOver()
    {
        FailedState?.Invoke();
        Debug.Log("Game Over!");
        SceneManager.LoadScene("LevelFailed", LoadSceneMode.Additive);
    }

    private void GameComplete()
    {
        tickAmount = 0;
    }
}
