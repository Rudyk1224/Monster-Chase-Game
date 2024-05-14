using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //this serialize field makes private variables (1 line below it) accesible in the game's terminal
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private bool isGrounded = true;
    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private string WALK_ANIMATION = "Walk"; //this name Walk needs to EXACTLY match the name for the boolean in the animator
    private string GROUND_TAG = "Ground"; //Again, Ground needs to exactly match the ground tag
    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update() // Update is called every frame (60 frames per 1 second)
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate() //FixedUpdate is not called every frame. Its only called a fixed number (to edit: go to edit --> project settings --> time --> fixed timestep. We use FixedUpdate to do physics calculations (like rigidbody)
    {
        
    }
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw gets input when we press left ( returns -1) or right arrow ( returns 1) (or equivalently a and d). if we press nothing, it returns 0
        //Note: if we were to use GetAxis, it wouldn't directly from 0 to 1 or -1 to 1. It would go 0 --> 0.11 --> 0.13 ... --> 1
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
        //moveForce allows you to control how fast the player goes
        //Time.deltaTime is the seconds between frames (60 frames per second), which allows the motion to be much smoother and prevents the player from being the flash

    }
    void AnimatePlayer()
    {
        if(movementX > 0) //we are going to the right side
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if(movementX < 0) //we are going to the left side
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }  
        else //we are not moving
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) //this bit of code is platform neutral (on computers it will be jump, on xbox itll be the default jump button like x
            //GetButton will return true --> when button is held down (i.e: the space bar is held down)
            //GetButtonDown will return true --> when you press down on a button
            //GetButtonUp will return true --> when you release your finger from the button (i.e: release your finger from the space bar)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
          
            //vector 2 denotes --> it has a x and y axis (vector 3 --> x, y and z axis
            //jumpForce adds a force in the y direction
            //ForceMode2D.Impulse adds physics to the player and pushes him instantly upwards
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //This function detects collisions between the player and another object called collision
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) //get access to the tag of the ground game object
            isGrounded = true;
        
        if (collision.gameObject.CompareTag(ENEMY_TAG)) //if collision (some game object) collides with the game object with the tag enemy
            Destroy(gameObject); //gameObject is the class Player's game object (this.gameObject)
        
        //OnCollisionEnter2D is a SOLID collision detecter which means the objects cant pass through each other
    }

    private void OnTriggerEnter2D(Collider2D collision) //another method for detecting collisions
    {
        if (collision.CompareTag("Enemy")) //But the difference is, Collider2D can acess comparetag right away without .gameObject (unlike Collision 2D)
            Destroy(gameObject);

        //Note: If the if statement has just 1 line, you can remove brackets

        //Another difference with OnTriggerEnter2D is that the trigger button on the colliding game object must be checked
        //Another difference with OnTriggerEnter2D is that it's not a solid collider, things can pass through it
    }
}
