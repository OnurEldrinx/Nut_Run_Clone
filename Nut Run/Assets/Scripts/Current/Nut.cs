using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Current
{
    public class Nut : MonoBehaviour
    {

        public NutType type;
        public bool isCollected;
        private float boxColliderSizeZ;
        
        private void Start()
        {
            boxColliderSizeZ = GetComponent<BoxCollider>().size.z;
        }

        public float GetBoxColliderSizeZ() { return this.boxColliderSizeZ; }
        
    }
}

