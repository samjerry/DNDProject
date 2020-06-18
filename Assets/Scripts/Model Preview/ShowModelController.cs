using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelController : MonoBehaviour
{
    private List<Transform> _models;

    private void Awake() 
    {
        _models = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++) 
        {
            var _model = transform.GetChild(i);
            _models.Add(_model);

            _model.gameObject.SetActive(i == 0);
        }

        var _root = transform.root;

        for (int i = 0; i < _root.childCount; i++) 
        {
            for (int j = 0; j < _root.GetChild(i).childCount; j++) 
            {
                _root.GetChild(i).GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    public void EnableModel(Transform _modelTransform) 
    {
        var _root = transform.root;

        for (int i = 0; i < _root.childCount; i++) 
        {
            for (int j = 0; j < _root.GetChild(i).childCount; j++) 
            {
                _root.GetChild(i).GetChild(j).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < transform.childCount; i++) 
        {
            var _transformToToggle = transform.GetChild(i);
            bool _shoulBeActive = _transformToToggle == _modelTransform;

            _transformToToggle.gameObject.SetActive(_shoulBeActive);
        }
    }

    public List<Transform> GetModels() 
    {
        return new List<Transform>(_models);
    }
}
