using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSelection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//If the player has left clicked
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor")) //Checks if the player clicked on a floor
                {
                    transform.position = _hit.point;
                }
            }
        }
    }
}