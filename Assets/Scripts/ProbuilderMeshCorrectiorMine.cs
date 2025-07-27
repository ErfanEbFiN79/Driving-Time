using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbuilderMeshCorrectiorMine : MonoBehaviour
{

    private void OnEnable()
    {
        MeshCollider _mymeshCollider;
        if(TryGetComponent<MeshCollider>(out _mymeshCollider))
        {
            Destroy(_mymeshCollider);
        }
        _mymeshCollider=gameObject.AddComponent<MeshCollider>();
        //_mymeshCollider.isTrigger = true;
    }
}
