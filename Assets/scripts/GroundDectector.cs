using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public GameOverPanel gameOverPanelScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            if (gameOverPanelScript != null)
            {
                gameOverPanelScript.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverPanelScript not assigned in GroundDetector!");
            }
        }
    }
}
