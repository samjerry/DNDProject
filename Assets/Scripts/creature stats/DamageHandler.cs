using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private CharacterUIManager _characterUI;

    private void Start()
    {
        _characterUI = GetComponent<CharacterUIManager>();

    }

    public int Damage(GameObject _target, int _amount, int _sidedDice, int _baseDamage, DamageTypes.DamageType _type)
    {
        int _damage;
        _damage = RollDamage(_amount, _sidedDice, _baseDamage);

        if (IsVulnerable(_target, _type))
        {
            _damage *= 2;
        }

        else if (IsResistant(_target, _type))
        {
            _damage /= 2;
        }

        else if (IsImmune(_target, _type))
        {
            _damage = 0;
        }

        return _damage;
    }

    private int RollDamage(int _amount, int _sidedDice, int _baseDamage)
    {
        int _damage = _amount * _sidedDice + _baseDamage;
        Debug.Log("Rolled: " + _damage + " damage");
        return _damage;
    }

    private bool IsVulnerable(GameObject _target, DamageTypes.DamageType _type)
    {
        //check the damage type of the attack
        //check through the vulnerable list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        for (int i = 0; i < _target.GetComponent<CharacterStats>().vulnerability.Length; i++)
        {
            if (_type == _target.GetComponent<CharacterStats>().vulnerability[i])
            {
                Debug.Log("is vulnerable to: " + _type + " damage");
                return true;
            }
        }

        return false;
    }

    private bool IsResistant(GameObject _target, DamageTypes.DamageType _type)
    {
        //check the damage type of the attack
        //check through the resistance list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        for (int i = 0; i < _target.GetComponent<CharacterStats>().resistance.Length; i++)
        {
            if (_type == _target.GetComponent<CharacterStats>().resistance[i])
            {
                Debug.Log("is resistant to: " + _type + " damage");
                return true;
            }
        }

        return false;
    }

    private bool IsImmune(GameObject _target, DamageTypes.DamageType _type)
    {
        //check the damage type of the attack
        //check through the immunity list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        for (int i = 0; i < _target.GetComponent<CharacterStats>().immunity.Length; i++)
        {
            if (_type == _target.GetComponent<CharacterStats>().immunity[i])
            {
                Debug.Log("is immune to: " + _type + " damage");
                return true;
            }
        }

        return false;
    }

    public void ApplyDamage(GameObject _target, int _damage)
    {
        _target.GetComponent<CharacterStats>().hitPoints -= _damage;
        _characterUI.SetHealthUI(_target, _target.GetComponent<CharacterStats>().hitPoints);
    }
}
