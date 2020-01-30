using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinimapCameraMovement : MonoBehaviour
{
    private Vector3 _camPos;

    private float _camSpeed;

    private GameObject _player;

    [SerializeField] private UnityEvent OnPlayerMove;

    // Start is called before the first frame update
    void Start()
    {
        _camPos = transform.position;
    }

    private void MoveCamera()
    {
        Vector3 _newCamPos = new Vector3(_player.transform.position.x, 20, _player.transform.position.x);

        _camPos = Mathf.Lerp(_camPos, _newCamPos, _camSpeed);
    }
}
