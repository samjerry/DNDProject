using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportFilter : MonoBehaviour
{
    private List<GameObject> _typeList;

    private GameObject _targetType;
    private Transform _viewPort;

    [SerializeField]
    private Text _previousTypeText,
                 _currentTypeText,
                 _NextTypeText;

    private int _typeIndex = 0;
    private int _maxIndex;

    private void Start() 
    {
        _typeList = new List<GameObject>();
        _viewPort = transform.GetChild(0);

        for (int i = 0; i < _viewPort.childCount; i++) 
        {
            _typeList.Add(_viewPort.GetChild(i).gameObject);
        }

        _maxIndex = _typeList.Count - 1;
        ChangeTypeText();
    }

    public void ChangeTypeIndex(int _value) 
    {
        if (_typeIndex + _value < _typeIndex && _typeIndex == 0) 
        {
            _typeIndex = _maxIndex;
        }

        else if (_typeIndex + _value > _typeIndex && _typeIndex == _maxIndex) 
        {
            _typeIndex = 0;
        } 
        
        else 
        {
            _typeIndex += _value;
        }


        Debug.Log(_typeIndex);
        ChangeTypeText();
    }

    private void ChangeTypeText() 
    {
        if (_typeIndex == 0) 
        {
            _previousTypeText.text = _typeList[_maxIndex].name;
            _currentTypeText.text = _typeList[_typeIndex].name;
            _NextTypeText.text = _typeList[_typeIndex + 1].name;
        }

        else if (_typeIndex == _maxIndex) 
        {
            _previousTypeText.text = _typeList[_typeIndex - 1].name;
            _currentTypeText.text = _typeList[_typeIndex].name;
            _NextTypeText.text = _typeList[0].name;
        } 
        
        else 
        {
            _previousTypeText.text = _typeList[_typeIndex - 1].name;
            _currentTypeText.text = _typeList[_typeIndex].name;
            _NextTypeText.text = _typeList[_typeIndex + 1].name;
        }
    }
}
