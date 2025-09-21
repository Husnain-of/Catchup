using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
