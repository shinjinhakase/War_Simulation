using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cursor : MonoBehaviour{

    [SerializeField]
    Tilemap tilemap;
    SpriteRenderer spriteRenderer;

    void Start(){

        spriteRenderer=GetComponent<SpriteRenderer>();

    }
    
    void Update(){
        
        switch(TacticsManager.status){

            case TacticsManager.Status.view:

                spriteRenderer.color=new Color32(255,255,255,255);
                Move();

            break;

            case TacticsManager.Status.select:

                Move();

            break;

            case TacticsManager.Status.action:

                spriteRenderer.color=new Color32(255,255,255,0);

            break;

            case TacticsManager.Status.attack:
            break;

        }

    }

    void Move(){

        Vector2 cursorPosition=transform.position;
        var cellBounds=tilemap.cellBounds;

        if(Input.GetKeyUp(KeyCode.UpArrow)&&cursorPosition.y<cellBounds.max.y-1){

            cursorPosition.y+=1;

        }

        if(Input.GetKeyUp(KeyCode.DownArrow)&&cursorPosition.y>0.5){

            cursorPosition.y-=1;

        }
        
        if(Input.GetKeyUp(KeyCode.RightArrow)&&cursorPosition.x<cellBounds.max.x-1){

            cursorPosition.x+=1;

        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow)&&cursorPosition.x>0.5){

            cursorPosition.x-=1;

        }

        transform.position=cursorPosition;

    }

}