using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    [Header("Prefabs & References")]
    public GameObject playerPrefab;          // Ball prefab
    public RectTransform canvasTransform;    // Canvas ka RectTransform
    public GameObject floatingTextPrefab;    // Floating Text Prefab

    [Header("Gravity Settings")]
    public float baseGravity = 1f;           // Starting gravity
    public float gravityIncrease = 0.2f;     // Har ball ke sath gravity increase
    public float maxGravity = 5f;            // Max gravity clamp

    [Header("Audio")]
    public AudioClip scoreSound;             // 🎵 Score ka sound
    private AudioSource audioSource;

    private int ballCount = 0;               // Kitni balls spawn hui hain

    private void Start()
    {
        // Basket object pe AudioSource ensure karo
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ✅ Score add 5 points
            if (ScoreManager.instance != null)
                ScoreManager.instance.AddScore(5);

            // ✅ Floating text spawn
            ShowFloatingText(collision);

            // ✅ Score sound bajao
            if (scoreSound != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }

            // ✅ Purani ball destroy
            Destroy(collision.gameObject);

            // ✅ Nayi ball spawn
            SpawnNewBall();
        }
    }

    void ShowFloatingText(Collision2D collision)
    {
        if (floatingTextPrefab != null && canvasTransform != null)
        {
            GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
            RectTransform rt = ft.GetComponent<RectTransform>();

            if (rt != null)
            {
                // Basket ke thoda upar spawn hoga
                rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
            }
        }
    }

    void SpawnNewBall()
    {
        if (playerPrefab == null || canvasTransform == null) return;

        GameObject newBall = Instantiate(playerPrefab, canvasTransform);
        RectTransform ballRect = newBall.GetComponent<RectTransform>();

        if (ballRect != null)
        {
            // ✅ Canvas aur Ball ka size nikal lo
            float canvasHalfWidth = canvasTransform.rect.width / 2f;
            float ballHalfWidth = ballRect.rect.width / 2f;

            // ✅ Random X ko clamp karo taake ball screen ke andar hi spawn ho
            float randomX = Random.Range(-canvasHalfWidth + ballHalfWidth, canvasHalfWidth - ballHalfWidth);

            // Fixed Y spawn height
            float fixedY = 840f;
            ballRect.anchoredPosition = new Vector2(randomX, fixedY);

            // Agar prefab ka size zero ho to fix kar do
            if (ballRect.sizeDelta == Vector2.zero)
                ballRect.sizeDelta = new Vector2(100, 100);

            // Always bring on top
            newBall.transform.SetAsLastSibling();
        }

        // ✅ Gravity increase logic
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            ballCount++;
            float newGravity = baseGravity + (ballCount * gravityIncrease);
            rb.gravityScale = Mathf.Min(newGravity, maxGravity); // Clamp max tak
        }
    }
}







