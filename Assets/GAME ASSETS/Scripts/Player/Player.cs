using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Gbamis
{
    public class Player : MonoBehaviour
    {
        protected  Animator animator;
        protected CharacterController controller;
        protected NavMeshAgent agent;

        public static bool isThrowing;   
        public PlayerData_SO playerData_SO;  

         void Awake(){
             animator = GetComponent<Animator>();
             controller = GetComponent<CharacterController>();
             agent = GetComponent<NavMeshAgent>();

             
         }
         void Start(){
             EventData_SO.HealthChanged(playerData_SO.player_health);
         }
    }
}
