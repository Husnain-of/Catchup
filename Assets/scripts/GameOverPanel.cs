using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [Header("Assign your GameOver UI Panel here")]
    public GameObject gameOverPanel;

    [Header("Main Menu Scene Name")]
    public string mainMenuSceneName = "Main Menu"; // yahan apna exact scene ka naam likho

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // start pe hide
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over Panel Shown");
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f; // pause game
        Debug.Log("Game over trying to show ads...");

        AdsManager.Instance.ShowInterstitialAd();
        
    }

    public void RestartGame()
    {
        Debug.Log("inside Restarting Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restarted");
    }

    public void GoToHome()
    {
        Debug.Log("inside Returning to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
        Debug.Log("Returned to Main Menu");
    }
}







