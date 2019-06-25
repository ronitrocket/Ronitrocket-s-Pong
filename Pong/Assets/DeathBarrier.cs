using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{

    public GameObject ball;

    public Manager manager;

    public bool isPlayer2Barrier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ball")
        {

            Destroy(other.gameObject);
            Instantiate(ball, Vector3.zero, Quaternion.identity);
            
            if (!isPlayer2Barrier)
            {
                manager.addPlayer2Score();
            } else
            {
                manager.addPlayer1Score();
            }

            manager.ResetPaddles();
        }
    }
}
