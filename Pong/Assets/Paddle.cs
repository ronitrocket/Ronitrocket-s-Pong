using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private Vector3 direction;
    public float speed;
    public bool isPaddle2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W) && !isPaddle2)
        {

            direction = Vector3.forward;
        } else if (Input.GetKey(KeyCode.S) && !isPaddle2)
        {

            direction = -Vector3.forward;
        } else if (Input.GetKey(KeyCode.UpArrow) && isPaddle2)
        {

            direction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && isPaddle2)
        {

            direction = -Vector3.forward;
        }


        if (Input.GetKeyUp(KeyCode.W) && !isPaddle2)
        {

            direction = Vector3.zero;
        }
        else if (Input.GetKeyUp(KeyCode.S) && !isPaddle2)
        {

            direction = Vector3.zero;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && isPaddle2)
        {

            direction = Vector3.zero;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isPaddle2)
        {

            direction = Vector3.zero;
        }


        transform.Translate(direction * speed * Time.deltaTime);
    }
}
