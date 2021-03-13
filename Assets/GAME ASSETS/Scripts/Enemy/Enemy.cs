using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyData_SO enemyData_SO;

        public virtual void Die(){}
    }
}
