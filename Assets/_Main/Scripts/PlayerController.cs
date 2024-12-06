using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDepth;
    [SerializeField] bool isGrounded;   


    [Header("Configurations")]
    [SerializeField] private float fallThreshold = -2f;
    [SerializeField] private float jumpThreshold = 2f;

    private Player player;
    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float horizontalMovement; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        rb = GetComponentInParent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        UpdateAnimations();

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDepth, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded) HandleJump();
    }

    public void PlayHurtAnim() {
        anim.SetTrigger("Hit");
    }

    public void PlayDeadAnim() {
        anim.SetTrigger("Dead");
        rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * player.Speed, rb.velocity.y);
    }

    private void HandleJump() {
        rb.AddForce(Vector2.up * player.JumpPower, ForceMode2D.Impulse);
    }

    private void UpdateAnimations()
    {
        if (horizontalMovement > 0) spriteRenderer.flipX = false;
        else if (horizontalMovement < 0) spriteRenderer.flipX = true;

        if (horizontalMovement != 0) anim.SetBool("IsRunning", true);
        else anim.SetBool("IsRunning", false);

        if (rb.velocity.y <= fallThreshold && !isGrounded) anim.SetBool("IsFalling", true);
        else anim.SetBool("IsFalling", false);

        if (rb.velocity.y >= jumpThreshold && !isGrounded) anim.SetBool("IsJumping", true);
        else anim.SetBool("IsJumping", false);
    }


}
