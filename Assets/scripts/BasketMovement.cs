using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    public float moveSpeed = 800f; // Movement speed
    public RectTransform canvasRect; // Canvas ka RectTransform (Inspector me drag karo)

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (canvasRect == null)
        {
            Debug.LogError("⚠️ Canvas RectTransform assign nahi kiya!");
        }
    }

    void Update()
    {
        float moveX = 0f;

        // ✅ PC ke liye (Testing)
        moveX = Input.GetAxis("Horizontal"); // -1 (left), +1 (right)

        // ✅ Mobile ke liye (Touch input)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
                moveX = -1f; // left
            else
                moveX = 1f;  // right
        }

        // Movement apply karo
        rectTransform.anchoredPosition += new Vector2(moveX * moveSpeed * Time.deltaTime, 0);

        // ✅ Basket ko screen ke andar clamp karo
        ClampBasket();
    }

    void ClampBasket()
    {
        if (canvasRect == null) return;

        Vector3 pos = rectTransform.anchoredPosition;

        float halfWidth = rectTransform.rect.width / 2;
        float canvasHalfWidth = canvasRect.rect.width / 2;

        pos.x = Mathf.Clamp(pos.x, -canvasHalfWidth + halfWidth, canvasHalfWidth - halfWidth);

        rectTransform.anchoredPosition = pos;
    }
}


