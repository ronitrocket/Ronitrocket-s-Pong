using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("SetVelocity", 3);
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        /*if (collision.transform.parent.GetComponent<Paddle>() && !collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "DownCollider")
        {
            Vector3 dir = new Vector3(1, 0, -1).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else if (collision.transform.parent.GetComponent<Paddle>() && !collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "ForwardCollider")
        {
            Vector3 dir = new Vector3(1, 0, 0).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else if (collision.transform.parent.GetComponent<Paddle>() && !collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "UpCollider")
        {
            Vector3 dir = new Vector3(1, 0, 1).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else if (collision.transform.parent.GetComponent<Paddle>() && collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "DownCollider")
        {
            Vector3 dir = new Vector3(-1, 0, -1).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else if (collision.transform.parent.GetComponent<Paddle>() && collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "ForwardCollider")
        {
            Vector3 dir = new Vector3(-1, 0, 0).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else if (collision.transform.parent.GetComponent<Paddle>() && collision.transform.parent.GetComponent<Paddle>().isPaddle2 && collision.transform.name == "UpCollider")
        {
            Vector3 dir = new Vector3(-1, 0, 1).normalized;

            rb.velocity = dir * Mathf.Max(lastFrameVelocity.magnitude, minVelocity);
        }
        else {
            Bounce(collision.contacts[0].normal);
        }*/

        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    float hitFactor(Vector3 ballPos, Vector3 racketPos, float racketHeight)
    {

        return (ballPos.z - racketPos.z) / racketHeight;
    }

    private void SetVelocity()
    {
        int rand = Random.Range(1,3);

        if (rand == 1)
        {
            rb.velocity = initialVelocity;
        } else
        {
            rb.velocity = -initialVelocity;
        }
    }
}