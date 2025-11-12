using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float xInput;
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float jumpForce = 5;

    bool facingRight = true;

    bool grounded;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundMask;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;

    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();   
        myAnimator = GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");


        Vector2 inputDirection = new Vector2(xInput, 0).normalized;

        //transform.localScale = new Vector2(xInput, 1);

        myRigidbody2D.linearVelocity = new Vector2(inputDirection.x * walkSpeed, myRigidbody2D.linearVelocityY);

        CheckGround();

        if(xInput == 0 && grounded)
        {

            myAnimator.SetBool("IsRunning", false);

        }
        else
        {
            myAnimator.SetBool("IsRunning", true);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            myRigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        #region Flip

        if (xInput < 0 && facingRight == true)
        {
            Flip();
            facingRight = false;
        }

        if (xInput > 0 && facingRight == false)
        {
            Flip();
            facingRight = true;
        }

        #endregion

    }

    void Flip()
    {

        // V�nd sprite:n genom att spegla den p� x-axeln
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.35f, groundMask);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Bugg")
        {

            gameManager.AddBuggs(1);
            Destroy(collision.gameObject);

        }

    }
}
