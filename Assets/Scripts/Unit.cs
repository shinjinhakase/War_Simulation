using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour{
    
    public LocalCharaData chara=new LocalCharaData();
    SpriteRenderer spriteRenderer;
    
    public GameObject cursor;
    public Grid grid;
    public Tilemap tilemap,goundmap;
    public TileBase possibleTile;

    List<Vector2> movePossibleList = new List<Vector2>();
    
    void Start(){

        //自分の存在を登録
        DataManager.impenetPlace.Add(new Vector2(this.transform.position.x,this.transform.position.y));
        TacticsManager.charaPosition.Add(new Vector2(this.transform.position.x,this.transform.position.y));
        DataManager.charaList.Add(this.gameObject);
        
    }

    void Update(){

        if(Input.GetKeyUp(KeyCode.Space)){

            if(TacticsManager.status==TacticsManager.Status.view){
                
                MovePreparation();
                
            }else if(TacticsManager.status==TacticsManager.Status.select){

                Move();

            }

        }
        
    }

    void MovePreparation(){

        if(cursor.transform.position==this.transform.position){
            
            TacticsManager.status=TacticsManager.Status.select;
            
            //今いる場所をTilemap上の座標に変換する
            Vector3Int currentPositionOnMap=grid.WorldToCell(this.transform.position);
            SearchPossible(currentPositionOnMap,chara.step);

        }

    }

    void SearchPossible(Vector3Int pos, int remainAmount){

        if(remainAmount == 0) return;

        Vector2 checkImpenetrable=new Vector2(goundmap.GetCellCenterWorld(pos).x,goundmap.GetCellCenterWorld(pos).y);
        if(checkImpenetrable!=new Vector2(cursor.transform.position.x,cursor.transform.position.y)&&DataManager.impenetPlace.Contains(checkImpenetrable)) return;

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

        if(cursor.transform.position==this.transform.position){

            TacticsManager.status=TacticsManager.Status.view;
            tilemap.ClearAllTiles();
            movePossibleList.Clear();

            return;

        }
        
        Vector2 currentCursorPosition=new Vector2(cursor.transform.position.x-0.5f,cursor.transform.position.y-0.5f);
        bool isMovePossible=movePossibleList.Contains(currentCursorPosition);
        bool isMoveImpossible=DataManager.impenetPlace.Contains(new Vector2(cursor.transform.position.x,cursor.transform.position.y));
        if(isMovePossible==true&&isMoveImpossible==false){

            DataManager.impenetPlace.Remove(new Vector2(this.transform.position.x,this.transform.position.y));
            TacticsManager.charaPosition.Remove(new Vector2(this.transform.position.x,this.transform.position.y));
            transform.position=new Vector2(currentCursorPosition.x+0.5f,currentCursorPosition.y+0.5f);
            DataManager.impenetPlace.Add(new Vector2(this.transform.position.x,this.transform.position.y));
            TacticsManager.charaPosition.Add(new Vector2(this.transform.position.x,this.transform.position.y));

            TacticsManager.status=TacticsManager.Status.action;

            tilemap.ClearAllTiles();

            movePossibleList.Clear();

        }

    }

    public void SetChara(){

        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=chara.sprite;

    }

}