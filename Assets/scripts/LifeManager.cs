using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [Header("Hearts UI")]
    public Image[] hearts;   // yahan 3 hearts assign karo

    [Header("Game Over Panel")]
    public GameOverPanel gameOverPanelScript;  // apna GameOverPanel script assign karo

    private int lives = 3;

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;

            // Heart disable karo
            hearts[lives].enabled = false;

            // Agar lives 0 ho gayi → Game Over
            if (lives <= 0)
            {
                if (gameOverPanelScript != null)
                {
                    gameOverPanelScript.ShowGameOver();
                }
            }
        }
    }
}



