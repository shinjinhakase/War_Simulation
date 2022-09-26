using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impenet : MonoBehaviour{
    
    public void DetectImpenetPlace(){

        int k=0;
        for(int i=DataManager.mapType.Count-1;i>=0;i--){

            for(int j=0;j<DataManager.mapType[i].Count;j++){

                if(DataManager.mapType[i][j]!="G"){

                    float impX=0.5f+j;
                    float impY=0.5f+k;
                    Vector2 impenetrableVector=new Vector2(impX,impY); 
                    DataManager.impenetPlace.Add(impenetrableVector);

                }
                
            }

            k++;

        }

    }

}