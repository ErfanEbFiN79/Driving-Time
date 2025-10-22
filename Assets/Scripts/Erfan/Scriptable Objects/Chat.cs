using UnityEngine;

[CreateAssetMenu(fileName = "Chat", menuName = "Scriptable Objects/Chat")]
public class Chat : ScriptableObject
{
    public string writer;
    public Sprite sprite;
    public int writerId;
    [TextArea] public string note;
}
