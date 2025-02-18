using UnityEngine;

class ObstacleManager : MonoBehaviour {

    protected float leftOfLimit = -12f;

    void Update() {
        if (GameManager.Instance.GetGameOver())
            return;
        AbstacleMoveToLeft();
    }

    protected virtual void AbstacleMoveToLeft() {
        transform.position += Vector3.left * (GameManager.Instance.GetGameSpeed() * 1.78f) * Time.deltaTime;
    }
}
