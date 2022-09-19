using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject{

    [SerializeField]
    public string codename;
    public Sprite sprite;
    public int HP;
    public int maxHP;
    public int ATK;


}