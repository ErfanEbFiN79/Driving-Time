using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] bool isMainMenu;
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite resumeSprite;
    [SerializeField] Image buttonImage;
    //[System.Serializable]
    public  UnityEvent  gamePauseEvent, GameResumeEvent, PlayerDeathEvent;
    // Start is called before the first frame update


    // Update is called once per frame
    // void Update()
    // {
    //     if (!isMainMenu)
    //     {
    //         if (Input.GetKeyDown(KeyCode.Y))
    //         {
    //             if (isPaused)
    //             {
    //                 ResumeGame();
    //             }
    //             else
    //             {
    //                 PauseTheGame();
    //             }
    //         }
    //     }
    //     if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         PlayerPrefs.DeleteAll();
    //     }
    //
    // }


    public void PauseTheGame()
    {
        buttonImage.sprite = resumeSprite;
        Time.timeScale = 0;
        isPaused = true;
        gamePauseEvent.Invoke();
    }
    public void ResumeGame()
    {
        buttonImage.sprite = pauseSprite;
        isPaused = false;
        Time.timeScale = 1f;
        GameResumeEvent.Invoke();
    }

    public void PauseAndResumeGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseTheGame();
        }
    }
    
}
