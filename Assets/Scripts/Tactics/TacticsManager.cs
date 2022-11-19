using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class TacticsManager : MonoBehaviour{

    public static int decideNumber;

    [SerializeField]
    GameObject command,decideMarker;

    public static List<Vector2> charaPosition=new List<Vector2>();

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

        status=Status.view;

        command.SetActive(false);

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

}