using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    [SerializeField]
    private GameObject _target;

    private Vector3 _nullSpawn = new Vector3(-1000, 
                                             -1000, 
                                             -1000);
    [SerializeField]
    private float _radius;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (MouseToWorldPosition() != null) {
                Spawn(_target, MouseToWorldPosition());
            }
        }    
    }

    private void Spawn(GameObject _objectToSpawn, Vector3 _spawnPos)
	{
        if (!SpawnObstructed(_spawnPos)) 
        {
            if (_objectToSpawn != null && _spawnPos != null) 
            {
                Instantiate(_objectToSpawn, _spawnPos, Quaternion.identity);
            }
        }
	}

    private Vector3 MouseToWorldPosition() 
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity)) 
        {
            GameObject _objectHit = _hit.collider.gameObject;
            if (_objectHit.tag == "Ground") 
            {
                return _hit.point;
            } 
        }
        return _nullSpawn;
    }

    private bool SpawnObstructed(Vector3 _center) 
    {
        bool _obstructed;

        Collider[] _hitColliders = Physics.OverlapSphere(_center, _radius);
        foreach (Collider _col in _hitColliders) 
        {
            if (_col.gameObject.tag == "Creature" || _col.gameObject.tag == "Wall") 
            {
                _obstructed = true;
                return _obstructed;
            }
        }
        return _obstructed = false;
    }
}
