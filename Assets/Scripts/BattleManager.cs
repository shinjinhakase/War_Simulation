using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour{
    
    public Character charaL,charaR;

    public GameObject charaLDraw,charaRDraw;
    public Text charaLName,charaRName;
    public Text charaLATK,charaRATK;

    void Start(){

        Draw();

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

    void Draw(){

        DrawSprite(charaL,charaLDraw);
        DrawSprite(charaR,charaRDraw);

        charaLName.text=charaL.codename;
        charaRName.text=charaR.codename;
        
        charaLATK.text="攻撃力:"+charaL.ATK.ToString();
        charaRATK.text="攻撃力:"+charaR.ATK.ToString();

    }

    void DrawSprite(Character scriptableObject,GameObject charaDraw){

        SpriteRenderer spriteRenderer=charaDraw.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=scriptableObject.sprite;

    }

    void Attack(Character attacker,Character defenser){

        defenser.HP-=attacker.ATK;

    }

}