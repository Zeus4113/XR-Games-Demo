using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_playerReference;
    [SerializeField] private GameObject m_environmentManager;
    [SerializeField] private float m_currentScore;
    [SerializeField] private GameObject m_scoreText;
    [SerializeField] private TMP_Text m_myText;


    private int m_tickAmount;
    private bool m_gameOver;

    public delegate void GameEnd(bool isTrue);
    public static event GameEnd FailedState;

    void Start()
    {
        Init();
    }
    public void Init()
    {
        // Init Chain
        m_playerReference.GetComponent<CharacterMovement>().Init();
        m_environmentManager.GetComponent<EnvironmentManager>().Init();

        // Event Binding
        PickupTrigger.IncreaseScore += UpdateScore;
        GameEndTrigger.CompleteState += PauseTimer;
        PauseLevel.gamePaused += PauseTimer;

        // Value Assignment
        m_myText = m_scoreText.GetComponentInChildren<TMP_Text>();
        m_currentScore = 0;
        m_gameOver = false;
        m_tickAmount = -1;

        UpdateScore(15);
        StartCoroutine(TickScore());
    }

    void Update()
    {
        m_playerReference.GetComponent<CharacterMovement>().Run();

    }

    void UpdateScore(int score)
    {
        if (!m_gameOver)
        {
            m_currentScore += score;
            m_myText.text = "O2 Remaining: " + m_currentScore.ToString();
        }
    }

    private IEnumerator TickScore()
    {
        while(m_currentScore > 0)
        {
            UpdateScore(m_tickAmount);
            yield return new WaitForSeconds(0.25f);
        }

        GameOver(true);
        yield return null;
    }

    private void GameOver(bool isTrue)
    {
        StopCoroutine(TickScore());
        m_gameOver = isTrue;
        FailedState?.Invoke(isTrue);
        Debug.Log("Game Over!");
        SceneManager.LoadScene("LevelFailed", LoadSceneMode.Additive);
    }

    private void PauseTimer(bool isTrue)
    {
        if (isTrue)
        {
            m_tickAmount = 0;
        }
        else if (!isTrue)
        {
            m_tickAmount = -1;
        }
    }
}
