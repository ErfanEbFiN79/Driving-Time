using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarPassTa : MonoBehaviour
{
    #region README!

    /*
     * This car pass work with year and code system
     * Car pass has 300 level
     * When player receive to the 74-year change
     * Code means how mush level player going to get when finished the mission, and we have code 1, 2, 3
     * We select randomly between each group of mission we have
     */

    #endregion
    
    #region Variables

    [Header("Base Settings")]
    [SerializeField] private Mission[] missionsYearOneCode1;
    [SerializeField] private Mission[] missionsYearOneCode2;
    [SerializeField] private Mission[] missionsYearOneCode3;
    
    [SerializeField] private Mission[] missionsYearTwoCode1;
    [SerializeField] private Mission[] missionsYearTwoCode2;
    [SerializeField] private Mission[] missionsYearTwoCode3;
    
    [SerializeField] private Mission[] missionsYearThreeCode1;
    [SerializeField] private Mission[] missionsYearThreeCode2;
    [SerializeField] private Mission[] missionsYearThreeCode3;
    
    public enum Level
    {
        Y1C1,
        Y1C2,
        Y1C3,
        Y2C1,
        Y2C2,
        Y2C3,
        Y3C1,
        Y3C2,
        Y3C3,
    }

    private Level _cLevel;
    
    #endregion

    #region Unity Methods

    // Test Code -->

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print(SendRandomLevel(Level.Y1C1).name);
        }
    }

    // <-- End Test Code 

    #endregion

    #region Send Methods

    public Mission SendRandomLevel(Level level)
    {
        var randomSelect = Random.Range(0, missionsYearOneCode1.Length);
        switch (level)
        {
            case Level.Y1C1:
                if (missionsYearOneCode1[randomSelect]) return missionsYearOneCode1[randomSelect];
                break;

            case Level.Y1C2:
                if (missionsYearOneCode2[randomSelect]) return missionsYearOneCode2[randomSelect];
                break;
            
            case Level.Y1C3: 
                if (missionsYearOneCode3[randomSelect]) return missionsYearOneCode3[randomSelect];
                break;
            
            case Level.Y2C1:
                if (missionsYearTwoCode1[randomSelect]) return missionsYearTwoCode1[randomSelect];
                break;
            
            case Level.Y2C2:
                if (missionsYearTwoCode2[randomSelect]) return missionsYearTwoCode2[randomSelect];
                break;
            
            case Level.Y2C3: 
                if (missionsYearTwoCode3[randomSelect]) return missionsYearTwoCode3[randomSelect];
                break;
            
            case Level.Y3C1:
                if (missionsYearThreeCode1[randomSelect]) return missionsYearThreeCode1[randomSelect];
                break;
            
            case Level.Y3C2:
                if (missionsYearThreeCode2[randomSelect]) return missionsYearThreeCode2[randomSelect];
                break;
            
            case Level.Y3C3:
                if (missionsYearThreeCode2[randomSelect]) return missionsYearThreeCode3[randomSelect];
                break;
        }

        return null;
    }

    #endregion
}