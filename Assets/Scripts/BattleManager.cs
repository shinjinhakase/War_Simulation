using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour{
    
    public Character charaL,charaR;

    void Start(){


        Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
        Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

        Attack(charaL,charaR);

        Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
        Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

        Attack(charaR,charaL);

        Debug.Log(charaL.codename+" "+charaL.HP+"/"+charaL.maxHP+" ATK:"+charaL.ATK);
        Debug.Log(charaR.codename+" "+charaR.HP+"/"+charaR.maxHP+" ATK:"+charaR.ATK);

    }

    void Update(){
    }

    void Attack(Character attacker,Character defenser){

        defenser.HP-=attacker.ATK;

    }

}