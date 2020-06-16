using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    [SerializeField]
    private GameObject _target;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) 
        {
            Spawn(_target, MouseToWorldPosition());
        }    
    }

    private void Spawn(GameObject _objectToSpawn, Vector3 _spawnPos)
	{
        if (_objectToSpawn != null && _spawnPos != null)
        {
            Instantiate(_objectToSpawn, _spawnPos, Quaternion.identity);
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
                Debug.Log("Spawn object");
            } 
            
            else 
            {
                Debug.Log("Spawneable area not found");
            }
        }

        return _hit.point;
    }
}
