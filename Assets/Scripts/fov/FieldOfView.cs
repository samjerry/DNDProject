using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float _viewRadius;
    [Range(0,360)]
    public float _viewAngle;

    public LayerMask targetMask;
    public LayerMask[] obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float meshResolution;

    public MeshFilter viewMeshFilter;
    public MeshRenderer viewMeshRenderer;

    private Mesh _viewMesh;
    private Material _viewMaterial;
    [SerializeField] private Color _color;

    private void Start() 
    {
        _viewMesh = new Mesh();
        _viewMesh.name = "View Mesh";
        Vector3[] vertices = _viewMesh.vertices;
        Color[] _colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            _colors[i] = Color.black;

        _viewMesh.colors = _colors;
        viewMeshFilter.mesh = _viewMesh;

        _viewMaterial = new Material(Shader.Find("Specular"));
        _viewMaterial.color = _color;

        viewMeshRenderer.material = _viewMaterial;

        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true) 
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    private void Update() 
    {
        DrawFieldOfView();
    }

    void FindVisibleTargets() 
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) 
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2) 
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                for (int j = 0; j < obstacleMask.Length; j++) 
                {
                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask[j])) {
                        visibleTargets.Add(target);
                    }
                }
            }
        }
    }

    void DrawFieldOfView() 
    {
        int stepCount = Mathf.RoundToInt(_viewAngle * meshResolution);
        float stepAngleSize = _viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();

        for (int i = 0; i < stepCount; i++) 
        {
            float angle = transform.eulerAngles.y - _viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++) 
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2) 
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        _viewMesh.Clear();
        _viewMesh.vertices = vertices;
        _viewMesh.triangles = triangles;
        _viewMesh.RecalculateNormals();
    }

    ViewCastInfo ViewCast(float globalAngle) 
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        for (int i = 0; i < obstacleMask.Length; i++) 
        {
            if (Physics.Raycast(transform.position, dir, out hit, _viewRadius, obstacleMask[i])) 
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
                break;
            }
        }

        return new ViewCastInfo(false, transform.position + dir * _viewRadius, _viewRadius, globalAngle);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) 
    {
        if (!angleIsGlobal) 
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfo 
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle) 
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
