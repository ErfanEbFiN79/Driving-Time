using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] bool isMainMenu;
    //[System.Serializable]
    public  UnityEvent  gamePauseEvent, GameResumeEvent, PlayerDeathEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Y))
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
        // if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    if (isPaused)
        //    {
        //        ResumeGame();
        //    }
        //    else
        //    {
        //        PauseTheGame();
        //    }
        //}
    }


    public void PauseTheGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        gamePauseEvent.Invoke();
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        GameResumeEvent.Invoke();
    }
}
