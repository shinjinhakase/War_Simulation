using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TacticsManager : MonoBehaviour{
    
    const string DATA_DIR="Assets/StreamingAssets/data/";
    
    int x,y;

    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    GameObject cursor;

    List<List<string>> mapType;
    List<string> mapTypeLine;

    void Start(){

        x=0;
        y=0;
        
        MapLoad();

    }

    void Update(){

        InputCheck();

    }

    void MapLoad(){

        tilemap.ClearAllTiles();

        FileStream stream=File.Open(DATA_DIR+"map1.json",FileMode.Open);
        StreamReader reader=new StreamReader(stream);
        var json=reader.ReadToEnd();
        reader.Close();
        stream.Close();
        SaveTilemapData data=JsonUtility.FromJson<SaveTilemapData>(json);

        mapType=new List<List<string>>();

        for(int a=0;a<data.mapData.Count;a++){

            mapTypeLine=new List<string>();
            string[] tmpList=data.mapData[a].Split(',');

            for(int i=0;i<tmpList.Length;i++){

                mapTypeLine.Add(tmpList[i]);
                
            }

            mapType.Add(mapTypeLine);

        }

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

    [Serializable]
    public class SaveTilemapData{

        public List<string> mapData=new List<string>();

    }

}