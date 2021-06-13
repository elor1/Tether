using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isOver;
    [SerializeField]
    private Player player;
    private int score = 0;
    private static int highScore = 0;
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject EndGameUI;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource musicSource;

    void Awake()
    {
        isOver = false;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HUD.SetActive(true);
        EndGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
        if (audioSource && !isOver)
        {
            audioSource.Play();
        }

        if (musicSource)
        {
            musicSource.Stop();
        }

        isOver = true;
        Score playerScore = player.GetComponent<Score>();
        if (playerScore)
        {
            score = playerScore.PlayerScore;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        HUD.SetActive(false);
        EndGameUI.SetActive(true);
        scoreText.text = "SCORE: " + score;
        highScoreText.text = "HI-SCORE: " + highScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
