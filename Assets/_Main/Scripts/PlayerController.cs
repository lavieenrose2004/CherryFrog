using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    [Header("Ground Check")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDepth;

    [Header("Configurations")]
    [SerializeField] private float fallThreshold = -0.1f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float horizontalMovement; 

    private bool groundHit;   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        UpdateAnimations();

        groundHit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDepth, groundLayer);
        if (groundHit) anim.SetTrigger("Land");

        if (Input.GetButtonDown("Jump") && groundHit) HandleJump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
    }

    private void HandleJump() {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        anim.SetTrigger("Jump");
    }

    private void UpdateAnimations()
    {
        if (horizontalMovement > 0) spriteRenderer.flipX = false;
        else if (horizontalMovement < 0) spriteRenderer.flipX = true;

        if (rb.velocity.x != 0) anim.SetBool("IsRunning", true);
        else anim.SetBool("IsRunning", false);

        if (rb.velocity.y <= fallThreshold) anim.SetTrigger("Fall");
    }


}
