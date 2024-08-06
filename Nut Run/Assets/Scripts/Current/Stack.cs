using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Current
{
    public class Stack : MonoBehaviour
    {

        private LinkedList<Nut> _collectedNuts;

        private void Start()
        {
            _collectedNuts = new LinkedList<Nut>();
        }

        private void Update()
        {
            
            for (var i = 1; i < _collectedNuts.Count; i++)
            {

                _collectedNuts.ElementAt(i).transform.DOMoveX(_collectedNuts.ElementAt(i - 1).transform.position.x,0.1f);

            }
        }

        private void OnCollisionEnter(Collision other)
        {

            GameObject g = other.gameObject;
            
            if (!g.CompareTag("Nut") || g.GetComponent<Nut>().isCollected) return;
            
            Nut nut = g.GetComponent<Nut>();
            
            g.transform.parent = transform;
            g.transform.localPosition = (_collectedNuts.Count == 0) ? Vector3.zero : _collectedNuts.Last.Value.transform.localPosition + new Vector3(0,0,(_collectedNuts.Last.Value.GetBoxColliderSizeZ() + nut.GetBoxColliderSizeZ()) / 2);
            
            _collectedNuts.AddLast(nut);
            nut.isCollected = true;
            
        }
    }
    
    
    
    
}