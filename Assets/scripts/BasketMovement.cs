// using UnityEngine;

// public class BasketMovement : MonoBehaviour
// {
//     public float moveSpeed = 10f; // Smooth follow speed
//     public RectTransform canvasRect; // Canvas ka RectTransform

//     private RectTransform rectTransform;

//     void Start()
//     {
//         rectTransform = GetComponent<RectTransform>();

//         if (canvasRect == null)
//         {
//             Debug.LogError("⚠️ Canvas RectTransform assign nahi kiya!");
//         }
//     }

//     void Update()
//     {
//         // ✅ Mobile/PC Touch control
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             // Screen se Canvas position me convert karo
//             Vector2 localPoint;
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(
//                 canvasRect, touch.position, null, out localPoint
//             );

//             // Basket ko touch position ke X par move karo (sirf X change hoga)
//             Vector2 targetPos = new Vector2(localPoint.x, rectTransform.anchoredPosition.y);

//             // Smooth move
//             rectTransform.anchoredPosition = Vector2.Lerp(
//                 rectTransform.anchoredPosition,
//                 targetPos,
//                 moveSpeed * Time.deltaTime
//             );

//             ClampBasket();
//         }

//         // ✅ PC testing ke liye (Mouse)
//         if (Application.isEditor && Input.GetMouseButton(0))
//         {
//             Vector2 localPoint;
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(
//                 canvasRect, Input.mousePosition, null, out localPoint
//             );

//             Vector2 targetPos = new Vector2(localPoint.x, rectTransform.anchoredPosition.y);

//             rectTransform.anchoredPosition = Vector2.Lerp(
//                 rectTransform.anchoredPosition,
//                 targetPos,
//                 moveSpeed * Time.deltaTime
//             );

//             ClampBasket();
//         }
//     }

//     void ClampBasket()
//     {
//         if (canvasRect == null) return;

//         Vector3 pos = rectTransform.anchoredPosition;

//         float halfWidth = rectTransform.rect.width / 2;
//         float canvasHalfWidth = canvasRect.rect.width / 2;

//         pos.x = Mathf.Clamp(pos.x, -canvasHalfWidth + halfWidth, canvasHalfWidth - halfWidth);

//         rectTransform.anchoredPosition = pos;
//     }
// }



using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public RectTransform canvasRect; 

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
        // ✅ Mobile control
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect, touch.position, null, out localPoint
            );

            Vector2 targetPos = new Vector2(localPoint.x, rectTransform.anchoredPosition.y);

            rectTransform.anchoredPosition = Vector2.Lerp(
                rectTransform.anchoredPosition,
                targetPos,
                moveSpeed * Time.deltaTime
            );

            ClampBasket();
        }

        // ✅ PC Mouse control (testing ke liye)
        if (Application.isEditor && Input.GetMouseButton(0))
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect, Input.mousePosition, null, out localPoint
            );

            Vector2 targetPos = new Vector2(localPoint.x, rectTransform.anchoredPosition.y);

            rectTransform.anchoredPosition = Vector2.Lerp(
                rectTransform.anchoredPosition,
                targetPos,
                moveSpeed * Time.deltaTime
            );

            ClampBasket();
        }
    }

    void ClampBasket()
    {
        if (canvasRect == null) return;

        Vector3 pos = rectTransform.anchoredPosition;

        float halfWidth = rectTransform.rect.width * rectTransform.localScale.x / 2f;
        float canvasHalfWidth = canvasRect.rect.width / 2f;

        // ✅ Basket ko sirf canvas ke andar hi allow karna
        pos.x = Mathf.Clamp(pos.x, -canvasHalfWidth + halfWidth, canvasHalfWidth - halfWidth);

        rectTransform.anchoredPosition = pos;
    }
}


