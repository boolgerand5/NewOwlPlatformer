using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator anim;

    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 15f; // Serialized field to control character speed
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 50.0f;
    [SerializeField] bool isGrounded = true;

    void Start()
    {
        // Gets references for the rigidbody and animator components.
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            Physics2D.IgnoreLayerCollision(10,15);
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        // Set Animation Parameters.
        anim.SetBool("run", movement != 0);
        anim.SetBool("grounded", isGrounded);

                // Check for "Fire1" input to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }
    }

    private void FixedUpdate()
    {
        // Use the serialized 'speed' field to control character movement
        rigid.velocity = new Vector2(speed * movement, rigid.velocity.y);
        
        // Flip character sprite based on movement direction
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();

        // Handle jump if jumpPressed and grounded
        if (jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        anim.SetTrigger("jump");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    public bool canAttack()
    {
        return movement == 0 && isGrounded;
    }

    void ShootArrow()
    {
        // Create an arrow instance at the player's position or the spawn point
        //GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
    }
}