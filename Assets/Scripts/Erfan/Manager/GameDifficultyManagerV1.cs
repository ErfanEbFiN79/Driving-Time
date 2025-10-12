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
        SpeedOfGame += (Time.deltaTime) / 10;
    }

    private void ManageSpeedOfCreateBlocks()
    {
        SpeedOfCreateBlocks -= (Time.deltaTime * SpeedOfCreateBlocks) / 10000;
    }

    #endregion

}
