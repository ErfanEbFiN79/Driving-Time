using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider hSlider;



    private void Start()
    {
        // hSlider = gameObject.GetComponent<Slider>();
    }



    public void SetSliderValues(float amount)
    {
        hSlider.value = amount;
        //Debug.Log(healthbarSlider.value);
    }

    public void SetMaxValueOfSlider(float amount)
    {
        hSlider.maxValue = amount;
    }
}
