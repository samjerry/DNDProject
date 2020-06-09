using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelUI : MonoBehaviour
{
    [SerializeField]
    private ShowModelButton _buttonPrefab;

    private void Start() 
    {
        var _models = FindObjectOfType<ShowModelController>().GetModels();
        foreach (var _model in _models) 
        {
            CreateButtonForModel(_model);
        }
    }

    public void CreateButtonForModel(Transform _model) 
    {
        var button = Instantiate(_buttonPrefab);
        button.transform.SetParent(this.transform);

        var _controller = FindObjectOfType<ShowModelController>();
        button.Initialize(_model, _controller.EnableModel);
    }
}
