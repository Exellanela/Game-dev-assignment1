using UnityEngine;
using System.Collections;

public class testEnemyMovement : MonoBehaviour {

	public float moveSpeed;
/*	float jumpForce = 500f;
	bool grounded = false;
	float groundRadius = 0.2f;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	Animator anim;
*/	private Rigidbody2D rb2d;
	private bool moving;
	private Vector3 moveDirection;

	private float timeNOTMovingTimer;
	public float time2NotMove;
	private float timeMovingTimer;
	public float timeMoving;
	private int JumpOrNah;

	bool facingRight = false;

	public bool bounds;
	public Vector3 minXPos;
	public Vector3 maxXPos;


	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
//		anim = GetComponent<Animator> ();

		timeNOTMovingTimer = Random.Range (time2NotMove * 1, time2NotMove * 2);
		timeMovingTimer = Random.Range (timeMoving * 1, timeMoving * 2);
	}


	void Update() {
		if (moving) {
			timeMovingTimer -= Time.deltaTime;
			rb2d.velocity = moveDirection;

/*
			JumpOrNah = Random.Range (1, 2);
			if (JumpOrNah == 1) {
				rb2d.velocity = moveDirection;
			} else if (JumpOrNah == 2) {
				rb2d.AddForce (new Vector2 (0, jumpForce));
			}
*/


			if (timeMovingTimer < 0f) {
				moving = false;
				timeNOTMovingTimer = Random.Range (time2NotMove * 1, time2NotMove * 2);
			}
		} else {
			timeNOTMovingTimer -= Time.deltaTime;
			rb2d.velocity = Vector2.zero;

			if (timeNOTMovingTimer < 0f) {
				moving = true;
				timeMovingTimer = Random.Range (timeMoving * 1, timeMoving * 2);
				moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, 0, 0);
			}
		}
	}


	void FixedUpdate() {
		if (moveSpeed > 0 && !facingRight) 
			Flip();
		else if (moveSpeed < 0 && facingRight)
			Flip();

//		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
//		anim.SetBool ("Grounded", grounded);

//		if (bounds) {
//			rb2d.position = new Vector3(
//	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
