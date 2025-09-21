// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     public GameObject playerPrefab;   // Ball prefab (UI Image wali)
//     public RectTransform canvasTransform; // Canvas ka RectTransform (Inspector me drag karo)

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         Debug.Log("Collision with: " + collision.gameObject.name);

//         if (collision.gameObject.CompareTag("Player"))
//         {
//             Debug.Log("Player detected! Destroying old ball.");
//             Destroy(collision.gameObject);
//             SpawnNewBall();
//         }
//     }

//     void SpawnNewBall()
// {
//     if (playerPrefab == null || canvasTransform == null)
//     {
//         Debug.LogError("⚠️ Player Prefab ya Canvas Transform assign nahi hua!");
//         return;
//     }

//     // Canvas ke andar direct instantiate
//     GameObject newBall = Instantiate(playerPrefab, canvasTransform);

//     RectTransform ballRect = newBall.GetComponent<RectTransform>();

//     if (ballRect == null)
//     {
//         Debug.LogError("⚠️ Prefab me RectTransform nahi mila!");
//         return;
//     }

//     // Random X position (UI Anchored Position ke liye)
//     float randomX = Random.Range(-680f, 680f);
//     float fixedY = 840f;

//     ballRect.anchoredPosition = new Vector2(randomX, fixedY);

//     // Agar size 0 ho to force kar do
//     if (ballRect.sizeDelta == Vector2.zero)
//     {
//         ballRect.sizeDelta = new Vector2(100, 100);
//     }

//     // Always bring on top (BG ke neeche na jaye)
//     newBall.transform.SetAsLastSibling();

//     Debug.Log("✅ New Ball UI spawned at anchoredPos: " + ballRect.anchoredPosition);
// }
// }




// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     [Header("Prefabs & References")]
//     public GameObject playerPrefab;         // Ball prefab (UI Image wali)
//     public RectTransform canvasTransform;   // Canvas RectTransform
//     public GameObject floatingTextPrefab;   // FloatingText prefab

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // ✅ Score +5 (agar ScoreManager hai to use karo)
//             if (ScoreManager.instance != null)
//             {
//                 ScoreManager.instance.AddScore(5);
//             }

//             // ✅ Floating text spawn karo
//             ShowFloatingText();

//             // ✅ Ball destroy
//             Destroy(collision.gameObject);

//             // ✅ Nayi ball spawn karo
//             SpawnNewBall();
//         }
//     }

//     void ShowFloatingText()
//     {
//         if (floatingTextPrefab != null && canvasTransform != null)
//         {
//             GameObject popup = Instantiate(floatingTextPrefab, canvasTransform);

//             // Basket ki world position ko screen-space UI me convert karo
//             Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

//             // UI element ki position set karo
//             popup.transform.position = screenPos;
//         }
//     }

//     void SpawnNewBall()
//     {
//         if (playerPrefab == null || canvasTransform == null) return;

//         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
//         RectTransform ballRect = newBall.GetComponent<RectTransform>();

//         if (ballRect != null)
//         {
//             float randomX = Random.Range(-680f, 680f);
//             float fixedY = 840f;
//             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

//             if (ballRect.sizeDelta == Vector2.zero)
//                 ballRect.sizeDelta = new Vector2(100, 100);

//             newBall.transform.SetAsLastSibling();
//         }
//     }
// }




// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     public GameObject playerPrefab;         // Ball prefab
//     public RectTransform canvasTransform;   // Canvas ka RectTransform
//     public GameObject floatingTextPrefab;   // ✅ Floating Text Prefab

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // ✅ Score add 5 points
//             ScoreManager.instance.AddScore(5);

//             // ✅ Floating text spawn karo
//             if (floatingTextPrefab != null && canvasTransform != null)
//             {
//                 GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
//                 RectTransform rt = ft.GetComponent<RectTransform>();

//                 // Text basket ke thoda upar spawn hoga
//                 rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
//             }

//             // Destroy old ball
//             Destroy(collision.gameObject);

//             // Spawn new ball
//             SpawnNewBall();
//         }
//     }

//     void SpawnNewBall()
//     {
//         if (playerPrefab == null || canvasTransform == null) return;

//         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
//         RectTransform ballRect = newBall.GetComponent<RectTransform>();

//         if (ballRect != null)
//         {
//             // Random X position between -680 to 680, fixed Y = 840
//             float randomX = Random.Range(-680f, 680f);
//             float fixedY = 840f;
//             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

//             // Optional: size fix agar zero ho
//             if (ballRect.sizeDelta == Vector2.zero)
//                 ballRect.sizeDelta = new Vector2(100, 100);

//             newBall.transform.SetAsLastSibling(); // Canvas ke upar dikhe
//         }
//     }
// }




using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    public GameObject playerPrefab;         // Ball prefab
    public RectTransform canvasTransform;   // Canvas ka RectTransform
    public GameObject floatingTextPrefab;   // ✅ Floating Text Prefab
    public float baseGravity = 50f;          // Starting gravity
    public float gravityIncrease = 1f;    // Har ball ke sath gravity increase
    private int ballCount = 0;              // Kitne ball spawn hue

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ✅ Score add 5 points
            ScoreManager.instance.AddScore(5);

            // ✅ Floating text spawn karo
            if (floatingTextPrefab != null && canvasTransform != null)
            {
                GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
                RectTransform rt = ft.GetComponent<RectTransform>();

                // Text basket ke thoda upar spawn hoga
                rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
            }

            // Destroy old ball
            Destroy(collision.gameObject);

            // Spawn new ball
            SpawnNewBall();
        }
    }

    void SpawnNewBall()
    {
        if (playerPrefab == null || canvasTransform == null) return;

        GameObject newBall = Instantiate(playerPrefab, canvasTransform);
        RectTransform ballRect = newBall.GetComponent<RectTransform>();

        if (ballRect != null)
        {
            // Random X position between -680 to 680, fixed Y = 840
            float randomX = Random.Range(-680f, 680f);
            float fixedY = 840f;
            ballRect.anchoredPosition = new Vector2(randomX, fixedY);

            // Optional: size fix agar zero ho
            if (ballRect.sizeDelta == Vector2.zero)
                ballRect.sizeDelta = new Vector2(100, 100);

            newBall.transform.SetAsLastSibling(); // Canvas ke upar dikhe
        }

        // ✅ Gravity increase logic
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            ballCount++;
            rb.gravityScale = baseGravity + (ballCount * gravityIncrease);
        }
    }
}

