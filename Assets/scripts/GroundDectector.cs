// using UnityEngine;

// public class GroundDetector : MonoBehaviour
// {
//     public GameOverPanel gameOverPanelScript;

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             Destroy(collision.gameObject);

//             if (gameOverPanelScript != null)
//             {
//                 gameOverPanelScript.ShowGameOver();
//             }
//             else
//             {
//                 Debug.LogError("GameOverPanelScript not assigned in GroundDetector!");
//             }
//         }
//     }
// }






using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public GameOverPanel gameOverPanelScript;

    [Header("Sounds")]
    public AudioClip outSound;   // ✅ Out sound clip
    public LifeManager lifeManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            if (lifeManager != null)
            {
                lifeManager.LoseLife();
            }
            // ✅ Out sound play karo
            if (outSound != null)
                AudioSource.PlayClipAtPoint(outSound, Camera.main.transform.position);

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







// using UnityEngine;

// public class GroundDetector : MonoBehaviour
// {
//     public GameOverPanel gameOverPanelScript;

//     [Header("Sounds")]
//     public AudioClip outSound;   // Ground touch sound

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // ✅ Out sound bajao
//             if (outSound != null)
//                 AudioSource.PlayClipAtPoint(outSound, Camera.main.transform.position);

//             // ✅ Ball ko destroy karo
//             Destroy(collision.gameObject);

//             // ✅ Game Over panel show karo
//             if (gameOverPanelScript != null)
//             {
//                 Debug.Log("👉 GameOverPanel ShowGameOver() called");
//                 gameOverPanelScript.ShowGameOver();
//             }
//             else
//             {
//                 Debug.LogError("⚠ GameOverPanelScript not assigned in GroundDetector!");
//             }
//         }
//     }
// }



