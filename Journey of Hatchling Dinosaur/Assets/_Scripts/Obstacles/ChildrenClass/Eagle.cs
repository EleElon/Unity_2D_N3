using UnityEngine;

class Eagle : ObstacleManager {

    protected override void AbstacleMoveToLeft() {
        base.AbstacleMoveToLeft();
        if (transform.position.x <= leftOfLimit) {
            EagleOP.Instance.ReturnEagle(gameObject);
        }
    }
}
