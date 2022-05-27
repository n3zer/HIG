using UnityEngine;


[CreateAssetMenu(fileName = "New HeroData", menuName = "Hero Data", order = 51)]
public class HeroData : ScriptableObject
{
    //Menu
    [SerializeField] private string nameCharepter;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private RuntimeAnimatorController animator;

    // Stats
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float mana;

    #region get data
    public string Name
    {
        get { return nameCharepter; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public float Health
    {
        get { return health; }
    }
    public float Armor
    {
        get { return armor; }
    }
    public float Speed
    {
        get{ return speed; }
    }
    public float RunSpeed
    {
        get { return runSpeed; }
    }
    public float Damage
    {
        get { return damage; }
    }
    public float Mana
    {
        get { return mana; }
    }


    #endregion
}