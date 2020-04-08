using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour {

   

    public Text score;
    public Text bestScore;
    public Text gold;
    public Image muteButton;
    public Image unMuteButton;
    public Image replayButton;

    public GameObject LevelComplete;
    public PlayerController playerController;

    public GroundController groundController;

    // Use this for initialization
    void Start () {
        
        ScoreManager.Instance.Reset();
        muteButton.enabled = false;
        unMuteButton.enabled = false;
        replayButton.enabled = false;
        LevelComplete.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        score.text = ScoreManager.Instance.Score.ToString();
        bestScore.text = ScoreManager.Instance.HighScore.ToString();
        gold.text = CoinManager.Instance.Coins.ToString();
        if (LevelManager.Inst.isLevelComplete) return;
        if (playerController.gameOver)
        {
            Invoke("EnableButton", 1.5f);
        }
	}


    public void SoundClick()
    {
        if (SoundManager.Instance.IsMuted())
        {
            unMuteButton.enabled = true;
            muteButton.enabled = false;
            SoundManager.Instance.ToggleMute();
        }
        else
        {
            unMuteButton.enabled = false;
            muteButton.enabled = true;
            SoundManager.Instance.ToggleMute();
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.hitButton);
    }

    public void ReplayButton()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.hitButton);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnableLevelCompletePanel()
    {

        LevelComplete.SetActive(true);
        
    }

    public void PlayNextLevel()
    {

        // groundController = FindObjectOfType<GroundController>();
        //LevelManager.Inst.level.LevelNumber += 1;
        //  
        CoinManager.Instance.Reset();
        playerController.levelComplete = false;
        FindObjectOfType<PlayerController>().StartPlayer();
        LevelComplete.SetActive(false);
       
    }

    void EnableButton()
    {
        replayButton.enabled = true;
        if (SoundManager.Instance.IsMuted())
        {
            muteButton.enabled = true;
            unMuteButton.enabled = false;
        }
        else
        {
            muteButton.enabled = false;
            unMuteButton.enabled = true;
        }
    }
}
