using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSaveController : MonoBehaviour{
    
    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    TileScriptableObject tileSB;

    const string SAVE_FILE="tilemap.json";
    const string DATA_DIR="Assets/StreamingAssets/data/";
    static string saveDataPath=Path.Combine(DATA_DIR+SAVE_FILE);
    
    void Start(){

        Save();

    }

    public void Save(){

        var data=new SaveTilemapData();

        tilemap.CompressBounds();
        var b=tilemap.cellBounds;

        string str="";

        for(int y=b.min.y;y<b.max.y;y++){

            for(int x=b.min.x;x<b.max.x;x++){

                if(tilemap.HasTile(new Vector3Int(x,y,0))){

                    str+=tileSB.tileDataList.Single(t=>t.tile==tilemap.GetTile(new Vector3Int(x,y,0))).head+",";

                }else{

                    str+=" ,";

                }

            }

            str=str.TrimEnd(',');
            data.mapData.Add(str);
            str="";

        }

        string json=JsonUtility.ToJson(data,true);

        if(!Directory.Exists(DATA_DIR)){

            Directory.CreateDirectory(DATA_DIR);

        }

        StreamWriter writer=new StreamWriter(saveDataPath,false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();

    }

    [Serializable]
    public class SaveTilemapData{

        public List<string> mapData=new List<string>();

    }

}