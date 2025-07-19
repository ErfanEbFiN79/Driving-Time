using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 followOffset;
    [SerializeField] float smoothFollowSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //followOffset = this.transform.position-player.position;
    }
   

    // Update is called once per frame
    // private void FixedUpdate()
    // {
    //     this.transform.position = Vector3.Lerp(this.transform.position, player.position + followOffset, smoothFollowSpeed);
    // }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.position + followOffset, smoothFollowSpeed);
    }
}

