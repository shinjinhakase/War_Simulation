using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour{

    [SerializeField]
    Character chara;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject cursor;

    [SerializeField]
    Grid grid;

    [SerializeField]
    Tilemap tilemap,goundmap;

    [SerializeField]
    TileBase possibleTile;

    List<Vector2> movePossibleList;

    bool isMovePreparation=false;
    bool isDrawChange=false;
    
    void Start(){

        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=chara.sprite;

        TacticsManager.impenetrable.Add(new Vector2(this.transform.position.x,this.transform.position.y));

        movePossibleList=new List<Vector2>();
        
    }

    void Update(){

        if(Input.GetKeyUp(KeyCode.Space)&&isDrawChange==false){

            MovePreparation();
            isDrawChange=true;
            

        }else if(Input.GetKeyUp(KeyCode.Space)&&isDrawChange==true){

            Move();
            isDrawChange=false;

        }
        
    }

    void MovePreparation(){

        if(cursor.transform.position==this.transform.position&&isMovePreparation==false){
            
            //今いる場所をTilemap上の座標に変換する
            int currentPositionOnMap_X=(int)(this.transform.position.x-0.5f);
            int currentPositionOnMap_Y=(int)(this.transform.position.y-0.5f);

            Vector3 currentPositionOnMap_vector3=new Vector3(currentPositionOnMap_X,currentPositionOnMap_Y,0);

            Vector3Int currentPositionOnMap=grid.WorldToCell(currentPositionOnMap_vector3);

            SearchPossible(currentPositionOnMap,chara.step);

            isMovePreparation=true;

        }else if(cursor.transform.position==this.transform.position&&isMovePreparation==true){

            if(Input.GetKeyUp(KeyCode.Space)){

                isMovePreparation=false;
                tilemap.ClearAllTiles();
                movePossibleList.Clear();

            }

        }

    }

    void SearchPossible(Vector3Int pos, int remainAmount){

        if(remainAmount == 0) return;

        var CB=goundmap.cellBounds;
        if(0<=pos.x&&pos.x<CB.max.x&&0<=pos.y&&pos.y<CB.max.y){

            tilemap.SetTile(pos, possibleTile);

            Vector2 intrusivePosition=new Vector2(pos.x,pos.y);
            movePossibleList.Add(intrusivePosition);

            remainAmount--; // 移動力を下げる

            // 再帰的に4方向を確認
            SearchPossible(pos + Vector3Int.up, remainAmount);
            SearchPossible(pos + Vector3Int.right, remainAmount);
            SearchPossible(pos + Vector3Int.down, remainAmount);
            SearchPossible(pos + Vector3Int.left, remainAmount);

        }else{

            return;

        }

    }

    void Move(){

        Vector2 currentCursorPosition=new Vector2(cursor.transform.position.x-0.5f,cursor.transform.position.y-0.5f);
        bool isMovePossible=movePossibleList.Contains(currentCursorPosition);
        bool isMoveImpossible=TacticsManager.impenetrable.Contains(new Vector2(cursor.transform.position.x,cursor.transform.position.y));
        if(isMovePossible==true&&isMovePreparation==true&&isMoveImpossible==false){

            TacticsManager.impenetrable.Remove(new Vector2(this.transform.position.x,this.transform.position.y));
            transform.position=new Vector2(currentCursorPosition.x+0.5f,currentCursorPosition.y+0.5f);
            TacticsManager.impenetrable.Add(new Vector2(this.transform.position.x,this.transform.position.y));
            isMovePreparation=false;
            tilemap.ClearAllTiles();

            movePossibleList.Clear();

        }

    }

}