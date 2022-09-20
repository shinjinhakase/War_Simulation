using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TacticsManager : MonoBehaviour{
    
    int x,y;

    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    GameObject cursor;

    public Text Test;

    void Start(){

        x=0;
        y=0;

    }

    void Update(){

        InputCheck();

        Test.text="x:"+x.ToString()+"\ny:"+y.ToString();

    }

    void InputCheck(){

        Vector2 cursorPosition=cursor.transform.position;
        var cellBounds=tilemap.cellBounds;

        if(Input.GetKeyUp(KeyCode.UpArrow)&&y<cellBounds.max.y-1){

            y+=1;
            cursorPosition.y+=1;

        }

        if(Input.GetKeyUp(KeyCode.DownArrow)&&y>0){

            y-=1;
            cursorPosition.y-=1;

        }
        
        if(Input.GetKeyUp(KeyCode.RightArrow)&&x<cellBounds.max.x-1){

            x+=1;
            cursorPosition.x+=1;

        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow)&&x>0){

            x-=1;
            cursorPosition.x-=1;

        }

        cursor.transform.position=cursorPosition;

    }

}