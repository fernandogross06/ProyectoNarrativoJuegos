using UnityEngine;

public class MageAnimations : MonoBehaviour
{
    // Reference to your Sprite Renderer
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Animation direction states
    /*private const string ANIM_UP = "WALK_TOP";
    private const string ANIM_UP_RIGHT = "WALK_TOP_RIGHT";
    private const string ANIM_RIGHT = "WALK_RIGHT";
    private const string ANIM_DOWN_RIGHT = "WALK_DOWN_RIGHT";
    private const string ANIM_DOWN = "WALK_DOWN";
    private const string ANIM_DOWN_LEFT = "WALK_DOWN_LEFT";
    private const string ANIM_LEFT = "WALK_LEFT";
    private const string ANIM_UP_LEFT = "WALK_TOP_LEFT";*/


    private const string ANIM_UP = "IDDLE_TOP";
    private const string ANIM_UP_RIGHT = "IDDLE_TOP_RIGHT";
    private const string ANIM_RIGHT = "IDDLE_RIGHT";
    private const string ANIM_DOWN_RIGHT = "IDDLE_DOWN_RIGHT";
    private const string ANIM_DOWN = "IDDLE_DOWN";
    private const string ANIM_DOWN_LEFT = "IDDLE_DOWN_LEFT";
    private const string ANIM_LEFT = "IDDLE_LEFT";
    private const string ANIM_UP_LEFT = "IDDLE_TOP_LEFT";
    // Current direction
    private string currentDirection = ANIM_DOWN;

    // Movement speed
    public float moveSpeed = 5f;
    // Are we moving?
    private bool isMoving = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same z-coordinate

        // Calculate direction from player to mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Determine the appropriate animation based on angle
        UpdateDirectionAnimation(direction);

        // Handle movement (optional)
        HandleMovement(direction);
    }

    private void UpdateDirectionAnimation(Vector2 direction)
    {
        // Calculate angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Normalize the angle to 0-360 range
        if (angle < 0) angle += 360;

        // Determine direction based on angle (8 directions)
        string newDirection;

        if (angle >= 337.5f || angle < 22.5f)
            newDirection = ANIM_RIGHT;
        else if (angle >= 22.5f && angle < 67.5f)
            newDirection = ANIM_UP_RIGHT;
        else if (angle >= 67.5f && angle < 112.5f)
            newDirection = ANIM_UP;
        else if (angle >= 112.5f && angle < 157.5f)
            newDirection = ANIM_UP_LEFT;
        else if (angle >= 157.5f && angle < 202.5f)
            newDirection = ANIM_LEFT;
        else if (angle >= 202.5f && angle < 247.5f)
            newDirection = ANIM_DOWN_LEFT;
        else if (angle >= 247.5f && angle < 292.5f)
            newDirection = ANIM_DOWN;
        else
            newDirection = ANIM_DOWN_RIGHT;

        // Update animation if direction changed
        if (newDirection != currentDirection)
        {
            currentDirection = newDirection;

            // Play the appropriate animation
            animator.Play(currentDirection);
        }
    }

    private void HandleMovement(Vector2 direction)
    {
        // Check for movement input (optional - you can remove this if you just want sprite direction)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        isMoving = horizontalInput != 0 || verticalInput != 0;

        // Set the animator's "IsMoving" parameter if you have one
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            // Move character based on input
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}