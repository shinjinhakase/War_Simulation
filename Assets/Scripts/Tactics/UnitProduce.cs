using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProduce : MonoBehaviour{
    
    const string DATA_DIR="Assets/StreamingAssets/data/";
    public string MAP_NAME="unit1.json";

    [SerializeField]
    CharacterList book;

    public GameObject unitOnMap;
    
    public void Produce(){

        FileStream stream=File.Open(DATA_DIR+MAP_NAME,FileMode.Open);
        StreamReader reader=new StreamReader(stream);
        var json=reader.ReadToEnd();
        reader.Close();
        stream.Close();
        MapLoad.SaveTilemapData data=JsonUtility.FromJson<MapLoad.SaveTilemapData>(json);

        GetUnitType(data);

    }

    void GetUnitType(MapLoad.SaveTilemapData data){

        int k=0;
        
        for(int line=data.mapData.Count-1;line>=0;line--){

            string[] tmpList=data.mapData[line].Split(',');
            Debug.Log(string.Join(",",data.mapData[line]));
            for(int column=0;column<tmpList.Length;column++){

                Debug.Log("k:"+k+" column:"+column+data.mapData[line][column]);
                UnitInstantiate(tmpList[column].ToString(),k,column);

            }
            
            k++;

        }

    }

    void UnitInstantiate(string type,int k,int column){

        GameObject unit=Instantiate(unitOnMap) as GameObject;
        unit.transform.position=new Vector2(0.5f+column,0.5f+k);
        Unit unitScript=unit.GetComponent<Unit>();
        LocalCharaData unitStatus=unitScript.chara;
             
        switch(type){

            case "Y":

                unitStatus.DeepCopy(book.characterList[0]);

            break;

            case "F":

                unitStatus.DeepCopy(book.characterList[1]);

            break;

            case "B":
            
                unitStatus.DeepCopy(book.characterList[2]);

            break;

            case "N":

                Destroy(unit);

            break;

        }

        unitScript.SetChara();

    }

}