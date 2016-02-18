using UnityEngine;
using System.Collections;

public class arrowController : MonoBehaviour {
	
	public float bulletSpeed = 5f;
    private int vidaFlecha = 0;
	void Update () {
		transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        vidaFlecha++;
        if(vidaFlecha == 200)
        {
            Destroy(gameObject);
        }
	}

	void OnBecameInvisible () {
		this.gameObject.SetActive(false);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "inimigo")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "inimigofase2")
        {
            Destroy(col.gameObject);
        }


        if (col.gameObject.tag == "inimigofaseboss")
        {
            Destroy(col.gameObject);
            Application.LoadLevel("EndGame");
        }

    }






}
