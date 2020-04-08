using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Inst;
    public int LastLevelPlayed { get; private set; }

    private const string LASTLEVELPLAYED= "LASTLEVELPLAYED";
    public bool isLevelComplete = false;

    public Level level;


    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (Inst)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        };

        LastLevelPlayed = PlayerPrefs.GetInt(LASTLEVELPLAYED, 0);
        if (LastLevelPlayed == 0)
        {
            SetLevelData();
        }
        else
        {
            UpdateLevelData(LastLevelPlayed);
        }
    }


    public void Init()
    {
        isLevelComplete = false;
        CoinManager.Instance.Reset();
    }
    public void SetLevelData()
    {
        PlayerPrefs.SetInt(LASTLEVELPLAYED, 1);
        LevelManager.Inst.level.LevelNumber =   1;
    }

    public int GetLastPlayedNumber()
    {
        return LastLevelPlayed = PlayerPrefs.GetInt(LASTLEVELPLAYED, 0);
    }

    public void UpdateLevelData(int level)
    {
        PlayerPrefs.SetInt(LASTLEVELPLAYED, level );
        LevelManager.Inst.level.LevelNumber = level ;
    }
}



[System.Serializable]
public class Level
{
    public int LevelToBeCheck;
    public int LevelNumber;

    public List<LevelDetails> levelDetails = new List<LevelDetails>();
}

[System.Serializable]
public class LevelDetails
    {
       
        public int NumberOfTurns;
        public int NumberOfCoins;
        public bool isBaseResize;
        public float BaseDecrement;
        public bool isBallResize;
        public float BallIncreament;
        public float BallSpeed;

      
    }
