using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarRoom : MonoBehaviour
{
    public GameObject _fogOfWarPlane;
    public Transform _player;
    public LayerMask _floorLayer;

    public float _radius = 5f;
    private float _radiusSqr { get { return _radius * _radius; } }

    private Mesh _mesh;
    private Vector3[] _vertices;

    private FogOfWarController _fowc;

    private Color _hidden;
    private Color _visited;
    private Color _revealed;
    private Color[] _colors;

    void Start()
    {
        _fowc = GetComponent<FogOfWarController>();
        SetColors();
        Initialize();
    }

    void Update()
    {
        Ray _r = new Ray(transform.position, _player.position - transform.position);
        RaycastHit _hit;
        if (Physics.Raycast(_r, out _hit, 1000, _floorLayer, QueryTriggerInteraction.Collide))
        {
            for (int i = 0; i < _vertices.Length; i++)
            {
                Vector3 _v = _fogOfWarPlane.transform.TransformPoint(_vertices[i]);
                float _dist = Vector3.SqrMagnitude(_v - _hit.point);
                if (_dist < _radiusSqr)
                {
                    float _alpha = Mathf.Min(_colors[i].a, _dist / _radiusSqr);
                    _colors[i].a = _alpha;
                }
                if (_dist > _radiusSqr)
                {
                    if (_colors[i].a < 1)
                    {
                        _colors[i].a = 0.7f;
                    }
                }
            }
            UpdateColor();
        }
    }

    void SetColors()
    {
        _hidden = _fowc._hiddenColor;
        _visited = _fowc._visitedColor;
        _revealed = _fowc._revealedColor;
    }

    void Initialize()
    {
        _mesh = _fogOfWarPlane.GetComponent<MeshFilter>().mesh;
        _vertices = _mesh.vertices;
        _colors = new Color[_vertices.Length];
        for (int i = 0; i < _colors.Length; i++)
        {
            _colors[i] = Color.black;
        }
        UpdateColor();
    }

    void UpdateColor()
    {
        _mesh.colors = _colors;
    }
}