using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject{

    [SerializeField]
    public Sprite sprite;
    public string codename;
    public string team;
    public int HP;
    public int maxHP;
    public int ATK;
    public int step;

    public void DeepCopy(Character chara){

        this.sprite=chara.sprite;
        this.codename=chara.codename;
        this.team=chara.team;
        this.HP=chara.HP;
        this.maxHP=chara.maxHP;
        this.ATK=chara.ATK;
        this.step=chara.step;

    }

}