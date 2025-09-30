using UnityEngine;

public class RoadsSystemV1 : MonoBehaviour
{
    #region Variables

    [Header("Settings")]
    [SerializeField] private GameObject[] roadParts;
    [SerializeField] private float distanceRoads;
    [SerializeField] private float destroyDistance;
    [SerializeField] private Vector3 sizeAddCreate;
    [SerializeField] private GameObject lastRoad;

    #endregion
    
    #region My Functions

    public void CreateRoad()
    {
        Vector3 pointCreate = GetPointCreate(lastRoad);
        GameObject roadCreate = roadParts[Random.Range(0, roadParts.Length)];
        GameObject r = Instantiate(roadCreate, pointCreate, roadCreate.transform.rotation);
        r.transform.SetParent(transform);
        lastRoad = r;
    }
    
    #endregion

    #region Helpfunctions

    private Vector3 GetPointCreate(GameObject lastRoadGet)
    {
        lastRoad = lastRoadGet;
        Vector3 lastVector = lastRoad.transform.position;
        lastVector += sizeAddCreate;
        return lastVector;
    }
    

    #endregion
}
