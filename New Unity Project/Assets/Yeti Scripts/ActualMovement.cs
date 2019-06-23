using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualMovement : MonoBehaviour
{
    public PlayerMovement controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public LayerMask groundLayer;
    public float vecAmount;
    public CircleCollider2D circle;
    float verticalVelocity;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        touchingGround();
        verticalVelocity = Mathf.Abs(body.velocity.y);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("VerticalVelocity", verticalVelocity);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
 
    public void OnCrouching(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void touchingGround() {
        if (!circle.IsTouchingLayers(groundLayer)) {
            animator.SetBool("IsJumping", false);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Application.LoadLevel(Application.loadedLevel);
    }
}
