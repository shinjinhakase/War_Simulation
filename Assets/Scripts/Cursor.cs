using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour{
    
    void Start(){ 
    }

    void Update(){
        
        Vector2 currentPosition=transform.position;

        if(Input.GetKeyUp(KeyCode.UpArrow)){

            currentPosition.y+=1;

        }

        if(Input.GetKeyUp(KeyCode.DownArrow)){

            currentPosition.y-=1;

        }
        
        if(Input.GetKeyUp(KeyCode.RightArrow)){

            currentPosition.x+=1;

        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow)){

            currentPosition.x-=1;

        }

        transform.position=currentPosition;

    }

}