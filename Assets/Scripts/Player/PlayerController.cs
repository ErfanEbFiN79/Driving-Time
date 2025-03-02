using System;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("See and Rotate")] 
    [SerializeField] private Transform viewPoint;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Joystick joystickRotate;
    [SerializeField] private Image[] change;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private bool invertLook;
    [SerializeField] private Vector3 offsetCam;
    [SerializeField] private float minLock;
    [SerializeField] private float maxLock;
    private Camera cam;
    private float verticalRotStore;
    private Vector2 mouseInput;
   
    
    [Header("Move")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private MoveType moveType;
    [SerializeField] private CharacterController cR;
    
    private Vector3 moveDir, movment;
    private float activeMoveSpeed;
    private enum MoveType
    {
        Transform,
        CharacterController
    }
    
    [Header("Jump")]
    [SerializeField] private float gravityMod;

    

 
    #endregion  

    #region Unity Methods

    private void Start()
    {
        cam = Camera.main;
        cR = GetComponent<CharacterController>();
    }

    private void Update()
    {
  
        // Get data
        GetData();
            
        // Rotate
        RotateH();
        RotateV();
        
        // Move
        ManageMove();
        
        //Gravity
        ManageGravity();

        if (GarageManager.instance.panelState)
        {
            joystickRotate.gameObject.transform.localScale = new Vector3(1, 1, 1);
            joystickRotate.gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(1700, 200);
            foreach (Image img in change)
            {
                img.color = new Color(1, 1, 1, 1);
            }
            // transform.LookAt(GarageManager.instance.panelGet.transform);
        }
        else
        {
            joystickRotate.gameObject.transform.localScale = new Vector3(4,4,4);
            joystickRotate.gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(1474, 471);
            foreach (Image img in change)
            {
                img.color = new Color(1, 1, 1, 0);
            }
            if (!joystickRotate.gameObject.activeInHierarchy)
            {
                joystickRotate.gameObject.SetActive(true);
            }
        
        }
    }
    
    private void LateUpdate()
    {   
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }

    #endregion

    #region Data

    private void GetData()
    {
        // Rotate left and right
        mouseInput = new Vector2(joystickRotate.Horizontal, joystickRotate.Vertical) * mouseSensitivity;
        
        // Rotate up and down
        verticalRotStore += mouseInput.y;
        verticalRotStore = Mathf.Clamp(verticalRotStore, minLock,  maxLock);
        
        //Move
        moveDir = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

        float yVel = movment.y;
        movment = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized;
        movment.y = yVel;
        
    }

    #endregion
    
    #region Manage

    private void ManageMove()
    {
        switch (moveType)
        {
            case MoveType.Transform:
                Move();
                break;

            case MoveType.CharacterController:
                MoveCharacterController();
                break;
        }
        
    }

    private void ManageGravity()
    {
        movment.y += Physics.gravity.y * Time.deltaTime * gravityMod;
    }
    
    #endregion

    #region Actions

    
    private void RotateH()
    {
        var rotation = transform.rotation;
        rotation = Quaternion.Euler(
            rotation.eulerAngles.x,
            rotation.eulerAngles.y + mouseInput.x,
            rotation.eulerAngles.z
        );
        transform.rotation = rotation;
    }

    private void RotateV()
    {
        if (!invertLook)
        {
            viewPoint.rotation = Quaternion.Euler(
                verticalRotStore,
                viewPoint.rotation.eulerAngles.y,
                viewPoint.rotation.eulerAngles.z
                );
        }
        else
        {
            viewPoint.rotation = Quaternion.Euler(
                -verticalRotStore,
                viewPoint.rotation.eulerAngles.y,
                viewPoint.rotation.eulerAngles.z
                );
        }
        
    }
    
    private void Move()
    {
        transform.position += movment * moveSpeed * Time.deltaTime;
    }

    private void MoveCharacterController()
    {
        cR.Move(movment * moveSpeed * Time.deltaTime);
    }
    
    #endregion


    
    
    
}
