using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    private GameObject _parent;
    private GameObject _canvas;
    private Image _hpBar;

    private int _maxHP;
    private int _currentHP;


    private void Start() 
    {
        _parent = transform.root.gameObject;
        _canvas = transform.Find("Canvas").gameObject;
        _hpBar = _canvas.transform.Find("HealthBar").gameObject.GetComponent<Image>();

        _maxHP = GetComponent<CharacterStats>().hitPoints;
        _currentHP = _maxHP;

        _hpBar.fillAmount = _currentHP / _maxHP;
    }

    public void SetHealthUI(GameObject _target, int _amount)
    {
        _currentHP = _amount;

        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}
