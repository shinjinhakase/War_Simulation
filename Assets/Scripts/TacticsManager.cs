using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class TacticsManager : MonoBehaviour{
    
    const string DATA_DIR="Assets/StreamingAssets/data/";
    
    int x,y;

    public static int decideNumber;

    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    GameObject cursor,command,decideMarker;

    List<List<string>> mapType;
    List<string> mapTypeLine;

    public static List<Vector2> impenetrable=new List<Vector2>();
    public static List<Vector2> charaPosition=new List<Vector2>();

    public static List<GameObject> charaList=new List<GameObject>();

    [SerializeField]
    private UnityEvent decide = new UnityEvent();

    public enum Status{

        view,
        select,
        action,
        attack

    }

    public static Status status;

    void Start(){

        x=0;
        y=0;

        status=Status.view;

        command.SetActive(false);

        MapLoad();
        Impenet();

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

    void Impenet(){

        int k=0;
        for(int i=mapType.Count-1;i>=0;i--){

            for(int j=0;j<mapType[i].Count;j++){

                if(mapType[i][j]!="G"){

                    float impX=0.5f+j;
                    float impY=0.5f+k;
                    Vector2 impenetrableVector=new Vector2(impX,impY); 
                    impenetrable.Add(impenetrableVector);

                }
                
            }

            k++;

        }

    }

    void InputCheck(){

        if(status==Status.view||status==Status.select){

            CursorMove();

        }else if(status==Status.action){

            command.SetActive(true);

        }else if(status==Status.attack){

            AttackDecide();

        }

    }

    void CursorMove(){

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

    void AttackDecide(){

        int moveRange=Command.attackContender.Count;
        decideNumber=0;

        RectTransform decidePosition=decideMarker.GetComponent<RectTransform>();

        float lowerLimit=decidePosition.localPosition.y-moveRange*60f;
        float upperLimit=220;
        
        if(Input.GetKeyUp(KeyCode.DownArrow)&&decidePosition.localPosition.y>lowerLimit){

            decidePosition.localPosition+=new Vector3(0,-60,0);
            decideNumber++;

        }

        if(Input.GetKeyUp(KeyCode.UpArrow)&&decidePosition.localPosition.y<upperLimit){

            decidePosition.localPosition+=new Vector3(0,60,0);
            decideNumber--;

        }

        if(Input.GetKeyUp(KeyCode.Space)){

            status=Status.view;
            decide.Invoke();

        }

    }
    
    [Serializable]
    public class SaveTilemapData{

        public List<string> mapData=new List<string>();

    }

}