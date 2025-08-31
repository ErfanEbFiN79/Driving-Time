using UnityEngine;

[CreateAssetMenu(fileName = "Mission2", menuName = "Scriptable Objects/Mission2")]
public class Mission2 : ScriptableObject
{
    public string nameMission;
    public string description;
    public string codeNeedCheck;
    public int levelAdd;
    public bool isDone;
    public bool active;
}
