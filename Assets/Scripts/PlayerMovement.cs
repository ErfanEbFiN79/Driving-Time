using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRigidBody;

    [SerializeField] Vector2 moveDirection;
    [SerializeField] float moveSpeed,turnSpeed;
    [SerializeField ]float maxSpeedOnZAxix;

    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }
   

    void Update()
    {
        if (_playerRigidBody.linearVelocity.z > maxSpeedOnZAxix)
        {
            _playerRigidBody.AddForce(Vector3.back * moveSpeed ,ForceMode.Force);
           // Debug.Log(_playerRigidBody.velocity.z);
        }
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        _playerRigidBody.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
        _playerRigidBody.linearVelocity = new Vector3(moveDirection.x*turnSpeed, _playerRigidBody.linearVelocity.y, _playerRigidBody.linearVelocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log( $"I have hit this Collision << {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I hit this trigger << "+other.name);
    }

}
