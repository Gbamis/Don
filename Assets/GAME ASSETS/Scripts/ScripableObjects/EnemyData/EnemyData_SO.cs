using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    [CreateAssetMenu(fileName="EnemyData", menuName="Scriptable Objects/Enemy")]
    public class EnemyData_SO : ScriptableObject
    {
        public float healthLevel;
        public float chaseSpeed,patrolSpeed,sightAngle,sensingRange;

        public bool playerInSight;
        public Vector3 playerPosition;
    }
}
