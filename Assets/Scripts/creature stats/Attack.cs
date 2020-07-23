using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private string _attackName, _attackType;

    [SerializeField]
    private int _diceAmount, _diceType, _targetAmount, _attackModifier, _attackReach, _damageModifier;

    public DamageTypes.DamageType damageType;


    private Text _descriptionText;

    void SetDescription()
    {
        _descriptionText.text = GetComponent<CharacterStats>().entityName + " uses " + _attackName + ". " + _attackType + " Attack: +" + _attackModifier + " to hit, reach " + _attackReach + " ft., " + _targetAmount + "target(s). Hit: " + GetRollAverage(_diceAmount, _diceType) + "(" + _diceAmount + "d" + _diceType + " + " + _damageModifier + ") " + damageType + " damage.";
    }

    int GetRollAverage(int amount, int dice)
    {
        return Mathf.RoundToInt(amount * dice / 2 + _damageModifier);
    }
}
