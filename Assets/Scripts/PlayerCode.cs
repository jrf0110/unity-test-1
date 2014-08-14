// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl
// Blah  balh balhb abl

using UnityEngine;
using System.Collections;

public class PlayerCode : MonoBehaviour {

	//Movement Stuff
    private float horizontalInput;
	private float verticalInput;
	public float maxSpeed = 10f;
	public float maxSpeedHolder;
	//public float velocity;
	private bool horizontalInputing;
	private bool verticalInputing;
	//private bool canHorizontalInput = true;

	//Jumping
	public bool touchingPlatform;
	//public Transform groundCheck;
	//private float groundRadius = 0.5f;
	//public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public bool dubbaJump;

	//Life Stuff
    public bool isActive;

	public int asdf = 1;
	
    // Use this for initialization
    void Start()
    {
		maxSpeedHolder = maxSpeed;

		isActive = true;
    }
	

	//==================UPDATE METHODS======================

	void Jumping()
	{
		if ((touchingPlatform || !dubbaJump))
		{	
			if(Input.GetButtonDown("Jump"))
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
				rigidbody.AddForce(new Vector2(0, jumpForce));
				touchingPlatform = false;

				if(!dubbaJump && !touchingPlatform)
				{
					dubbaJump = true;
				}
			}
		}
	}
	
	//==================UPDATE!!!!======================

	//==================================================

	//==================================================
	void Update () 
    {
		if (isActive)
        {
			if(horizontalInput != 0) horizontalInputing = true;
			else horizontalInputing = false;

			if(verticalInput != 0) verticalInputing = true;
			else verticalInputing = false;

			horizontalInput = Input.GetAxis("Horizontal");
			verticalInput = Input.GetAxis("Vertical");

			Jumping();
		 }
}
	
	//==================END=UPDATE======================

	//==================================================

	//==================================================

	void FixedUpdate()
	{	
		//print ("fixed update: " + Time.deltaTime);
		if(isActive)
		{
			//touchingPlatform = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			if(horizontalInputing) rigidbody.velocity = new Vector3(horizontalInput*maxSpeed, rigidbody.velocity.y,rigidbody.velocity.z);
			if(verticalInputing) rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y,verticalInput*maxSpeed);


			if(touchingPlatform) 
			{
				dubbaJump = false;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			touchingPlatform = true;

		}
	}

}  //Class
