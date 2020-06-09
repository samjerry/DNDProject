using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelUI : MonoBehaviour 
{
    [SerializeField]
    private ShowModelButton _buttonModelPrefab;

    [SerializeField]
    private GameObject _target;

    private void Start() 
    {
        var _models = _target.GetComponent<ShowModelController>().GetModels();
        foreach (var _model in _models) {
            CreateButtonForModel(_model);
        }      
    }

    public void CreateButtonForModel(Transform _model) 
    {
        var _button = Instantiate(_buttonModelPrefab);
        _button.transform.SetParent(this.transform);

        var _controller = _target.GetComponent<ShowModelController>();
        _button.Initialize(_model, _controller.EnableModel);
    }
}
