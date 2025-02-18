using UnityEngine;

class ObstacleManager : MonoBehaviour {

    float leftOfLimit = -12f;

    void Update() {
        AbstacleMoveToLeft();
    }

    void AbstacleMoveToLeft() {
        transform.position += Vector3.left * (GameManager.Instance.GetGameSpeed() * 1.78f) * Time.deltaTime;
        if (transform.position.x <= leftOfLimit) {
            Destroy(gameObject);
        }
    }
}
