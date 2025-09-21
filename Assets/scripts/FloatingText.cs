using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 100f;       // Upar move speed
    public float fadeDuration = 1f;      // Kitne sec me fade hoga
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0; // Start invisible
    }

    void OnEnable()
    {
        // Har spawn par reset karo
        canvasGroup.alpha = 1;
    }

    void Update()
    {
        // Upar move karo
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

        // Dheere dheere fade out karo
        canvasGroup.alpha -= Time.deltaTime / fadeDuration;

        // Destroy jab alpha 0 ho jaye
        if (canvasGroup.alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
