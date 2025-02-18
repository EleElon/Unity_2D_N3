using UnityEngine;

class ParallaxBackGround : MonoBehaviour {

    [Header("---------- Variables ----------")]
    Material _material;
    [SerializeField] float parallaxFactor;
    float offset;
    void Start() {
        _material = GetComponent<Renderer>().material;
    }

    void Update() {
        ParallaxScroll();
    }

    void ParallaxScroll() {
        float parallaxSpeed = GameManager.Instance.GetGameSpeed() * parallaxFactor;
        offset += Time.deltaTime * parallaxSpeed;
        _material.SetTextureOffset("_MainTex", Vector2.right * offset);
    }
}
