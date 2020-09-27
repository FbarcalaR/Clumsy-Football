using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public Text wonText;
    public Text playAgainText;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public int scoreToWin = 3;

    private bool wonState = false;
    private int player1Score = 0;
    private int player2Score = 0;
    private Vector3 player1InitialPosition;
    private Vector3 player2InitialPosition;

    public void Start()
    {
        player1InitialPosition = player1.transform.position;
        player2InitialPosition = player2.transform.position;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit") && wonState)
        {
            wonState = false;
            playAgainText.enabled = false;
            wonText.enabled = false;

            player1.transform.position = player1InitialPosition;
            player2.transform.position = player2InitialPosition;
            player1Score = 0;
            player2Score = 0;

            player1ScoreText.text = "Player 1: " + player1Score;
            player2ScoreText.text = "Player 2: " + player2Score;

            ResumeGame();
        }
    }

    public void AddPlayerScore(bool player1Scored)
    {
        ball.transform.position = Vector3.zero;
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (player1Scored)
        {
            player1Score++;
            player1ScoreText.text = "Player 1: " + player1Score;
            if(player1Score == scoreToWin)
            {
                PlayerWon(true);
            }
        }
        else
        {
            player2Score++;
            player2ScoreText.text = "Player 2: " + player2Score;
            if (player2Score == scoreToWin)
            {
                PlayerWon(false);
            }
        }
    }

    private void PlayerWon(bool isPlayer1)
    {
        wonState = true;
        string text = isPlayer1 ? "Player 1 Won!" : "Player 2 Won!";
        playAgainText.enabled = true;
        wonText.enabled = true;
        wonText.text = text;
        PauseGame();

    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
