using System;
using UnityEngine;

[Serializable]

public class LaptopOS1 : MonoBehaviour
{
    #region Variables

    [Header("Color System")]
    [SerializeField] private Light[] colorOfDesk;
    #endregion

    #region Buttons

    public void ChangeColor(int code)
    {
        foreach (var light1 in colorOfDesk)
        {
            switch (code)
            {
                case 0:
                    light1.color = Color.red;
                    break;
                case 1:
                    light1.color = Color.blue;
                    break;
                case 2:
                    light1.color = Color.green;
                    break;
                case 3:
                    light1.color = Color.magenta;
                    break;
            }

            //light1.intensity = 0.35f;
        }
    }
    #endregion
}
