using System.Collections.Generic;
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

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float stamina;
    [SerializeField] private float damage;

    [Header("Magic")]
    [SerializeField] private float mana;

    [Header("Regeneration ")]
    [SerializeField] private float regenMana;
    [SerializeField] private float regenHealth;

    [Header("Max stats")]
    [SerializeField] private float maxMana;
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxStamina;





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
    public float Stamina
    {
        get { return stamina; }
    }
    public float Damage
    {
        get { return damage; }
    }
    public float Mana
    {
        get { return mana; }
    }

    public float RegenMana
    {
        get { return regenMana; }
    }
    public float RegenHealth
    {
        get { return regenHealth; }
    }

    public float MaxMana
    {
        get { return maxMana; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public float MaxStamina
    {
        get { return maxStamina; }
    }



    #endregion
}