using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class PosionObject : MonoBehaviour
    {
        public float detonationTime;
      
        void OnCollisionEnter(Collision col){
            StartCoroutine(Destroy());
        }
        IEnumerator Destroy(){
            yield return new WaitForSeconds(detonationTime);
            InventoryPool.Instance.ReturnPoisionToPool(this.gameObject);
        } 
    }
}
