using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/Mission")]
public class Mission : ScriptableObject
{
    public enum State
    {
        One,
        Two,
        Three,
    }

    public int year;
    public State state; 
    public int levelAdd;
    [TextArea] public string description;
    public string codeCheck;
    public int targetCode;
}
