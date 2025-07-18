using UnityEngine;

public class CarControllV1 : MonoBehaviour
{
    [Header("Move Setting")]

    public float lateralForce = 300f;

    public float maxLateralSpeed = 5f;

    public float tiltMultiplier = 5f;

    public float rotationSpeed = 1.5f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0);


        float horizontalInput = Input.GetAxis("Horizontal");


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if(touch.position.x < Screen.width / 2)
                    horizontalInput = -1f;
                else if(touch.position.x > Screen.width / 2)
                    horizontalInput = 1f;
            }
        }


        if(Mathf.Abs(rb.linearVelocity.x) < maxLateralSpeed)
        {
            rb.AddForce(Vector3.right * horizontalInput * lateralForce * Time.fixedDeltaTime);
        }


        float tiltAngle = Mathf.Clamp(rb.linearVelocity.x * -tiltMultiplier, -15f, 15f);
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, tiltAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Hit Something

    }
}
