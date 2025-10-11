using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnerSystem : MonoBehaviour
{
    #region Variables

    [Header("Setting")]
    [SerializeField] private GameObject[] spawnedObjects;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Vector3 firstSpawnPosition;
    [SerializeField] private Vector3 secondSpawnPosition;
    [SerializeField] private bool workWithSides;
    
    private Vector3 spawnPosition;

    #endregion

    #region Unity Methods

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnDelay);
    }

    #endregion
    
    #region Methods

    private void Spawn()
    {
        int selectNumber = RandomNumber(0, spawnedObjects.Length);
        GameObject spawnedObject = spawnedObjects[selectNumber];
        if (!workWithSides)
        {
            spawnPosition = new Vector3(
                RandomNumber(firstSpawnPosition.x, secondSpawnPosition.x, true),
                RandomNumber(firstSpawnPosition.y, secondSpawnPosition.y, true),
                RandomNumber(firstSpawnPosition.z, secondSpawnPosition.z, true)
            );
        }
        else
        {
            int r = Random.Range(0, 2);
            spawnPosition = r == 0 ? firstSpawnPosition : secondSpawnPosition;
        }
        


        Instantiate(spawnedObject, spawnPosition, spawnedObject.transform.rotation);
    }
    
    #endregion

    #region Helper

    private int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    
    private float RandomNumber(float min, float max, bool beFloat)
    {
        return Random.Range(min, max);
    }

    #endregion
}
