using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Ye function Start Button se call hoga
    public void PlayGame()
    {
        // "Game" ki jagah apna game scene ka exact naam likhna
        SceneManager.LoadScene("Game");
    }

    // Agar Exit button bhi chahiye
    public void QuitGame()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();
    }
}

