using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    NodeSpawner nodeSpawner;
    GameObject temp;
    GameObject _temp; 
       
    public float[] XSpawns;
    public Vector2 obstacleMinMax;
    public Vector2 coinMinMax;

    public GameObject obstaclePrefab;
    public GameObject[] coinSets;



    int generateNumber = 1;

    private void Awake()
    {

        RandomizeObstacleGeneration();  
        RandomizeCoinSpawns();           
             
    }
    void Start()
    {
        nodeSpawner = GameObject.FindObjectOfType<NodeSpawner>();
      
    }
    private void OnTriggerExit(Collider other){
        nodeSpawner.SpawnTile();
        Destroy(gameObject, 1f);  
    }      
    void RandomizeObstacleGeneration(){
        if(temp != null || _temp != null){
            return;
        }
        int obstacleRNG = (int)Random.Range(obstacleMinMax.x, obstacleMinMax.y);
        if(obstacleRNG != generateNumber){
            return;
        }
        int randomObsLocation = Random.Range(0, XSpawns.Length);
        if (obstacleRNG == generateNumber){
            temp = (GameObject)Instantiate(obstaclePrefab, new Vector3(XSpawns[randomObsLocation], 0, transform.position.z), Quaternion.identity);
        }

    }
    void RandomizeCoinSpawns(){
        if(_temp != null || temp != null){
            return;
        }
        int coinRNG = (int)Random.Range(coinMinMax.x, coinMinMax.y);          
        if(coinRNG != generateNumber){
            return;
        }

        int coinSetsRNG = (int)Random.Range(0, coinSets.Length);      
        int randomCoinLocation = Random.Range(0, XSpawns.Length);
        if(coinRNG == generateNumber){
            _temp = (GameObject)Instantiate(coinSets[coinSetsRNG], new Vector3(XSpawns[randomCoinLocation], 0.5f, transform.position.z), Quaternion.identity);
        }

    }

    
}
