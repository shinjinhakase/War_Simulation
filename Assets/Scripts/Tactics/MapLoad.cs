using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MapLoad : MonoBehaviour{

    const string DATA_DIR="Assets/StreamingAssets/data/";
    public string MAP_NAME="map1.json";
    
    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    TileScriptableObject tileSB;
    
    List<string> mapTypeLine;

    [SerializeField]
    private UnityEvent launchImpenet=new UnityEvent();
    
    void Start(){

        Load();
        launchImpenet.Invoke();

    }

    void Load(){

        tilemap.ClearAllTiles();

        FileStream stream=File.Open(DATA_DIR+MAP_NAME,FileMode.Open);
        StreamReader reader=new StreamReader(stream);
        var json=reader.ReadToEnd();
        reader.Close();
        stream.Close();
        SaveTilemapData data=JsonUtility.FromJson<SaveTilemapData>(json);

        GetMapType(data);

    }

    void GetMapType(SaveTilemapData data){

        for(int a=0;a<data.mapData.Count;a++){

            mapTypeLine=new List<string>();
            string[] tmpList=data.mapData[a].Split(',');

            for(int i=0;i<tmpList.Length;i++){

                mapTypeLine.Add(tmpList[i]);

                if(tmpList[i]==" ") continue;
                tilemap.SetTile(new Vector3Int(i,a,0),tileSB.tileDataList.Single(t=>t.head==tmpList[i]).tile);
                
            }

            DataManager.mapType.Add(mapTypeLine);

        }

    }

    [Serializable]
    public class SaveTilemapData{

        public List<string> mapData=new List<string>();

    }

}