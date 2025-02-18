using UnityEngine;

class Crate : ObstacleManager {

    protected override void AbstacleMoveToLeft() {
        base.AbstacleMoveToLeft();
        if (transform.position.x <= leftOfLimit) {
            CrateOP.Instance.ReturnCrate(gameObject);
        }
    }
}
