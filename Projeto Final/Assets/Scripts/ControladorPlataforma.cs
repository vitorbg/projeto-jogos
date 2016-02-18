using UnityEngine;
using System.Collections;

public class ControladorPlataforma : MonoBehaviour
{

    public Transform posicaoInicial;
    public Transform posA;
    public Transform posB;
    public float speed;
    private float startTime;
    private float journeyLenght;
    int idMovimento;
    public Transform objeto;

    // Use this for initialization
    void Start()
    {
        objeto.position = posicaoInicial.position;
        startTime = Time.time;
        idMovimento = 1;


    }

    void FixedUpdate()
    {
        float dist = (Time.time - startTime) * speed;
        float journey = dist / journeyLenght;


        if (idMovimento == 1)
        {
            objeto.position = Vector3.Lerp(posA.position, posB.position, journey);
            if (objeto.position == posB.position)
            {
                movimento2();
            }

        }
        else if (idMovimento == 2)
        {
            objeto.position = Vector3.Lerp(posB.position, posA.position, journey);
            if (objeto.position == posA.position)
            {
                movimento1();
            }
        }
    }

    void movimento1()
    {
        idMovimento = 1;
        startTime = Time.time;
        journeyLenght = Vector3.Distance(posA.position, posB.position);
    }

    void movimento2()
    {
        idMovimento = 2;
        startTime = Time.time;
        journeyLenght = Vector3.Distance(posB.position, posA.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}