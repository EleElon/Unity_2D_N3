using UnityEngine;

class Frog : ObstacleManager {

    protected override void AbstacleMoveToLeft() {
        base.AbstacleMoveToLeft();
        if (transform.position.x <= leftOfLimit) {
            FrogOP.Instance.ReturnFrog(gameObject);
        }
    }
}
