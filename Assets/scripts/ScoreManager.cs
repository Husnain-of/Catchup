// using UnityEngine;
// using TMPro; // Agar normal UI Text use kar rahe ho to "using UnityEngine.UI;" aur Text likho

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager instance;

//     public int score = 0;                     // Initial score 0
//     public TextMeshProUGUI scoreText;         // Score Text (Inspector me drag & drop)

//     private void Awake()
//     {
//         // Singleton pattern
//         if (instance == null)
//             instance = this;
//         else
//             Destroy(gameObject);

//         // Initial score UI update
//         UpdateUI();
//     }

//     public void AddScore(int points)
//     {
//         score += points;
//         UpdateUI();
//     }

//     void UpdateUI()
//     {
//         if (scoreText != null)
//         {
//             // ✅ Score hamesha same line me
//             scoreText.text = "Score: " + score;
//         }
//     }
// }


using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;                     // Initial score = 0
    public TextMeshProUGUI scoreText;         // Inspector me assign karo

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Initial display
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            // ✅ Single line me score update
            scoreText.text = "Score: " + score;

            // Optional: Alignment aur wrap settings
            scoreText.alignment = TextAlignmentOptions.Left; // ya Center/Right
            scoreText.textWrappingMode = TextWrappingModes.NoWrap; // Word wrap off
        }
    }
}

