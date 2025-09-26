// // using UnityEngine;

// // public class BasketCollector : MonoBehaviour
// // {
// //     public GameObject playerPrefab;   // Ball prefab (UI Image wali)
// //     public RectTransform canvasTransform; // Canvas ka RectTransform (Inspector me drag karo)

// //     private void OnCollisionEnter2D(Collision2D collision)
// //     {
// //         Debug.Log("Collision with: " + collision.gameObject.name);

// //         if (collision.gameObject.CompareTag("Player"))
// //         {
// //             Debug.Log("Player detected! Destroying old ball.");
// //             Destroy(collision.gameObject);
// //             SpawnNewBall();
// //         }
// //     }

// //     void SpawnNewBall()
// // {
// //     if (playerPrefab == null || canvasTransform == null)
// //     {
// //         Debug.LogError("⚠️ Player Prefab ya Canvas Transform assign nahi hua!");
// //         return;
// //     }

// //     // Canvas ke andar direct instantiate
// //     GameObject newBall = Instantiate(playerPrefab, canvasTransform);

// //     RectTransform ballRect = newBall.GetComponent<RectTransform>();

// //     if (ballRect == null)
// //     {
// //         Debug.LogError("⚠️ Prefab me RectTransform nahi mila!");
// //         return;
// //     }

// //     // Random X position (UI Anchored Position ke liye)
// //     float randomX = Random.Range(-680f, 680f);
// //     float fixedY = 840f;

// //     ballRect.anchoredPosition = new Vector2(randomX, fixedY);

// //     // Agar size 0 ho to force kar do
// //     if (ballRect.sizeDelta == Vector2.zero)
// //     {
// //         ballRect.sizeDelta = new Vector2(100, 100);
// //     }

// //     // Always bring on top (BG ke neeche na jaye)
// //     newBall.transform.SetAsLastSibling();

// //     Debug.Log("✅ New Ball UI spawned at anchoredPos: " + ballRect.anchoredPosition);
// // }
// // }




// // using UnityEngine;

// // public class BasketCollector : MonoBehaviour
// // {
// //     [Header("Prefabs & References")]
// //     public GameObject playerPrefab;         // Ball prefab (UI Image wali)
// //     public RectTransform canvasTransform;   // Canvas RectTransform
// //     public GameObject floatingTextPrefab;   // FloatingText prefab

// //     private void OnCollisionEnter2D(Collision2D collision)
// //     {
// //         if (collision.gameObject.CompareTag("Player"))
// //         {
// //             // ✅ Score +5 (agar ScoreManager hai to use karo)
// //             if (ScoreManager.instance != null)
// //             {
// //                 ScoreManager.instance.AddScore(5);
// //             }

// //             // ✅ Floating text spawn karo
// //             ShowFloatingText();

// //             // ✅ Ball destroy
// //             Destroy(collision.gameObject);

// //             // ✅ Nayi ball spawn karo
// //             SpawnNewBall();
// //         }
// //     }

// //     void ShowFloatingText()
// //     {
// //         if (floatingTextPrefab != null && canvasTransform != null)
// //         {
// //             GameObject popup = Instantiate(floatingTextPrefab, canvasTransform);

// //             // Basket ki world position ko screen-space UI me convert karo
// //             Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

// //             // UI element ki position set karo
// //             popup.transform.position = screenPos;
// //         }
// //     }

// //     void SpawnNewBall()
// //     {
// //         if (playerPrefab == null || canvasTransform == null) return;

// //         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
// //         RectTransform ballRect = newBall.GetComponent<RectTransform>();

// //         if (ballRect != null)
// //         {
// //             float randomX = Random.Range(-680f, 680f);
// //             float fixedY = 840f;
// //             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

// //             if (ballRect.sizeDelta == Vector2.zero)
// //                 ballRect.sizeDelta = new Vector2(100, 100);

// //             newBall.transform.SetAsLastSibling();
// //         }
// //     }
// // }




// // using UnityEngine;

// // public class BasketCollector : MonoBehaviour
// // {
// //     public GameObject playerPrefab;         // Ball prefab
// //     public RectTransform canvasTransform;   // Canvas ka RectTransform
// //     public GameObject floatingTextPrefab;   // ✅ Floating Text Prefab

// //     private void OnCollisionEnter2D(Collision2D collision)
// //     {
// //         if (collision.gameObject.CompareTag("Player"))
// //         {
// //             // ✅ Score add 5 points
// //             ScoreManager.instance.AddScore(5);

// //             // ✅ Floating text spawn karo
// //             if (floatingTextPrefab != null && canvasTransform != null)
// //             {
// //                 GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
// //                 RectTransform rt = ft.GetComponent<RectTransform>();

// //                 // Text basket ke thoda upar spawn hoga
// //                 rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
// //             }

// //             // Destroy old ball
// //             Destroy(collision.gameObject);

// //             // Spawn new ball
// //             SpawnNewBall();
// //         }
// //     }

// //     void SpawnNewBall()
// //     {
// //         if (playerPrefab == null || canvasTransform == null) return;

// //         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
// //         RectTransform ballRect = newBall.GetComponent<RectTransform>();

// //         if (ballRect != null)
// //         {
// //             // Random X position between -680 to 680, fixed Y = 840
// //             float randomX = Random.Range(-680f, 680f);
// //             float fixedY = 840f;
// //             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

// //             // Optional: size fix agar zero ho
// //             if (ballRect.sizeDelta == Vector2.zero)
// //                 ballRect.sizeDelta = new Vector2(100, 100);

// //             newBall.transform.SetAsLastSibling(); // Canvas ke upar dikhe
// //         }
// //     }
// // }




// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     public GameObject playerPrefab;         // Ball prefab
//     public RectTransform canvasTransform;   // Canvas ka RectTransform
//     public GameObject floatingTextPrefab;   // ✅ Floating Text Prefab
//     public float baseGravity = 50f;          // Starting gravity
//     public float gravityIncrease = 5f;    // Har ball ke sath gravity increase
//     private int ballCount = 0;              // Kitne ball spawn hue
//     public float maxGravity = 100f; 

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

//         // ✅ Gravity increase logic
//         Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
//         if (rb != null)
//         {
//             ballCount++;
//             float newGravity = baseGravity + (ballCount * gravityIncrease);
//             rb.gravityScale = Mathf.Min(newGravity, maxGravity); // 👈 Clamp to max
//         }
//     }
// }




// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     [Header("Prefabs & References")]
//     public GameObject playerPrefab;          // Ball prefab
//     public RectTransform canvasTransform;    // Canvas ka RectTransform
//     public GameObject floatingTextPrefab;    // Floating Text Prefab

//     [Header("Gravity Settings")]
//     public float baseGravity = 1f;           // Starting gravity
//     public float gravityIncrease = 0.2f;     // Har ball ke sath gravity increase
//     public float maxGravity = 5f;            // Max gravity clamp

//     private int ballCount = 0;               // Kitni balls spawn hui hain

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // ✅ Score add 5 points
//             if (ScoreManager.instance != null)
//                 ScoreManager.instance.AddScore(5);

//             // ✅ Floating text spawn
//             ShowFloatingText(collision);

//             // ✅ Purani ball destroy
//             Destroy(collision.gameObject);

//             // ✅ Nayi ball spawn
//             SpawnNewBall();
//         }
//     }

//     void ShowFloatingText(Collision2D collision)
//     {
//         if (floatingTextPrefab != null && canvasTransform != null)
//         {
//             GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
//             RectTransform rt = ft.GetComponent<RectTransform>();

//             if (rt != null)
//             {
//                 // Basket ke thoda upar spawn hoga
//                 rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
//             }
//         }
//     }

//     void SpawnNewBall()
//     {
//         if (playerPrefab == null || canvasTransform == null) return;

//         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
//         RectTransform ballRect = newBall.GetComponent<RectTransform>();

//         if (ballRect != null)
//         {
//             // Random X, fixed Y
//             float randomX = Random.Range(-680f, 680f);
//             float fixedY = 840f;
//             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

//             // Agar prefab ka size zero ho to fix kar do
//             if (ballRect.sizeDelta == Vector2.zero)
//                 ballRect.sizeDelta = new Vector2(100, 100);

//             // Always bring on top
//             newBall.transform.SetAsLastSibling();
//         }

//         // ✅ Gravity increase logic
//         Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
//         if (rb != null)
//         {
//             ballCount++;
//             float newGravity = baseGravity + (ballCount * gravityIncrease);
//             rb.gravityScale = Mathf.Min(newGravity, maxGravity); // Clamp max tak
//         }
//     }
// }




// using UnityEngine;

// public class BasketCollector : MonoBehaviour
// {
//     [Header("Prefabs & References")]
//     public GameObject playerPrefab;          // Ball prefab
//     public RectTransform canvasTransform;    // Canvas ka RectTransform
//     public GameObject floatingTextPrefab;    // Floating Text Prefab

//     [Header("Gravity Settings")]
//     public float baseGravity = 1f;           // Starting gravity
//     public float gravityIncrease = 0.2f;     // Har ball ke sath gravity increase
//     public float maxGravity = 5f;            // Max gravity clamp

//     private int ballCount = 0;               // Kitni balls spawn hui hain

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // ✅ Score add 5 points
//             if (ScoreManager.instance != null)
//                 ScoreManager.instance.AddScore(5);

//             // ✅ Floating text spawn
//             ShowFloatingText(collision);

//             // ✅ Purani ball destroy
//             Destroy(collision.gameObject);

//             // ✅ Nayi ball spawn
//             SpawnNewBall();
//         }
//     }

//     void ShowFloatingText(Collision2D collision)
//     {
//         if (floatingTextPrefab != null && canvasTransform != null)
//         {
//             GameObject ft = Instantiate(floatingTextPrefab, canvasTransform);
//             RectTransform rt = ft.GetComponent<RectTransform>();

//             if (rt != null)
//             {
//                 // Basket ke thoda upar spawn hoga
//                 rt.anchoredPosition = collision.transform.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50);
//             }
//         }
//     }

//     void SpawnNewBall()
//     {
//         if (playerPrefab == null || canvasTransform == null) return;

//         GameObject newBall = Instantiate(playerPrefab, canvasTransform);
//         RectTransform ballRect = newBall.GetComponent<RectTransform>();

//         if (ballRect != null)
//         {
//             // ✅ Canvas aur Ball ka size nikal lo
//             float canvasHalfWidth = canvasTransform.rect.width / 2f;
//             float ballHalfWidth = ballRect.rect.width / 2f;

//             // ✅ Random X ko clamp karo taake ball screen ke andar hi spawn ho
//             float randomX = Random.Range(-canvasHalfWidth + ballHalfWidth, canvasHalfWidth - ballHalfWidth);

//             // Fixed Y spawn height
//             float fixedY = 840f;
//             ballRect.anchoredPosition = new Vector2(randomX, fixedY);

//             // Agar prefab ka size zero ho to fix kar do
//             if (ballRect.sizeDelta == Vector2.zero)
//                 ballRect.sizeDelta = new Vector2(100, 100);

//             // Always bring on top
//             newBall.transform.SetAsLastSibling();
//         }

//         // ✅ Gravity increase logic
//         Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
//         if (rb != null)
//         {
//             ballCount++;
//             float newGravity = baseGravity + (ballCount * gravityIncrease);
//             rb.gravityScale = Mathf.Min(newGravity, maxGravity); // Clamp max tak
//         }
//     }
// }



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

