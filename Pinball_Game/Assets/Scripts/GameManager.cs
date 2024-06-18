using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Ball, highScoreText, scoreText, startText, restartText, quitText;
    // restart, quit, start are going to be hot keys not ui buttons

    int score, highScore;

    [SerializeField]
    Vector3 startPos;

    public int multiplier;

    bool canPlay;
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        Time.timeScale = 1.0f;
        score = 0;
        multiplier = 1;
/*
        highScore = PlayerPrefs.HasKey("Highscore") ? PlayerPrefs.GetInt("HighScore") : 0;
        highScoreText.GetComponent<Text>().text = "Highscore :" + highScore;*/
        
        canPlay = false;
    }

    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        //scoreText.GetComponent<Text>().text = "Score :" + score;

        if (scoreText == null)
        {
            Debug.Log("ScoreText returned Null");
        }
        scoreText.GetComponent<Text>();
        if (GetComponent<Text>() == null)
        {
            Debug.Log("Can't find text component");
        }
        scoreText.GetComponent<Text>().text = "Score" + score;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStart(); 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameQuit();
        }

        if (Input.GetKey(KeyCode.R)) { GameRestart(); }
    }



    public void GameStart()
    {
        
        /*highScoreText.SetActive(false);*/
        startText.SetActive(false);
        scoreText.SetActive(true);
        Instantiate(Ball,startPos,Quaternion.identity);

    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
