using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    [Header("Gameplay")]
    public Player player;

    [Header("UI")]
    public Text coinsText;

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
        Coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCoinCollected()
    {
        Coins++;
    }
}
