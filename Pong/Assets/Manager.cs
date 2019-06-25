using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public GameObject ball;

    private int player1Score;
    private int player2Score;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public GameObject player1Win;
    public GameObject player2Win;

    public GameObject playAgain;
    public GameObject mainMenu;

    public GameObject paddle1;
    public GameObject paddle2;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player1Score >= 7)
        {
            Time.timeScale = 0;
            player1Win.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            Destroy(GameObject.Find("Ball"));
        }

        if (player2Score >= 7)
        {
            Time.timeScale = 0;
            player2Win.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            Destroy(GameObject.Find("Ball"));
        }

        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();

    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ResetGame()
    {

        Time.timeScale = 1;

        player1Score = 0;
        player2Score = 0;

        player2Win.SetActive(false);
        player1Win.SetActive(false);
        playAgain.SetActive(false);
        mainMenu.SetActive(false);

        paddle1.transform.position = new Vector3(-17.5f, 0, 0);
        paddle2.transform.position = new Vector3(17.5f, 0, 0);

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    public void ResetPaddles()
    {
        paddle1.transform.position = new Vector3(-17.5f, 0, 0);
        paddle2.transform.position = new Vector3(17.5f, 0, 0);
    }

    public void addPlayer1Score()
    {
        player1Score += 1;
        Debug.Log("1: " + player1Score.ToString());
    }

    public void addPlayer2Score()
    {
        player2Score += 1;
        Debug.Log("2: " + player2Score.ToString());
    }

    private void reEnableBall()
    {
        Debug.Log("adhasdhas");
        
    }
}
