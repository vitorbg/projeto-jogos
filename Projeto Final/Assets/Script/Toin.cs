using UnityEngine;
using System.Collections;

public class Toin : MonoBehaviour {

	public bool walk;
	public float maxSpeed;
	public float movimentoX;
	public Rigidbody2D RbPlayer;
	public Animator anime;
	public bool facingRight;
	public float jumpForce;
	public bool DoubleJump;
	public Transform groundCheck;
	public bool grounded;
	public LayerMask WhatIsGround;
	public bool attack;
	public bool wallcheck;
	public float timerAttack;
	public float addSpeed;
	public float walkSpeed;
	public GameObject arrow_prefab;
	public Transform spawnPosition;

	// Use this for initialization
	void Start () {
		wallcheck = false;
		walk = false;
		attack = false;
		walkSpeed = maxSpeed;
		anime.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (wallcheck == false) 
		{
			RbPlayer.velocity = new Vector2 (movimentoX * walkSpeed, RbPlayer.velocity.y);
		}

		movimentoX = Input.GetAxis("Horizontal");
		anime.SetBool("walk", walk);
		anime.SetBool ("Grounded", grounded);
		anime.SetBool ("attack", attack);
	
		// Mover
		if (movimentoX != 0) 
		{
			walk = true;
		} 
		else {
			walk = false;
		}

		// Mover rápido
		if (Input.GetButtonDown ("Fire2")) 
		{
			walkSpeed = maxSpeed + addSpeed;
		}

		if (Input.GetButtonUp ("Fire2")) 
		{
			walkSpeed = maxSpeed;
		}

		//flip do toin
		if (movimentoX > 0 && facingRight) 
		{
			flip ();
		} 
		else if (movimentoX < 0 && !facingRight) {
			flip ();
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.1f, WhatIsGround);

		if (grounded == true) 
		{
			DoubleJump = false;
		}

		if (Input.GetButtonDown ("Jump") && (grounded || !DoubleJump)) 
		{

			RbPlayer.velocity = new Vector2 (0, 0);
			RbPlayer.AddForce (new Vector2 (0, jumpForce));

			if (!grounded && !DoubleJump) {

				DoubleJump = true;
			}

		}


		if (Input.GetButtonDown ("Fire1")) 
		{
			attack = true;
			timerAttack=0;


		}

		if (Input.GetButtonUp ("Fire1") || attack == true) 
		{

			timerAttack = timerAttack + Time.deltaTime;

			if (timerAttack > 1.04f) 
			{
				attack = false;

				if (!facingRight) 
				{
					GameObject thePrefab = Instantiate (arrow_prefab) as GameObject;
					thePrefab.transform.position = spawnPosition.position;
					thePrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (300, 0));
				} 
				else 
				{
					GameObject thePrefab = Instantiate (arrow_prefab) as GameObject;
					thePrefab.transform.position = spawnPosition.position;
					thePrefab.transform.localScale = new Vector3 (thePrefab.transform.localScale.x * -1, thePrefab.transform.localScale.y, thePrefab.transform.localScale.z);
					thePrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-300, 0));
				}

			}

		}

	}

	// Realiza flip do toin
	void flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "inimigo")
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOverFloresta");
        }

        if (col.gameObject.tag == "inimigofase2")
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOverCaverna");
        }


        if (col.gameObject.tag == "inimigofaseboss")
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOverCaverna");
        }





        if (col.gameObject.tag == "plataformamovel")
        {
            transform.SetParent(col.gameObject.transform);
        }
    }


    void OnCollisionStay2D()
    {

        //Debug.Log ("estou no colisor");
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "plataformamovel")
        {
            transform.SetParent(null);
        }
        //Debug.Log ("Sai do colisor");

    }


}
