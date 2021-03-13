using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gbamis
{

    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
    public class PlayerData_SO : ScriptableObject
    {
        public EventData_SO eventData_SO;

        [Header("PLAYER DATA")]
        [HideInInspector]
        public Vector3 butterfly_current_position;
        public bool butterfly_is_free;
        [HideInInspector]
        public Vector3 player_current_position;
        [HideInInspector]
        public Vector3 tapLocation;

        
        [Range(0,100)]
        public float player_health;
        public float player_coin_count;


    }

}