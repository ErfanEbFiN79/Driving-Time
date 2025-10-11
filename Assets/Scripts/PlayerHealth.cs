using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currenthealth, maxHealth, damageAmount;
    [SerializeField] UnityEvent takenDamageEvent;

    [SerializeField] HealthBar healthBarCode;
    [SerializeField] float backwardForce;

    private void Start()
    {
        currenthealth = maxHealth;
        if (healthBarCode != null)
        {
            healthBarCode.SetMaxValueOfSlider(maxHealth);
            healthBarCode.SetSliderValues(maxHealth);
        }
    }
    public void TakenDamage()
    {
        currenthealth -= damageAmount;
        //Debug.Log("health =" + currenthealth);
        if (currenthealth <= 0)
        {
            currenthealth = 0f;
            //excute player death functions
            //playerDeathEvent.Invoke();
            PlayerDied();
        }
        healthBarCode.SetSliderValues(currenthealth);
        //updated UI
        takenDamageEvent.Invoke();
    }


    public void PlayerDied()
    {
        GetComponent<CarControlV1>().PlayerHasDied();
    }

    public void ResumeGameAfterPlayerDeath()
    {
        currenthealth = maxHealth;
        healthBarCode.SetMaxValueOfSlider(maxHealth);
        healthBarCode.SetSliderValues(currenthealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakenDamage();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakenDamage();
            Destroy(collision.gameObject);
        }
    }



}
