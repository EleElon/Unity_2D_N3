using UnityEngine;

class ObstacleCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameManager.Instance.IsGameOver(true);
        }

        if (collision.gameObject.CompareTag("ScoreZone")) {
            GameManager.Instance.ScoreIncre(1);
        }
    }
}
