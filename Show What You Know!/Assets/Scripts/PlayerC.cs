using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public float speed;
    public Vector3 laneOffset;
    public float altitudeSpeed;
    public float waitTime;
    public bool devMode = false;


    private bool canMove = true;
    private bool canMove_ = true;
    [HideInInspector]
    public bool isDead = false;  
    bool isRolling = false;  
    bool isJumping = false;
    int jumpCount = 0;
    int rollCount = 0;
    private bool neverDone = true;




    void Start()
    {

    }


    void Update()
    {
        #region Jump Mechanic           
        if(Input.GetKeyDown(KeyCode.Space) && !isRolling && !isDead){
            if(jumpCount != 1){   
                StartCoroutine(Jump());
            }

        }
        #endregion
        #region Movement

        if(Input.GetKeyDown(KeyCode.A)){
                var ableToMove = AllowMovement();
                if(ableToMove){
                    transform.position = transform.position + -laneOffset;

                }
                
            }
        if(Input.GetKeyDown(KeyCode.D)){
                var ableToMove_ = AllowMovement_();
                if(ableToMove_){
                    transform.position = transform.position + laneOffset;
                }
            }
        #endregion
        #region Roll Mechanic
        if(Input.GetKeyDown(KeyCode.S) && !isJumping && !isDead){
            if(rollCount != 1){
                StartCoroutine(Roll());
            }
        }
        #endregion
        #region Death System
        if(neverDone){
            if(isDead && !devMode){
                //TODO: play death animation, go back to main menu
                canMove = false;
                canMove_ = false;
                transform.Rotate(-90, 0, 0, Space.World);
                speed = 0;
                neverDone = false;
            }            
        }

        #endregion
        if(Input.GetKeyDown(KeyCode.Return)){
            devMode = !devMode;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);        
        
    }
    IEnumerator Jump(){
        transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        jumpCount++;
        isJumping = true;
        yield return new WaitForSeconds(waitTime);
        transform.position = new Vector3(transform.position.x, .75f, transform.position.z);
        isJumping = false;
        yield return new WaitForSeconds(.02f);
        jumpCount--;
    }
    IEnumerator Roll(){
        transform.Rotate(90, 0, 0);
        rollCount++;
        isRolling = true;
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(-90, 0 ,0);
        isRolling = false;
        yield return new WaitForSeconds(.02f);
        rollCount--;
    }
    #region Ineffecient Movement Detect System
    bool AllowMovement(){
        if(!isDead){
            if(transform.position.x == -laneOffset.x){
                canMove = false;
            }
            else{
                canMove = true;
            }
                        
        }
        return canMove;

    }
    bool AllowMovement_(){
        if(!isDead){
            if(transform.position.x == laneOffset.x){
                canMove_ = false;
            }
            else{
                canMove_ = true;
            }
                            
        }
        return canMove_;
    }
    #endregion      
}
