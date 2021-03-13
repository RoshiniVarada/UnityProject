using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    [Header("Gameplay")]
    public Player player;

    [Header("UI")]
    public Text coinsText;
    public Text messageText;

    public GameObject button;
  

    private bool gameOver;
    private bool restart;
    // private float resetTimer = 3f;

    private int coins = 0;
    private int Coins
    {
        set
        {
            coins = value;
            coinsText.text = "Coins: " + coins;
        }
        get
        {
            return coins;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player.OnCoinCollected += OnCoinCollected;
        player.OnWin += OnWin;
        player.OnLose += OnLose;
        Coins = 0;
        messageText.text = "";
        button.SetActive(false);
        restart = false;
    }

    // Update is called once per frame

    public void restartClick()
    {
        if(gameOver)
        restart = !restart;
    }
    void Update()
    {
        if (gameOver && restart)
        {
           // resetTimer -= Time.deltaTime;
        ////    if(resetTimer <= 0.0f)
           // {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          //  }
        }
    }

    void OnCoinCollected()
    {
        Coins++;
    }
    void OnWin()
    {
        messageText.text = "You Win!";
        gameOver = true;
        button.SetActive(true);
    }
    void OnLose()
    {
        messageText.text = "Game Over!";
        gameOver = true;
        button.SetActive(true);
    }
}
