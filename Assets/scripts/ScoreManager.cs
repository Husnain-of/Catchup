
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

