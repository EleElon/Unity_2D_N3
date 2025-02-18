using UnityEngine;

class Spawner : MonoBehaviour {

    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform highPos;
    [SerializeField] Transform lowPos;

    float nextTimeToSpawn = 2f;
    float spawnRate = 2f;

    void Update() {
        if (GameManager.Instance.GetGameOver())
            return;
        SetTimeSpawn();
    }

    void SpawnObstacles() {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle = null;

        switch (index) {
            case 0:
                obstacle = EagleOP.Instance?.GetEagle();
                break;
            case 1:
                obstacle = FrogOP.Instance?.GetFrog();
                break;
            case 2:
                obstacle = CrateOP.Instance?.GetCrate();
                break;
        }

        if (obstacle != null) {
            SetSpawnPosition(obstacle, (index == 0) ? highPos : lowPos);
        }
    }

    void SetSpawnPosition(GameObject obj, Transform pos) {
        obj.transform.position = pos.position;
    }

    void SetTimeSpawn() {
        if (Time.time >= nextTimeToSpawn) {
            SpawnObstacles();
            nextTimeToSpawn = Time.time + spawnRate;
        }
    }
}
