using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerGuiManager
{
    [SerializeField] private Slider _health;
    [SerializeField] private Slider _mana;
    [SerializeField] private Slider _stamina;

    public void SetMax(float health, float mana, float stamina)
    {
        _health.maxValue = health;
        _mana.maxValue = mana;
        _stamina.maxValue = stamina;
    }

    public void SetData(float health, float mana, float stamina)
    {
        _health.value = health;
        _mana.value = mana;
        _stamina.value = stamina;
    }
}
