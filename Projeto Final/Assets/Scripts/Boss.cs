using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
  
    public bool walk;
    public float movimentoX;
    public Animator anime;
    public Rigidbody2D RbPlayer;
    public float maxSpeed;
    public bool facingRight;
    public BoxCollider2D coliderChao;
    public Transform LL;
    public Transform LR;
    public Transform LM;
    public Transform groundCheck;
    public bool grounded;
    public bool pontoLR;
    public bool pontoLM;
    public bool magiaLancada;
    public bool spellcast;
    public int contadorMagia;

    // Use this for initialization
    void Start()
    {
        walk = false;
        pontoLR = false;
        pontoLM = false;
        magiaLancada = false;
        contadorMagia = 0;

        
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
                SoundController.playSound(soundFX.LAUGTH);

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

    }

    void OnTriggerStay2D(Collider2D col)
    {

    }

    void OnTriggerExit2D(Collider2D col)
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
     
    }

    void OnCollisionStay2D()
    {

    }

    void OnCollisionExit2D(Collision2D col)
    {

    }
}
