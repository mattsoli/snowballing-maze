using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public UIController ui;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        this.ui.ActiveWinPanel(false);
        this.ui.ActiveGameOverPanel(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.hasArrived) // player has arrived to the finish line
        {
            this.Win();
        }

        if (this.player.isDead) // player is dead
        {
            this.GameOver();
        }
    }

    void Win()
    {
        this.SetScoreText();
        // this.player.enabled = false; // for stop the input controller on the player
        if (this.player.score != 3)
        {
            this.ui.restartText.text = "Try Again";
        }
        else
        {
            this.ui.restartText.text = "Play Again";
        }
        Time.timeScale = 0;
        this.ui.ActiveWinPanel(true);
    }

    void GameOver()
    {
        Time.timeScale = 0;
        this.ui.ActiveGameOverPanel(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void SetScoreText()
    {
        int score = this.player.score;

        for (int i = 0; i < score; i++)
        {
            this.ui.winPanelImages[i].SetActive(score > i);
        }
    }

}
