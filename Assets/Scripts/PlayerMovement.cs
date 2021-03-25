using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed of character movement and height of the jump. Set these values in the inspector.
    public float speed;
    public float jumpHeight;
    //delete this if it deosn't work
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    //------------------------
    public GameObject Firepoint;

    //Assigning a variable where we'll store the Rigidbody2D component.
    private Rigidbody2D rb;

    private bool onFloor;
    private bool canJump;

    //-----------------------------------

    public AudioSource catJump;


    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody2D component on the game object where this script is attached.
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //To stop infinite jump: add at the start of every frame. a canJump = false
        //canJump = false;

        //Check if the player is on the floor. If we are, then we are able to jump.
        if (onFloor == true)
        {
            canJump = true;
            
        }
        //to stop infinite jump: or you can also just add an else statement
        else
        {
            canJump = false;
        }


        //If we're able to jump and the player has pressed the space bar, then we jump!
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            //delete this if it doesn't work
            if (playerAnimator != null)
            {
            	playerAnimator.SetTrigger("jump");
            }

            catJump.Play();
            Debug.Log("Jumped!");
        }


        //Movement code for left and right arrow keys.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            //delete this if it doesn't work, take out the If when you have a player sprite
            if(playerSprite != null)
            {
            	playerSprite.flipX = true;
            	//Firepoint.transform.Rotate(0f,180f,0f);
            	
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            //delete this if it doesn't work, take out the If when you have a player sprite
            if(playerSprite != null)
            {
            	playerSprite.flipX = false;
            	//Firepoint.transform.Rotate(0f,0f,0f);
            	
            }
        }
        //ELSE if we're not pressing an arrow key, our velocity is 0 along the X axis, and whatever the Y velocity is (determined by jump)
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //after we've checked everything, then we will activate the animations
        //maginitude is turning the vector2 into a number
        //wrap this code inside a statement, so if you dont have an animator then it wont give you problems
        if(playerAnimator != null)
        {
        	playerAnimator.SetFloat("speed",rb.velocity.magnitude);	
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we collide with an object tagged "floor" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "floor")
        {
            onFloor = true;
            print(onFloor);
            //print statements print to the Console panel in Unity. 
            //This will print the value of onFloor, which is a boolean, so either True or False.
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we exit our collision with the "floor" object, then we are unable to jump.
        if (collision.gameObject.tag == "floor")
        {
            onFloor = false;
            print(onFloor);
        }
    }

    //----------------------
    //to flip the Firepoint
    private void Flip()
    {
    	if (playerSprite.flipX == true) //for facing left
    	{
    		Firepoint.transform.Rotate(0,180,0);
    	}

    	else if (playerSprite.flipX == false) //for facing right
    	{
    		Firepoint.transform.Rotate(0,0,0);
    	}
    }
}