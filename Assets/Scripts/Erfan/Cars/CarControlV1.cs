using System;
using TMPro;
using UnityEngine;

public class CarControlV1 : MonoBehaviour
{
    #region Variables

    [Header("Move Setting")]
    [SerializeField] private float lateralForce = 300f;
    [SerializeField] private float maxLateralSpeed = 5f;
    [SerializeField] private float tiltMultiplier = 5f;
    [SerializeField] private float rotationSpeed = 1.5f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moreRotateSpeed;
    private Rigidbody rb;
    
    [Header("Ui Controller")]
    [SerializeField] private TMP_Text speedCarText;

    private float ride;

    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    private void Update()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
        UiManager();
        DifficultySystem();
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
                    horizontalInput = (-1 * moreRotateSpeed) * Time.deltaTime;
                else if(touch.position.x > Screen.width / 2)
                    horizontalInput = (1 * moreRotateSpeed) * Time.deltaTime;
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
    
    public void PlayerHasDied()
    {
        print("Player Die");
    }

    private void DifficultySystem()
    {   
        moveSpeed += Time.deltaTime / 10;
    }

    private void UiManager()
    {
        speedCarText.text = moveSpeed.ToString("F1");
    }
}
