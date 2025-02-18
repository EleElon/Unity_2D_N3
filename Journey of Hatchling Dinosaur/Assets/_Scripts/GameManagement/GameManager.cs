using UnityEngine;

class GameManager : MonoBehaviour {

    internal static GameManager Instance { get; private set; }
    [Header("---------- Variables ----------")]
    float gameSpeed = 5f;
    float gameSpeedUpScaleValue = 0.15f;
    int score;
    bool isGamePaused, isGameOver;

    void Awake() {
        Instance = this;
    }

    void FixedUpdate() {
        UpScaleGameSpeed();
    }

    void UpScaleGameSpeed() {
        gameSpeed += Time.deltaTime * gameSpeedUpScaleValue;
    }

    internal float GetGameSpeed() {
        return gameSpeed;
    }
    internal bool GetGamePause() {
        return isGamePaused;
    }

    internal void IsGameOver(bool state) {
        isGameOver = state;
    }

    internal bool GetGameOver() {
        return isGameOver;
    }
}
