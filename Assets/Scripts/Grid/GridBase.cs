using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridMaster
{
    public class GridBase : MonoBehaviour
    {
        public int maxX;
        public int maxY;
        public int maxZ;

        public float offsetX;
        public float offsetY;
        public float offsetZ;

        public Node[,,] grid;

        public GameObject gridFloorprefab;

        public Vector3 startNodePos;
        public Vector3 endNodePos;

        public int enabledY;
        private List<GameObject> _yCollisions = new List<GameObject>();

        public int agents;

        private LevelManager _lvlManager;

        public void InitGrid(LevelControl.LevelInitializer.GridStats gridStats)
        {
            maxX = gridStats.maxX;
            maxY = gridStats.maxY;
            maxZ = gridStats.maxZ;

            offsetX = gridStats.offsetX;
            offsetY = gridStats.offsetY;
            offsetZ = gridStats.offsetZ;

            _lvlManager = LevelManager.GetInstance();

            CreateGrid();
            CreateMouseCollision();
            CloseAllMouseCollisions();

            _yCollisions[enabledY].SetActive = true;
        }

        public bool start;
        
        private void Update()
        {
  
        }

        public void ShowPath(List<Node> path)
        {
            foreach (Node n in path)
            {
                n.worldObject.SetActive(false);
            }
        }

        public Node GetNode(int x, int y, int z)
        {

        }

        public Node NodeFromWorldPos(Vector3 worldPos)
        {
            float worldX = worldPos.x;
            float worldY = worldPos.y;
            float worldZ = worldPos.z;

            worldX /= offsetX;
            worldY /= offsetY;
            worldZ /= offsetZ;

            int x = Mathf.RoundToInt(worldX);
            int y = Mathf.RoundToInt(worldY);
            int z = Mathf.RoundToInt(worldZ);

            if (x > maxX - 1)
                x = maxX - 1;
            if (y > maxY - 1)
                y = maxY - 1;
            if (z > maxZ - 1)
                z = maxZ - 1;
            
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            if (z < 0)
                z = 0; 

            return grid[x, y, z];
        }

        void CreateGrid()
        {
            grid = new Node[maxX, maxY, maxZ];

            for (int i = 0; i < maxY; i++)
            {
                _lvlManager.lvlObjects.Add(new ObjsPerFloor());
                _lvlManager.lvlObjects[i].floorIndex = i;
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    for (int z = 0; z < maxZ; z++)
                    {
                        float posX = x * offsetX;
                        float posY = y * offsetY;
                        float posZ = z * offsetZ;
                        GameObject go = Instantiate(gridFloorprefab, new Vector3(posX, posY, posZ), Quaternion.identity) as GameObject;

                        go.transform.name = x.ToString() + " " + y.ToString() + " " + z.ToString();
                        go.transform.parent = transform;

                        Node node = new Node();
                        node.x = x;
                        node.y = y;
                        node.z = z;
                        node.worldObject = go;
                        node.nodeRef = go.GetComponentInChildren<NodeReferences>();
                        node.isWalkable = false;
                        node.nodeRef.tileRenderer.enabled = false;

                        RaycastHit[] hits = Physics.BoxCastAll(
                            new Vector3(posX, posY, posZ),
                            new Vector3(0.5f, 0.5f, 0.5f),
                            Vector3.up
                            );

                        for (int i = 0; i < hits.Length; i++)
                        {
                            if (hits[i].transform.GetComponent<LevelObject>())
                            {
                                LevelObject lvlObj = hits[i].transform.GetComponent<LevelObject>();

                                if (!_lvlManager.lvlObjects[y].objs.Contains(lvlObj.gameObject))
                                {
                                    _lvlManager.lvlObjects[y].objs.Add(lvlObj.gameObject);
                                }

                                node.nodeRef.tileRender.enabled = true;

                                if (lvlObj.objType == LevelObject.LvlObjectType.Obstacle)
                                {
                                    node.isWalkable = false;
                                    node.nodeRef.ChangeTileMaterial(1);
                                    break;
                                }

                                if (true)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}