using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelControl
{
    public class LevelInitializer : MonoBehaviour
    {
        /*
        [SerializeField] private GameObject _gridBasePrefab;

        [SerializeField] private int _unitCount = 1;
        [SerializeField] GameObject _unitPrefabs;

        private WaitForEndOfFrame _waitEF;

        private GridStats _gridStats;

        [System.Serializable]
        public class GridStats
        {
            public int maxX = 10;
            public int maxY = 3;
            public int maxZ = 10;

            public float offsetX = 1;
            public float offsetY = 1;
            public float offsetZ = 1;
        }

        private void Start()
        {
            _waitEF = new WaitForEndOfFrame();

            StartCoroutine("InitLevel");
        }

        IEnumerator InitLevel()
        {
            yield return StartCoroutine(CreateGrid());

            yield return StartCoroutine(CreateUnits());

            yield return StartCoroutine(EnablePlayerInteraction());
        }

        IEnumerator CreateGrid()
        {
            GameObject go = Instantiate(_gridBasePrefab, Vector3.zero, Quaternion.identity) as GameObject;

            go.GetComponent<GridMaster.GridBase>().InitGrid(_gridStats);

            yield return _waitEF;
        }

        IEnumerator CreateUnits()
        {
            for (int i = 0; i < _unitCount; i++)
            {
                Instantiate(_unitPrefabs, Vector3.zero, Quaternion.identity);
            }

            yield return _waitEF;
        }

        IEnumerator EnablePlayerInteraction()
        {
            GetComponent<Ping.PlayerInteractions>().enabled = true;

            yield return _waitEF;
        }
        */
    }
}
