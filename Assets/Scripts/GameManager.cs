using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public PlayerController playerControllerScript;
    public Button restartButton;
    public int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // load the score text
        playerScore = player.GetComponent<PlayerController>().playerScore;
        scoreText.text = "Score: " + playerScore;

        // if the game is over, disactive the button and show the game over text
        if (CheckGameOver())
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    // chech if the game is over 
    bool CheckGameOver()
    {
        return player.GetComponent<PlayerController>().gameOver;
    }

    // reload the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
