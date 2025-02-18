using UnityEngine;

class Spawner : MonoBehaviour {

    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform highPos;
    [SerializeField] Transform lowPos;

    float nextTimeToSpawn;
    float spawnRate = 2f;

    void Update() {
        SetTimeSpawn();
    }

    void SpawnObstacles() {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle;

        switch (index) {
            case 0:
                obstacle = Instantiate(obstacles[index], highPos.position, Quaternion.identity);
                break;
            case 1:
                obstacle = Instantiate(obstacles[index], lowPos.position, Quaternion.identity);
                break;
            case 2:
                obstacle = Instantiate(obstacles[index], lowPos.position, Quaternion.identity);
                break;
        }
    }

    void SetTimeSpawn() {
        if (Time.time >= nextTimeToSpawn) {
            SpawnObstacles();
            nextTimeToSpawn = Time.time + spawnRate;
        }
    }
}
