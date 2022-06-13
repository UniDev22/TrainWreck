using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public GameObject parentObj;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnBecameInvisible(){
        Destroy(parentObj, .5f);
    }

}
