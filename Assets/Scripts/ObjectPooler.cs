using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler currentInstance;
    [SerializeField] GameObject[] sectionPrefabArray;
    [SerializeField] List<GameObject> sectionList;

    private void Awake()
    {
        if (currentInstance == null)
        {
            currentInstance = this;

        }
        else if(currentInstance!=this)
        {
            Destroy(gameObject);
            return;
        }
        sectionList = new List<GameObject>();

    }
    // Start is called before the first frame update
    void Start()
    {
        if (sectionPrefabArray.Length > 0)
        {
            foreach (GameObject temp in sectionPrefabArray)
            {
                sectionList.Add(Instantiate(temp));
                
            }
            foreach (GameObject item in sectionList)
            {
                item.SetActive(false);
            }
        }
        
    }

    public GameObject GiveMeASection()
    {
        int randomIndex = Random.Range(0, sectionList.Count);
        int maxnumberofTry = 10,thisnumberoftry=0;
        while (sectionList[randomIndex].activeInHierarchy &&thisnumberoftry<=maxnumberofTry)
        {
            thisnumberoftry++;
            randomIndex = Random.Range(0, sectionList.Count);

        }
        if (sectionList[randomIndex].activeInHierarchy)
        {
            Debug.Log("new section is being created");
            GameObject temp = Instantiate(sectionPrefabArray[Random.Range(0, sectionPrefabArray.Length)]);
            temp.SetActive(false);
            sectionList.Add(temp);
            temp.SetActive(true);
            return temp;
        }
        else
        {
            sectionList[randomIndex].SetActive(true);
            return sectionList[randomIndex];
        }
      
    }
}