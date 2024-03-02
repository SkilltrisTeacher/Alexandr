using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private KeyCode jumpButton = KeyCode.Space;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D feetCollider;
    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
        SwitchAnimation(playerInput);
        Flip(playerInput);
        bool isGrounded = feetCollider.IsTouchingLayers(groundLayer);
        if (Input.GetKeyDown(jumpButton) && isGrounded) Jump();
    }
    private void SwitchAnimation(float playerInput)
    {
    playerAnimator.SetBool("Run", playerInput != 0 );
    }

    private void Move(float direction)
    {
        //объявляем двумерный вектор скорости по оси Х
        Vector2 velocity = playerRigidbody2D.velocity;
        //Изменение вектора движения
        playerRigidbody2D.velocity = new Vector2(speed * direction, velocity.y);
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(0f, jumpForce);
        playerRigidbody2D.AddForce(jumpVector);
    }

    private void Flip(float direction)
    {
        if (direction > 0) spriteRenderer.flipX = false;
        if (direction < 0) spriteRenderer.flipX = true;
    }

}
