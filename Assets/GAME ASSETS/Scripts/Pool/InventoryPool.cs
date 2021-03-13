using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class InventoryPool : MonoBehaviour
    {
        private static InventoryPool m_instance;
        public static InventoryPool Instance{get {return m_instance;}}

        public Transform poisionParentTransfrom;
        Queue<GameObject> poisionPool = new Queue<GameObject>();

        void Awake(){
            m_instance = this;
            InitPoisionPool();
        }


        void InitPoisionPool(){
            //int childNum = poisionParentTransfrom.childCount;

            foreach(Transform t in poisionParentTransfrom){
                GameObject g = t.gameObject;
                poisionPool.Enqueue(g);
                g.SetActive(false);
            }
        }
        public GameObject RequestPoisionFromPool(){
            if(poisionPool.Count==0)
                return null;

            GameObject posion = poisionPool.Dequeue();
            return posion;   
        }
        public void ReturnPoisionToPool(GameObject po){
            poisionPool.Enqueue(po);
            po.SetActive(false);
        }
    }
}
