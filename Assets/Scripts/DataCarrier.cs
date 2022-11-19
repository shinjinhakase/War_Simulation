using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataCarrier : MonoBehaviour{
    
    
    public static Character charaL,charaR;
    
    /*
    public GameObject cursor;
    
    void Start(){

        DontDestroyOnLoad(this.gameObject);

    }
    
    public void DataCarry(){

        GameObject[] unit=GameObject.FindGameObjectsWithTag("Unit");
        for(int i=0;i<unit.Length;i++){

            if(unit[i].transform.position==cursor.transform.position){

                charaL=unit[i].GetComponent<Unit>().chara;

            }

            if(unit[i].transform.position==Command.attackContender[TacticsManager.decideNumber].transform.position){

                charaR=unit[i].GetComponent<Unit>().chara;

            }

        }

        SceneManager.LoadScene("Battle");
        
    }
    */

}