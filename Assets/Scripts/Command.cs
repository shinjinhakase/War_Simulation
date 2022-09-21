using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour{
    
    int select=0;
    
    void Start(){
        
    }

    void Update(){
        
        Vector2 currentPosition=transform.position;

        if(Input.GetKeyUp(KeyCode.UpArrow)&&select!=0){

            select--;
            currentPosition.y+=0.5f;

        }else if(Input.GetKeyUp(KeyCode.DownArrow)&&select!=1){

            select++;
            currentPosition.y-=0.5f;

        }
        
        transform.position=currentPosition;

        if(Input.GetKeyUp(KeyCode.Space)){

            switch(select){

                case 0:

                    Debug.Log("attack!");

                break;

                case 1:

                    Debug.Log("standby");

                break;

            }
            
        }

    }

}