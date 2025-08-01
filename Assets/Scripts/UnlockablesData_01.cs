using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="SO/Unlockable Data SO",fileName ="Unlockables_Data")]
public class UnlockablesData_01 : ScriptableObject
{
    public UnlockableType type;
    public string unlockableName;
    public int minimumLevelToUnlock;
    public int unlockableObjectCode;
    public Skybox skybox;
    public bool needVip;
    public int codeLevel;
}

//[System.Serializable]
public enum UnlockableType { car,level,skybox};




