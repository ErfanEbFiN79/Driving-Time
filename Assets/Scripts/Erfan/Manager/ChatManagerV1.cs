using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManagerV1 : MonoBehaviour
{
    public Chat chat;
    
    [Header("Need Access")]
    [SerializeField] private Image img;
    [SerializeField] private TMP_Text nameThis;
    [SerializeField] private TMP_Text note;

    private void OnEnable()
    {
        if (chat != null)
        {
            nameThis.text = chat.name;
            note.text = chat.note;
            img.sprite = chat.sprite; 
        }

    }
}
