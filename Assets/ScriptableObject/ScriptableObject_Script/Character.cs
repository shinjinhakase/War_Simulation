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

}