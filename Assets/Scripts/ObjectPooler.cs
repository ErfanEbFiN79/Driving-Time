using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler currentInstance;
    [SerializeField] GameObject[] sectionPrefabArray;
    [SerializeField] List<GameObject> sectionList;
    [SerializeField] GameObject[] stationaryObstaclesArray;
    [SerializeField] List<GameObject> stationaryObsticalesList;
    [SerializeField] GameObject[] movingObsticalesArray;
    [SerializeField] List<GameObject> movingObsticalesList;
    [SerializeField] sbyte numberOfObsticales = 10;
    [SerializeField] int searchIndex = 0;
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
        stationaryObsticalesList = new List<GameObject>();
        movingObsticalesList = new List<GameObject>();
        

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
        if (stationaryObstaclesArray.Length > 0)
        {
            for (int i = 0; i < numberOfObsticales; i++)
            {
                GameObject temp = Instantiate(stationaryObstaclesArray[Random.Range(0, stationaryObstaclesArray.Length)]);
                stationaryObsticalesList.Add(temp);
                temp.SetActive(false);
            }
        }
        if (movingObsticalesArray.Length > 0)
        {
            for (int i = 0; i < numberOfObsticales; i++)
            {
                GameObject temp = Instantiate(movingObsticalesArray[Random.Range(0, movingObsticalesArray.Length)]);
                movingObsticalesList.Add(temp);
                temp.SetActive(false);
            }
        }
    }



    public GameObject GiveMeASection()
    {
        int randomIndex = Random.Range(0, sectionList.Count);
        int maxnumberofTry = 4,thisnumberoftry=0;
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

    public GameObject GiveMeAnObstacle(ObstacleType type)
    {
        List<GameObject> listToSearch=new List<GameObject>();
        if(type== ObstacleType.moving)
        {
            listToSearch = movingObsticalesList;
        }
        if (ObstacleType.stationary == type)
        {
            listToSearch = stationaryObsticalesList;
        }
        int counter = 0;
        while (counter < numberOfObsticales && listToSearch.Count>0)
        {
            if (!listToSearch[searchIndex].activeInHierarchy)
            {
                listToSearch[searchIndex].SetActive(true);
                return listToSearch[searchIndex];
            }
            else
            {
                searchIndex = (searchIndex + 1) % listToSearch.Count;
            }
            counter++;
        }
        return null;
        //if(obs)
    }
}




public enum ObstacleType { moving , stationary}
