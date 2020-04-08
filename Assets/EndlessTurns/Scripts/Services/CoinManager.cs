using UnityEngine;
using System;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins { get; private set; }

    public int LevelCoins { get; private set; }

    public static event Action<int> CoinsUpdated = delegate {};

    public static event Action<int> LevelCoinsUpdated = delegate { };

    [SerializeField]
    int INITIAL_COINS = 100;
    const string COINS = "COINS";   // key name to store high score in PlayerPrefs

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        // Initialize coins
        Coins = PlayerPrefs.GetInt(COINS, INITIAL_COINS);
        LevelCoins = 0;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;

//        Debug.Log("Coins: " + Coins + ", was increased by: " + amount);

        // Store new coin value
        PlayerPrefs.SetInt(COINS, Coins);
        AddLevelCoins(amount);
        // Fire event
        CoinsUpdated(Coins);
    }
    public void AddLevelCoins(int amount)
    {

        Debug.Log("Coins: Updated " + Coins);
        LevelCoins += amount;

        Debug.Log("Coins: " + Coins + ", was increased by: " + LevelCoins);

        // Store new coin value
        //PlayerPrefs.SetInt(COINS, Coins);

        // Fire event
      //  LevelCoinsUpdated(LevelCoins);
    }

  
    public void RemoveCoins(int amount)
    {
        Coins -= amount;

//        Debug.Log("Coins: " + Coins + ", was decreased by: " + amount);

        // Store new coin value
        PlayerPrefs.SetInt(COINS, Coins);

        // Fire event
        CoinsUpdated(Coins);
    }
}
