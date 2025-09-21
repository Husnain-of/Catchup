using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    public GameObject playerPrefab;   // Ball prefab (UI Image wali)
    public RectTransform canvasTransform; // Canvas ka RectTransform (Inspector me drag karo)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected! Destroying old ball.");
            Destroy(collision.gameObject);
            SpawnNewBall();
        }
    }

    void SpawnNewBall()
{
    if (playerPrefab == null || canvasTransform == null)
    {
        Debug.LogError("⚠️ Player Prefab ya Canvas Transform assign nahi hua!");
        return;
    }

    // Canvas ke andar direct instantiate
    GameObject newBall = Instantiate(playerPrefab, canvasTransform);

    RectTransform ballRect = newBall.GetComponent<RectTransform>();

    if (ballRect == null)
    {
        Debug.LogError("⚠️ Prefab me RectTransform nahi mila!");
        return;
    }

    // Random X position (UI Anchored Position ke liye)
    float randomX = Random.Range(-680f, 680f);
    float fixedY = 840f;

    ballRect.anchoredPosition = new Vector2(randomX, fixedY);

    // Agar size 0 ho to force kar do
    if (ballRect.sizeDelta == Vector2.zero)
    {
        ballRect.sizeDelta = new Vector2(100, 100);
    }

    // Always bring on top (BG ke neeche na jaye)
    newBall.transform.SetAsLastSibling();

    Debug.Log("✅ New Ball UI spawned at anchoredPos: " + ballRect.anchoredPosition);
}
}
