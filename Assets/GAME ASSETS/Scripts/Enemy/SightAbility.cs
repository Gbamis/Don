using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class SightAbility : MonoBehaviour
    {
        private RaycastHit hit, testHit;

        public bool fire, inRange, inSight;
        public Vector3 targetOffset = Vector3.zero;
        public EnemyData_SO enemyData_SO;

        private void Update(){
            if(enemyData_SO.playerInSight==true){
                 EventData_SO.PlayerSeen();
            }
        }
        private void FixedUpdate()
        {

            CheckSight();
            CheckOverlap();
        }

        private void CheckAngleToTarget(Transform otherTarget)
        {
            Vector3 target = otherTarget.position - transform.position;
            target = targetOffset + target;

            Vector3 self = transform.forward;

            float angle = Vector3.Angle(target, self);
            if (angle < enemyData_SO.sightAngle)
            {
                Vector3 origin = transform.position;
                Vector3 dir = target * enemyData_SO.sensingRange;

                Debug.DrawRay(origin, dir, Color.blue);

                if (Physics.Raycast(origin, dir, out testHit, enemyData_SO.sensingRange))
                {
                    if (testHit.collider.gameObject.CompareTag("Player"))
                    {
                        Vector3 lookDir = otherTarget.position + targetOffset;
                        transform.LookAt(lookDir);
                        enemyData_SO.playerInSight = true;
                        enemyData_SO.playerPosition = otherTarget.position;
                       

                    }
                    else
                    {
                        enemyData_SO.playerInSight = false;
                    }
                }
                else
                {
                    enemyData_SO.playerInSight = false;
                }
            }
            else
            {
                enemyData_SO.playerInSight = false;
            }

        }
        private void CheckOverlap()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyData_SO.sensingRange);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    inRange = true;
                    CheckAngleToTarget(c.gameObject.transform);
                    break;
                }
                else
                {
                    inRange = false;
                    enemyData_SO.playerInSight = false;
                }
            }
        }

        private void CheckSight()
        {
            Vector3 origin = transform.position;
            Vector3 dir = transform.forward * enemyData_SO.sensingRange;

            Debug.DrawRay(origin, dir, Color.red);

            if (Physics.Raycast(origin, dir, out hit, enemyData_SO.sensingRange))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    fire = true;
                }
                else
                {
                    fire = false;
                }
            }
            else
            {
                fire = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, enemyData_SO.sensingRange);
            Gizmos.color = Color.green;
        }
    }
}
