using UnityEngine;

public class GameDifficultyManagerV1 : MonoBehaviour
{
    #region Variables

    [Header("Get Value")]
    public float SpeedOfGame { get; private set; }
    public float SpeedOfCreateBlocks { get; private set; }

    [Header("Manage Speed Of Game")]
    [SerializeField] private float startSpeedOfGame;
    [SerializeField] private float timeIncreaseSpeed;
    
    [Header("Manage Speed Of Create Blocks")]
    [SerializeField] private float startSpeedOfCreateBlocks;
    [SerializeField] private float timeIncreaseCreateBlocks;


    [Header("Add More Speed Manage")] 
    [SerializeField] private float[] speedGoNextStage;
    
    #endregion

    #region Unity Methods

    private void Start()
    {
        SpeedOfGame = startSpeedOfGame;
        SpeedOfCreateBlocks = startSpeedOfCreateBlocks;
    }

    private void Update()
    {
        ManageSpeedOfGame();
        ManageSpeedOfCreateBlocks();
    }

    #endregion

    #region MyMethods

    private void ManageSpeedOfGame()
    {
        if (SpeedOfGame > speedGoNextStage[0])
        {
            SpeedOfGame += (Time.deltaTime) / 10 + 1;
        }
        else if (SpeedOfGame > speedGoNextStage[1])
        {
            SpeedOfGame += (Time.deltaTime) / 10 + 3;
        }
        else if (SpeedOfGame > speedGoNextStage[2])
        {
            SpeedOfGame += (Time.deltaTime) / 10 + 5;
        }
        else
        {
            SpeedOfGame += (Time.deltaTime) / 10;
        }
    }

    private void ManageSpeedOfCreateBlocks()
    {
        SpeedOfCreateBlocks -= (Time.deltaTime * SpeedOfCreateBlocks) / 10000;
    }

    #endregion

}
