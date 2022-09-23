using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Command : MonoBehaviour{
    
    int select=0;

    List<Vector2> attackablePosition;
    public static List<Character> attackContender;

    public GameObject cursor,command;
    public Text contenderText;
    
    void Start(){

        attackablePosition=new List<Vector2>();
        
    }

    void Update(){
        
        Vector2 currentPosition=transform.position;

        if(Input.GetKeyUp(KeyCode.UpArrow)&&select!=0){

            select--;
            currentPosition.y+=0.5f;

        }else if(Input.GetKeyUp(KeyCode.DownArrow)&&select!=1){

            select++;
            currentPosition.y-=0.5f;

        }
        
        transform.position=currentPosition;

        if(Input.GetKeyUp(KeyCode.Space)){

            switch(select){

                case 0:

                    AttackablePositionCheck();
                    attackContender=new List<Character>();
                    for(int i=0;i<TacticsManager.charaList.Count;i++){

                        if(attackablePosition.Contains(TacticsManager.charaList[i].transform.position)){

                            attackContender.Add(TacticsManager.charaList[i].GetComponent<Unit>().chara);

                    
                        }

                    }

                    ContenderTextDraw(attackContender);

                    TacticsManager.status=TacticsManager.Status.attack;

                    command.SetActive(false);


                break;

                case 1:

                    TacticsManager.status=TacticsManager.Status.view;

                    command.SetActive(false);

                break;

            }

        }

    }

    void AttackablePositionCheck(){

        attackablePosition.Clear();

        attackablePosition.Add(new Vector2(cursor.transform.position.x+1f,cursor.transform.position.y));
        attackablePosition.Add(new Vector2(cursor.transform.position.x,cursor.transform.position.y-1f));
        attackablePosition.Add(new Vector2(cursor.transform.position.x,cursor.transform.position.y+1f));
        attackablePosition.Add(new Vector2(cursor.transform.position.x-1f,cursor.transform.position.y));

    }

    void ContenderTextDraw(List<Character> contender){

        string drawText="";
        for(int i=0;i<contender.Count;i++){

            drawText+=contender[i].codename+"\n";

        }

        contenderText.text=drawText;

    }

}