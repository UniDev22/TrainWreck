using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerC playerC;
    private void Awake()
    {
        playerC = GameObject.FindObjectOfType<PlayerC>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && playerC.devMode == false){
            playerC.isDead = true;
        }
    }
}
