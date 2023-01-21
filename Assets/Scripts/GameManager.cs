using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private float currentScore;
    [SerializeField] private GameObject scoreText;

    private int tickAmount;

    void Start()
    {
        playerReference.GetComponent<CharacterMovement>().Init();
        PickupTrigger.IncreaseScore += UpdateScore;

        tickAmount = -1;
        UpdateScore(35);
        StartCoroutine(TickScore());
    }

    void Update()
    {
        playerReference.GetComponent<CharacterMovement>().Run();

    }

    void UpdateScore(int score)
    {
        currentScore += score;
        Debug.Log(currentScore);
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
        Debug.Log("Game Over!");
    }
}
