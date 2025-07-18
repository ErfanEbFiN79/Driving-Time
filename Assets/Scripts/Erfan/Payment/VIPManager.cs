using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VIPManager : MonoBehaviour
{
    #region Variables

    [SerializeField] [TextArea] private string[] k;
    [SerializeField] [TextArea] private string[] v;
    public bool FullVip { get; private set; }


    public bool LockSystem { get; private set; }
    public bool AdvanceLockSystem { get; private set; }


    #endregion

    #region Unity Methods

    private void Start()
    {
        FullVip = HaveVip();
    }

    #endregion

    #region Request

    public void SendActiveRequest(int state)
    {
        ActiveRequest(state);
    }

    public bool HaveVipRequest()
    {
        return HaveVip();
    }
    

    #endregion

    #region Active

    private void ActiveRequest(int state)
    {
        switch (state)
        {
            case 0:
                FullVip = true;
                FullVip = HaveVip();
                break;
        }
    }

    private bool HaveVip()
    {
        return PlayerPrefs.GetString(k[0]) == v[0];
    }
    

    #endregion
}
