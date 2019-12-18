using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridMaster
{
    public class NodeReferences : MonoBehaviour
    {
        public MeshRenderer tileRender;
        public Material[] tileMaterials;

        public void ChangeTileMaterial(int index)
        {
            tileRender.material = tileMaterials[index];
        }
    }
}