using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	Animator anim;
	private Rigidbody2D rb2d;

//	bool facingRight = true;
	float maxSpeed = 6f;
	float jumpForce = 800f;
	float kbForce = 500f;

	bool grounded = false;
	float groundRadius = 0.2f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public testHP healthScript;

	public Collider2D meleeHitbox;
	private bool melee = false;
	private float attackTimer = 0;
	private float attackCD = 0.2f;

	void Awake() {
		meleeHitbox.enabled = false;
	}

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (grounded && Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool ("Grounded", false);
			rb2d.AddForce(new Vector2(0, jumpForce));
		}


		if (Input.GetKeyDown ("q") && !melee) { 
			melee = true;
			attackTimer = attackCD;
			meleeHitbox.enabled = true;
		}

		if (attackTimer > 0) {
			attackTimer -= Time.deltaTime;
		} else {
			melee = false;
			meleeHitbox.enabled = false;
		}

		anim.SetBool ("Melee", melee);

/*
		if (maxSpeed > 0 && !facingRight) {
			Flip ();
		} else if (maxSpeed < 0 && facingRight) {
			Flip ();
		}
*/
	}



	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Grounded", grounded);

		float curSpeed = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (curSpeed));
		rb2d.velocity = new Vector2 (curSpeed * maxSpeed, rb2d.velocity.y);
	}

/*
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
*/


	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == "Enemy") {
			healthScript.UpdatePlayerHP ();

			rb2d.AddForce(new Vector3 (kbForce, kbForce));
		}
	}
}
