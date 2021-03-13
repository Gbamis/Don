using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class FootIkPlacement : MonoBehaviour
    {
        public List<LEG_IK_SOLVER> leg_solvers;
        RaycastHit hit;
        public float rayLength;
        public GameObject placer;

        void Update()
        {
            //Ray();
            transform.position = placer.transform.position;
        }

        void Ray(){
            Vector3 origin = transform.position;
            Vector3 direction = Vector3.down *rayLength;

            if(Physics.Raycast(origin,direction, out hit, rayLength)){
                Debug.DrawRay(origin,direction,Color.blue);
                transform.position = hit.point;
            }
            //Debug.DrawRay(origin,direction,Color.red);
        }
        void Solve(){
            foreach (LEG_IK_SOLVER legData in leg_solvers)
            {
                ApplyFootPlacing(legData);
            }
        }
        void ApplyFootPlacing(LEG_IK_SOLVER leg)
        {
            float disVector = Vector3.Distance(leg.footIK.transform.position, leg.footPlaceHolder.position);

            if (disVector > leg.footDistance)
            {
                leg.footIK.transform.position = leg.footPlaceHolder.position;
                
            }
        }

    }


    [System.Serializable]
    public class LEG_IK_SOLVER
    {
        public Transform footPlaceHolder;
        //public Transform kneePlaceHolder;
        public GameObject footIK;
        //public GameObject kneePole;
        public float footDistance = 1;
        //public float kneeDistance = 1;
    }
}
