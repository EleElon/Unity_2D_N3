using UnityEngine;

class EggController : MonoBehaviour {
    [SerializeField] GameObject player;
    public void HidePlayerInStartGame() {
        gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }
}
