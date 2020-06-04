using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField]
    private Text _diceAmountText;

    private List<GameObject> _diceList;

    private GameObject _targetDice;

    private int _diceAmount = 0;

    void Start()
    {
        _diceList = new List<GameObject>();
        _diceAmountText.text = _diceAmount.ToString();
    }

    public void SetTargetDice(GameObject _dice)
    {
        _targetDice = _dice;
        Debug.Log("Target dice is: " + _targetDice.name);
    }

    public void ChangeDiceAmount(int _value)
    {
        if ((_diceAmount + _value) >= 0)
        {
            _diceAmount += _value;
            _diceAmountText.text = _diceAmount.ToString();
        }
    }

    public void AddToDiceList()
    {
        if (_targetDice != null)
        {
            for (int i = 0; i < _diceAmount; i++)
            {
                _diceList.Add(_targetDice);
                Debug.Log("Added: " + _targetDice + " to the dice spawn list");
            }
        }
       
        Debug.Log("Total dice that will be spawned: " + _diceList.Count);
    }

    public void SpawnDice()
    {
        if (_diceList.Count != 0)
        {
            foreach (GameObject _dice in _diceList)
            {
                Vector3 _randomPos = new Vector3(Random.Range(0, 3),
                                                 Random.Range(0, 3),
                                                 transform.position.y);

                Instantiate(_dice, _randomPos, Quaternion.identity);
            }
        }
    }

    public void DeleteDice()
    {
        foreach (GameObject _dice in _diceList)
        {
            Destroy(_dice);
        }

        _diceList.Clear();
    }
}
