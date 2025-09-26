// using UnityEngine;
// using TMPro;

// public class FloatingText : MonoBehaviour
// {
//     public float moveSpeed = 300;       // Upar move speed
//     public float fadeDuration = 20f;      // Kitne sec me fade hoga
//     private CanvasGroup canvasGroup;
//     private RectTransform rectTransform;

//     void Awake()
//     {
//         rectTransform = GetComponent<RectTransform>();
//         canvasGroup = gameObject.AddComponent<CanvasGroup>();
//         canvasGroup.alpha = 0; // Start invisible
//     }

//     void OnEnable()
//     {
//         // Har spawn par reset karo
//         canvasGroup.alpha = 1;
//     }

//     void Update()
//     {
//         // Upar move karo
//         rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

//         // Dheere dheere fade out karo
//         canvasGroup.alpha -= Time.deltaTime / fadeDuration;

//         // Destroy jab alpha 0 ho jaye
//         if (canvasGroup.alpha <= 0)
//         {
//             Destroy(gameObject);
//         }
//     }
// }



using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 100f;         // Kitni speed se upar jaye
    public float lifeTime = 1.5f;          // Kitne sec baad destroy ho
    public float fadeDuration = 0.5f;      // End me kitni der me fade ho

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private float timer;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 1; // Start visible
    }

    void OnEnable()
    {
        timer = 0f; // Reset timer har spawn par
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Upar move karo
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

        // Agar text lifeTime cross kar raha hai to fade karna start karo
        if (timer > lifeTime)
        {
            float fadeAmount = 1 - ((timer - lifeTime) / fadeDuration);
            canvasGroup.alpha = Mathf.Clamp01(fadeAmount);

            // Jab completely fade ho jaye to destroy
            if (canvasGroup.alpha <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

