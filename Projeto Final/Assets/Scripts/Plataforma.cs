using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour {

    public float speed;
    public float x;


    // Use this for initialization
    void Start()
    {
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        x += speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }
}
