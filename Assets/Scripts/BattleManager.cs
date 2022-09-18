using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour{
    
    public Character charaL,charaR;

    void Start(){


        Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
        Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

        Attack(charaL,charaR);

        if(charaR.HP<=0){

            charaR.HP=0;
            Debug.Log(charaL.codename+"の勝利");

            Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
            Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

        }else{

            Attack(charaR,charaL);

            if(charaL.HP<=0){

                charaL.HP=0;
                Debug.Log(charaR.codename+"の勝利");
            
            }

            Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
            Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

        }
        
    }

    void Update(){
    }

    void Attack(Character attacker,Character defenser){

        defenser.HP-=attacker.ATK;

    }

}