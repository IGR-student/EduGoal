// using System.Collections;
// using System.Collections.Generic;
//using System.Media;
//using System.Runtime.Hosting;
//using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private int total;
    public bool chance = false;
    public Text scoreText;
    public GameObject playButton;
    public DarkWizard player;
    //public Quizpop quizpop;
    //public Player player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        //total = 0;
        scoreText.text = score.ToString();
        //scoreText.text = total.ToString();

        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i=0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncScore()
    {
        // Debug.Log("GAME OVER");
        //gameOver.SetActive(true)
        score++;
        //total += score;
        scoreText.text = score.ToString();
        //scoreText.text = total.ToString();
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        chance = true;
        Pause();
        //quizpop.ShowCanvas();
    }
    /*
    public void GrantChance()
    {
        if (chance == 1)
        {
            quizpop.CheckChance();
        }
    }*/
}
