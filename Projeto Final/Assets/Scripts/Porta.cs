using UnityEngine;
using System.Collections;

public class Porta : MonoBehaviour {

    public string cena;

    // Use this for initialization
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            FadeController.fadeOn(1);
            Invoke("carregaCena", 1);
        }
    }

    void carregaCena()
    {
        Application.LoadLevel(cena);
    }
}
