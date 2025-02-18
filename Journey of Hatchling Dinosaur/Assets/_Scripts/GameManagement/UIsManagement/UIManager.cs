using TMPro;
using UnityEngine;

class UIManager : MonoBehaviour {

    internal static UIManager Instance { get; private set; }

    [Header("---------- Texts ----------")]
    [SerializeField] TextMeshProUGUI ScoreText;

    [Header("---------- Panels ----------")]
    [SerializeField] GameObject gamePausedPanel;
    [SerializeField] GameObject gameOverPanel;

    void Awake() {
        Instance = this;
    }

    internal void SetGamePausePanel(bool state) {
        if (gamePausedPanel)
            gamePausedPanel.SetActive(state);
    }

    internal bool GamePausedPanelActivated() {
        return gamePausedPanel.activeInHierarchy;
    }

    internal void SetGameOverPanel(bool state) {
        if (gameOverPanel)
            gameOverPanel.SetActive(state);
    }

    internal bool GameOverPanelActivated() {
        return gameOverPanel.activeInHierarchy;
    }

    internal void SetScoreText(string txt) {
        if (ScoreText)
            ScoreText.text = txt;
    }
}
