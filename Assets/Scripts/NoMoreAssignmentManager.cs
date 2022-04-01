using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoMoreAssignmentManager : MonoBehaviour
{
    public PlayerController player;
    public Button playButton;
    public TMP_Text textScore;
    public TMP_Text textSumScore;
    public TMP_Text textHighScore;
    public TMP_Text textHighScoreBoard;

    public GameObject gameoverPanel;
    public GameObject settingPanel;
    bool playerPreviousState = false;
    int high_score = 0;
    private int score; 
    float timer = 0.0f;

    public UnityEvent onGameFinished;
    public UnityEvent onNewHighScore;

    public SoundManager soundManager; 

    // Start is called before the first frame update
    void Start()
    {
        high_score = LoadScoreFromDisk();
        textHighScore.text = "Your Highest Record - " + high_score.ToString();
        textHighScoreBoard.text = "1. ME - " + high_score.ToString();
        soundManager.LoadBGM_SFX();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDead) {
            if (!playButton.IsActive() && !settingPanel.active) {
                player.Player_running();

                ScoreCounting();
                
            }
        }
    }

    public void ScoreCounting() {
        timer += Time.deltaTime;
        score = (int)(timer % 60);
        textScore.text = "Your Score - " + score.ToString();
        textSumScore.text = "Your Score - " + score.ToString();
        if (score > high_score) { // New highscore
            onNewHighScore.Invoke();
            SaveScoreToDisk(score);
            textHighScore.text = "You got a new Record - " + score.ToString();
            textHighScoreBoard.text = "1. ME - " + score.ToString();
        }
    }

    public void Restart() {
        SceneManager.LoadScene("Level01");
    }

    public static void DumpToConsole(object obj)
    {
        var output = JsonUtility.ToJson(obj, true);
        Debug.Log(output);
    }

    public void SaveScoreToDisk(int score) {
        PlayerPrefs.SetInt("HIGH_SCORE", score);
    }

    public int LoadScoreFromDisk() {
        if (!PlayerPrefs.HasKey("HIGH_SCORE")) {
            return 0;
        }
        return PlayerPrefs.GetInt("HIGH_SCORE");
    }

}
