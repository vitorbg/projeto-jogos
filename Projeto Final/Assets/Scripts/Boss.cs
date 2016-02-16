using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

   // public camera cam;

  
    public bool walk;
    public float movimentoX;
    public Animator anime;
    public Rigidbody2D RbPlayer;
    public float maxSpeed;
    public bool facingRight;
    public float jumpForce;
    public BoxCollider2D coliderChao;
    public bool DoubleJump;
    public Transform LL;
    public Transform LR;
    public Transform LM;

    public float transition;
    private float x;
    private float y;
    public Transform groundCheck;
    public bool grounded;
    public LayerMask WhatIsGround;
    public bool pontoLR;
    public bool pontoLM;
    public bool magiaLancada;
    public bool spellcast;
    public bool wallcheck;
    public int contadorMagia;

    private int timeAndar;

    // Use this for initialization
    void Start()
    {
        walk = false;
        timeAndar = 0;
        pontoLR = false;
        pontoLM = false;
        magiaLancada = false;
        contadorMagia = 0;

        //      cam = FindObjectOfType(typeof(camera)) as camera;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        anime.SetBool("walk", walk);
        anime.SetBool("grounded", grounded);
        anime.SetBool("spellcast", spellcast);
        anime.SetFloat("speedY", RbPlayer.velocity.y);




        if (transform.position.x > LM.position.x)
        {
            if (magiaLancada)
            {
                contadorMagia++;
                if(contadorMagia ==80) {
                    pontoLM = false;
                    spellcast = false;
                }
                
            }
            else
            {
                pontoLM = true;
            }
        }


        if (pontoLM)
        {
            spellcast = true;
            magiaLancada = true;
            RbPlayer.velocity = new Vector2(0, RbPlayer.velocity.y);
           
        }
        else {
            if (pontoLR == false)
            {
                if (RbPlayer.position.x > LR.position.x)
                {
                    pontoLR = true;

                }
                else
                {
                    movimentoX = 1;
                    RbPlayer.velocity = new Vector2(movimentoX * maxSpeed, RbPlayer.velocity.y);
                }

            }
            else
            {
                if (RbPlayer.position.x < LL.position.x)
                {
                    pontoLR = false;


                    magiaLancada = false;
                    pontoLM = false;
                    contadorMagia = 0;
                    
                }
                else
                {
                    movimentoX = -1;
                    RbPlayer.velocity = new Vector2(movimentoX * maxSpeed, RbPlayer.velocity.y);
                }
            }
        }


        if (movimentoX != 0)
        {
            walk= true;
        }
        else {
            walk = false;
        }

       

        if (movimentoX > 0 && !facingRight)
        {
            Flip();
        }
        else if (movimentoX < 0 && facingRight)
        {

            Flip();
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, WhatIsGround);

        if (grounded == true)
        {

            DoubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && (grounded || !DoubleJump))
        {

            //     SoundController.playSound(soundFX.JUMP);
            RbPlayer.velocity = new Vector2(0, 0);
            RbPlayer.AddForce(new Vector2(0, jumpForce));

            if (!grounded && !DoubleJump)
            {

                DoubleJump = true;
            }
        }

       

    }



    void Flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "moeda")
        {
            Destroy(col.gameObject);
        }

        if (col.tag == "veneno")
        {
            gameObject.SetActive(false);
        }

        if (col.tag == "ajustecamera")
        {
            //       cam.ajusteY = 0;
        }
 


    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "gatilho" && col.tag != "ajustecamera" && col.tag != "interacao")
        {
            wallcheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        wallcheck = false;
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "plataformamovel")
        {
            transform.SetParent(col.gameObject.transform);
        }

        //Debug.Log ("Entrei no colisor");
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
