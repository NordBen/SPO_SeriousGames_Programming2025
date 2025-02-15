using UnityEngine;

public class PhysicsInUnityCubeRB : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 8;
    [SerializeField] float forwardSpeed = 1;
    [SerializeField] float rightSpeed = 1;
    [SerializeField] float UpSpeed = 8;
    [SerializeField] float multiplier = 2;

    Vector2 input;
    [SerializeField] bool isGetAxis = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.up;
    }

    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        input = new Vector2(hori, verti);

        Vector3 inputVelocity = new Vector3(input.x, 0, input.y) * forwardSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) { rb.AddForce(Vector3.forward * forwardSpeed, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-Vector3.right * rightSpeed, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * forwardSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * rightSpeed, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * UpSpeed, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.AddForce(-Vector3.up * (UpSpeed * multiplier), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGetAxis = !isGetAxis;
            Debug.Log(isGetAxis);
        }

        if (isGetAxis)
        {
            rb.AddForce(inputVelocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered Trigger");
        rb.AddForce((Vector3.up * (force * 20)), ForceMode.Impulse);
    }
}
