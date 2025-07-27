using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    [SerializeField] string[] tagsToDiactivate;



    private void OnTriggerEnter(Collider other)
    {
      foreach(string t in tagsToDiactivate)
        {
            if (t == other.tag)
            {
                other.gameObject.SetActive(false);
                return;
            }
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (string t in tagsToDiactivate)
        {
            if (t == collision.gameObject.tag)
            {
                collision.gameObject.SetActive(false);
                return;
            }
        }
    }

}
