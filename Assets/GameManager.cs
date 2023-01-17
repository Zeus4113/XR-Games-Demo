using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private float currentScore;

    void Start()
    {
        playerReference.GetComponent<CharacterMovement>().Init();
        PickupTrigger.IncreaseScore += UpdateScore;
    }

    void Update()
    {
        playerReference.GetComponent<CharacterMovement>().Run();
    }

    void UpdateScore(int score)
    {
        currentScore += score;
        Debug.Log(currentScore);
    }

    void ResetScore()
    {
        currentScore = 0;
    }
}
