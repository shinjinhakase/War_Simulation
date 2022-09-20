using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour{

    /*
    private enum Status{
    }
    */


    [SerializeField]
    Character chara;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject cursor;

    [SerializeField]
    Grid grid;

    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    TileBase possibleTile;
    
    void Start(){

        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=chara.sprite;

        
    }

    void Update(){

        if(cursor.transform.position==this.transform.position){

            if(Input.GetKeyUp(KeyCode.Space)){

                //今いる場所をTilemap上の座標に変換する
                int currentPositionOnMap_X=(int)(this.transform.position.x-0.5f);
                int currentPositionOnMap_Y=(int)(this.transform.position.y-0.5f);

                Vector3 currentPositionOnMap_vector3=new Vector3(currentPositionOnMap_X,currentPositionOnMap_Y,0);

                Vector3Int currentPositionOnMap=grid.WorldToCell(currentPositionOnMap_vector3);

                SearchPossible(currentPositionOnMap,chara.step);

            }
        }
        
    }

    void SearchPossible(Vector3Int pos, int remainAmount){

        if(remainAmount == 0) return;
        tilemap.SetTile(pos, possibleTile);

        remainAmount--; // 移動力を下げる

        // 再帰的に4方向を確認
        SearchPossible(pos + Vector3Int.up, remainAmount);
        SearchPossible(pos + Vector3Int.right, remainAmount);
        SearchPossible(pos + Vector3Int.down, remainAmount);
        SearchPossible(pos + Vector3Int.left, remainAmount);

    }

}