using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCamerController : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] GameObject first_MainMenuObject;
    [SerializeField] GameObject[] everyActivator;

    private void Awake()
    {
        _mainCamera = Camera.main;
        foreach (GameObject item in everyActivator)
        {
            item.SetActive(false);
        }
        first_MainMenuObject.SetActive(true);
    }



    public void MoveBetweenMenus(GameObject menuactivator)
    {
        foreach (GameObject item in everyActivator)
        {
            item.SetActive(false);
        }
        first_MainMenuObject.SetActive(false);
        menuactivator.SetActive(true);
    }    
    public void BackToMainMenu()
    {
        print("Its Click");
        foreach (GameObject item in everyActivator)
        {
            item.SetActive(false);
        }
        first_MainMenuObject.SetActive(true);
    }
}