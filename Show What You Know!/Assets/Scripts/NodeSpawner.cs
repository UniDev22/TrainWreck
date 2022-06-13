using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    public GameObject nodeTemplate;
    Vector3 nextSpawnPoint;
    public int startingNodeAmt = 15;

    void Start()
    {
        for (int i = 0; i < startingNodeAmt; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {

    }
    public void SpawnTile(){
        GameObject temp = Instantiate(nodeTemplate, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(3).transform.position;
    }
}
