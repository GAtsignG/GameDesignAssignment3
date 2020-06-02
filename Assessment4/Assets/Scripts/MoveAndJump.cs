using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndJump : MonoBehaviour
{
Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private bool isGrounded = true;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;



    void Start()
    {
        if (gameObject.tag == "Player")
        {
          rb = GetComponent<Rigidbody2D>();
        }
        

        additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
          Move();
          Debug.Log(isGrounded);
          if (isGrounded)
          {
          Jump();
          BetterJump();
          }
          
        }
        
        CheckIfGrounded();
    }


    void Move() {
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    // void Jump() {
    //     if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) {
    //         rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //         additionalJumps--;
    //     }
    // }
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded )) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void CheckIfGrounded() {

        if (gameObject.tag != "Player")
        {
          Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        
    
        if (colliders != null) {
            isGrounded = true;
            Debug.Log("isGrounded  " + colliders.name);
            //additionalJumps = defaultAdditionalJumps;
        } 
        else {
            Debug.Log("On air");
            if (isGrounded) {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;          
        }
        
        }
    }
}
