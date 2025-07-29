using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]

public class LaptopOS1 : MonoBehaviour
{
    #region Variables

    [Header("Color System")]
    [SerializeField] private Light[] colorOfDesk;
    [SerializeField] private string codeSaveColorDesk;
    [SerializeField] private Slider setIntensity;
    [SerializeField] private string codeSaveIntensity;
    
    [Header("Music System")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] musics;
    [SerializeField] private string codeSaveMusic;
    
    [Header("PowerSystem")]
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Material[] materialOn;
    [SerializeField] private Material[]  materialOff;
    [SerializeField] private GameObject[] materialOnScreen;
    [SerializeField] private int[] materialWorkOn;
    private Material[] materials;
    
    
    #endregion

    #region Unity Functions

    private void Start()
    {
        LoadData();
        for (int i = 0; i < materialWorkOn.Length; i++)
        {
            TurnOff(i);
        }

    }

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
        }
        SaveData(codeSaveColorDesk, code, true);
    }
    
    public void ChangeIntensity()
    {
        foreach (var light1 in colorOfDesk)
        {
            light1.intensity = setIntensity.value;
        }
        
        SaveData(codeSaveIntensity,setIntensity.value);
    }
    
    public void TurnOn(int code)
    {
        materials = meshRenderers[code].materials;
        materials[materialWorkOn[code]] = materialOn[code];
        meshRenderers[code].materials = materials;
        materialOnScreen[code].SetActive(true);
    }

    public void TurnOff(int code)
    {
        materials = meshRenderers[code].materials;
        materials[materialWorkOn[code]] = materialOff[code];
        meshRenderers[code].materials = materials;
        materialOnScreen[code].SetActive(false);
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    
    
    
    
    #endregion

    #region Managers

    private void SaveData(string code, float value)
    {
        PlayerPrefs.SetFloat(code, value);
    }
    
    private void SaveData(string code, int value, bool intSet)
    {
        if (intSet)
        {
            PlayerPrefs.SetInt(code, value);
        }
        else
        {
            PlayerPrefs.SetFloat(code, value);
        }

    }

    private void LoadData()
    {
        ChangeColor( PlayerPrefs.GetInt(codeSaveColorDesk));
        foreach (var light1 in colorOfDesk)
        {
            light1.intensity = PlayerPrefs.GetFloat(codeSaveIntensity);
        }
    }

    #endregion
}
