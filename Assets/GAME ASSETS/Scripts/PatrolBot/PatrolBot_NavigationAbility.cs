using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Gbamis
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PatrolBot_NavigationAbility : MonoBehaviour
    {
        private NavMeshAgent agent;
        private int nextInt;
        public List<Transform> wayPoints;
        Queue<Transform> innerPoints = new Queue<Transform>();
        public EnemyData_SO enemyData_SO;
        public float areaObservingTime = 0.0f;
        private float areaObserveCounter;


        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = true;
            agent.speed = enemyData_SO.patrolSpeed;
            agent.angularSpeed = 500;
        }

        void Start()
        {
            GotoNextPoint();
        }
        void Update()
        {
            if (enemyData_SO.playerInSight)
            {
                ChaseTarget();
            }
            else
            {
                Patrol();
            }


        }
        private void ChaseTarget()
        {
            agent.speed = enemyData_SO.chaseSpeed;
            agent.destination = enemyData_SO.playerPosition;

        }
        void Patrol()
        {
            agent.speed = enemyData_SO.patrolSpeed;
            if (!agent.pathPending && agent.remainingDistance < 0.2f && wayPoints.Count != 0)
            {
                areaObserveCounter += Time.deltaTime;
                if (areaObserveCounter > areaObservingTime)
                {
                    GotoNextPoint();
                }

            }
        }
        void GotoNextPoint()
        {
            if (wayPoints.Count < 2)
            {
                RefillWaypoints();
            }
            else
            {
                areaObserveCounter = 0;
                Random.InitState(System.DateTime.Now.Millisecond);

                nextInt = Random.Range(0, wayPoints.Count);

                agent.speed = enemyData_SO.patrolSpeed;
                agent.destination = wayPoints[nextInt].position;
                innerPoints.Enqueue(wayPoints[nextInt]);
                wayPoints.RemoveAt(nextInt);
            }

        }
        void RefillWaypoints()
        {
            foreach (Transform t in innerPoints)
            {

                wayPoints.Add(t);

            }
            innerPoints.Clear();
        }
    }
}
