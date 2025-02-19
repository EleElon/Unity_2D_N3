using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour {

    internal static GameManager Instance { get; private set; }
    [Header("---------- Variables ----------")]
    float gameSpeed = 5f;
    float gameSpeedUpScaleValue = 0.005f;
    float score;
    bool isGamePaused = false, isGameOver = false;

    void Awake() {
        Instance = this;
        UIManager.Instance.SetScoreText("Score: " + Mathf.FloorToInt(score));

        IsPaused(true);
    }

    void FixedUpdate() {
        if (isGameOver) {
            GameOver();
            return;
        }
        UpScaleGameSpeed();
        ScoreIncre();
    }

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            EscapeKey();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            UIManager.Instance.SetStartGameText(false);
            IsPaused(false);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.GetEggCrackSound());
        }
    }

    void EscapeKey() {
        if (isGameOver) {
            return;
        }
        else if (!isGamePaused && !UIManager.Instance.GamePausedPanelActivated()) {
            UIManager.Instance.SetGamePausePanel(true);
            IsPaused(true);
        }
        else if (isGamePaused && UIManager.Instance.GamePausedPanelActivated()) {
            Debug.Log("pressed");
            UIManager.Instance.SetGamePausePanel(false);
            IsPaused(false);
        }
    }

    void UpScaleGameSpeed() {
        gameSpeed += Time.deltaTime * gameSpeedUpScaleValue;
    }

    void IsPaused(bool state) {
        SetGamePause(state);
        Time.timeScale = state ? 0 : 1;
    }

    void GameOver() {
        UIManager.Instance.SetGamePausePanel(false);
        UIManager.Instance.SetGameOverPanel(true);
        IsPaused(true);
    }

    public void Continue() {
        IsPaused(false);
        UIManager.Instance.SetGamePausePanel(false);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("GamePlay");
        IsPaused(true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    internal float GetGameSpeed() {
        return gameSpeed;
    }

    void SetGamePause(bool state) {
        isGamePaused = state;
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

    void ScoreIncre() {
        score += Time.deltaTime * 9;
        UIManager.Instance.SetScoreText("Score: " + Mathf.FloorToInt(score));
    }
}
