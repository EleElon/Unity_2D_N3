using System.Collections;
using UnityEngine;

class PlayerController : MonoBehaviour {

    internal static PlayerController Instance { get; private set; }

    [Header("---------- Variables ----------")]
    float jumpForce = 15f;
    bool isJumping, canJump, isRunning;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [Header("---------- Components ----------")]
    Rigidbody2D _rb;
    [SerializeField] BoxCollider2D[] _colliders;
    Animator _animator;

    void Awake() {
        Instance = this;

        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _colliders = GetComponents<BoxCollider2D>();
    }

    void Update() {
        CheckGround();
        HandleJump();
        HandleDuck();
        UpdateAnimations();
    }

    void HandleJump() {
        if (Input.GetButtonDown("Jump") && canJump) {
            Jump();
            isJumping = true;
        }
    }

    void HandleDuck() {
        if (Input.GetKey(KeyCode.E) && !isJumping) {
            IsDuck(true);
        }
        else {
            IsDuck(false);
        }
    }

    void Jump() {
        _rb.linearVelocity = Vector2.up * jumpForce;
    }

    void CheckGround() {
        canJump = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isJumping = false;
    }

    void IsDuck(bool state) { //FIXME: player can't allow to duck when jumping
        _colliders[0].enabled = !state;
        _colliders[1].enabled = state;

        isRunning = !state;
    }

    void UpdateAnimations() {
        bool isRunningAnimation = isRunning;

        _animator.SetBool("IsRunning", isRunningAnimation);
    }
}
