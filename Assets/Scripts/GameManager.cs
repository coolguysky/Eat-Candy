using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;
    int lives = 3;
    bool gameOver = false;
    public Text scoreText;
    public GameObject liveHolder;
    public GameObject gameOverPanel;
    public AudioSource eatCandy;
    public AudioSource takeDamage;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            eatCandy.Play();
            scoreText.text = score.ToString();
        }
        
    }
    public void DecrementLives()
    {
        if(lives > 0)
        {
            lives--;
            takeDamage.Play();
            liveHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if(lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
