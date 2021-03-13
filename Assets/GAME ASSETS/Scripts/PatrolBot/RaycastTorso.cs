using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class RaycastTorso : MonoBehaviour
    {
        RaycastHit hit;
        public float rayLength;
        public float strideLength, strideHeight, speed;
        public Transform placerRef;
        float lerp;
        Vector3 newPos;
        // Update is called once per frame
        void Update()
        {
            Ray();
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 0.06f);
        }
        void Ray()
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward * rayLength;


            if (Physics.Raycast(origin, direction, out hit, rayLength))
            {
                float dis = Vector3.Distance(placerRef.position, hit.point);
                
                if (dis > strideLength)
                {
                    
                    lerp += Time.deltaTime * speed;
                    Debug.Log(lerp.ToString());
                    
                    Vector3 oldPos = placerRef.transform.position;
                    newPos = hit.point;

                    Vector3 movement = Vector3.Lerp(oldPos, newPos, lerp);
                    movement.y = Mathf.Sin(lerp * Mathf.PI) * strideHeight;

                    placerRef.transform.position = movement;
                    
                }
                else{
                    lerp=0;
                }
            }
            
            Debug.DrawRay(origin, direction, Color.red);
        }
    }
}
