using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowModelButton : MonoBehaviour
{
    private Transform _objectToShow;
    private Action<Transform> _clickAction;

    public void Initialize(Transform _objectToShow, Action<Transform> _clickAction) 
    {
        this._objectToShow = _objectToShow;
        this._clickAction = _clickAction;
        GetComponentInChildren<Text>().text = _objectToShow.gameObject.name;
    }

    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(HandleButtonClick);    
    }

    private void HandleButtonClick() 
    {
        _clickAction(_objectToShow);
    }
}
