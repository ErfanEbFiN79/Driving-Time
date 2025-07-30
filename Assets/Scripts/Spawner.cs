using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] Sectionarray;
    [SerializeField] GameObject previusSection;
    [SerializeField] byte numberOfSection;
    [SerializeField] float OffSet=10f;
    [SerializeField] float SectionLenght = 1000f;

    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Midsection"))
        {
            print("midsection");
            if (previusSection != null)
            {
                previusSection.SetActive(false);
                
            }
           
            //previusSection = other.transform.parent.gameObject;
            previusSection = other.transform.gameObject;
            GameObject temp = ObjectPooler.currentInstance.GiveMeASection();
            temp.transform.position = new Vector3(0, other.transform.parent.position.y - 0.01f, other.transform.position.z + OffSet + SectionLenght);
            temp.transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Midsection"))
        {
            print("midsection");
            if (previusSection != null)
            {
                previusSection.SetActive(false);
                
            }
           
            previusSection = other.transform.parent.gameObject;
            GameObject temp = ObjectPooler.currentInstance.GiveMeASection();
            temp.transform.position = new Vector3(0, other.transform.parent.position.y - 0.01f, other.transform.position.z + OffSet + SectionLenght);
            temp.transform.rotation = Quaternion.identity;
        }
    }
}
