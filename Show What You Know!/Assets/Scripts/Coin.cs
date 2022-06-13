using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameObject parentObj;
    public AudioClip clip;

    void Awake()
    {
        parentObj = transform.parent.gameObject;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            GameUI.coinCount += 1;
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(parentObj);
        }
    }

    private void OnBecameInvisible(){
        Destroy(parentObj);
    }

}
