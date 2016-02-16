using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    //public Transform player;
    private float x;
    private float y;
    public float transition;
    public bool usaLerp;
    public bool segueY;
    public float ajusteY;
    public Transform LL;
    public Transform LR;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //  x = player.position.x;
        //y = player.position.y;

        //transform.position = new Vector3(x, transform.position.y, transform.position.z);

        //transform.position = new Vector3(x, y, transform.position.z);

        //transform.position = Vector3.Lerp(transform.position, new Vector3(x,y,transform.position.z), transition);


        if (segueY)
        {
            //        y = player.position.y + ajusteY;
        }
        else
        {
            y = transform.position.y;
        }

        //    if (player.position.x > LL.position.x && player.position.x < LR.position.x)
        {

            if (usaLerp)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), transition);
            }
            else
            {
                transform.position = new Vector3(x, y, transform.position.z);
            }

        }

    }
}
