using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Serializing to show the field inside the editor, tooltip to describe wwhat it is.
    [SerializeField]
    [Tooltip("Speed the player will move in the X axis.")]
    private float movementSpeed;

    [SerializeField]
    [Tooltip("Height the player will jump in the Y axis.")]
    private float jumpHeight;

    // Rigidbody, so that our player has physics.
    private Rigidbody2D rb2d;

    // Animator,  so we can animate our player.
    private Animator anim;

    // Sprite Renderer, so we can render the sprites
    private SpriteRenderer spriteRenderer;

    // Are we facing right?
    private bool facingRight = true;

    // Are we on solid ground?
    private bool grounded = true;


    // Audio for Sound effects
    private AudioSource source;

    [SerializeField]
    private AudioClip jumpSound;


    // Virtual Joystick for our mobile device.
    [SerializeField]
    private Joystick joystick;


    // Using this for initialization
    void Start()
    {
        // Sets the instance fields, to the instance we've got on our object.
        // More info about RigidBody2D here: https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // Defines the move-direction.
        // See more @ https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float move = joystick.Horizontal;

        // Adds velocity to the rigidbody in the move direction multiplied with our speed.
        // See more @ https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
        rb2d.velocity = new Vector2(move * movementSpeed, rb2d.velocity.y);
        

        // Animator
        // See more @ https://docs.unity3d.com/ScriptReference/Animator.SetFloat.html
        anim.SetFloat("Speed", Mathf.Abs(move));

        /*
           If we're facing the negative direction and not facing right, flip the sprite.
           Uses our bool facingRight, to create an "on-off" switch. 
           Also uses our move, if we press D we'd get a positive value, and if we press A we'd get a negative value.
        */
        if (move > 0 && !facingRight)
        {
            facingRight = true;
            spriteRenderer.flipX = false;
        }
        else if (move < 0 && facingRight)
        {
            facingRight = false;
            spriteRenderer.flipX = true;
        }
    }

    // When the player is touching the ground tagged by environment, he sets the bool to true and can jump again.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Environment"))
        {
            grounded = true;
            anim.SetBool("Grounded", true);
        }
    }

    // When the player's not touching the ground anymore, he sets his bool to false and starts running the "Jump" animation.
    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Environment"))
        {
            grounded = false;
            anim.SetBool("Grounded", false);
        }
    }

    public void Jump()
    {
        if(grounded)
        {
            rb2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            grounded = false;
            anim.SetBool("Grounded", false);
            source.clip = jumpSound;
            source.Play();
        }
        
    }
}
