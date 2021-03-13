using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class LightFlies : MonoBehaviour
    {
        public GameObject followTarget;
        public PlayerData_SO playerData_SO;
        public float followDistance,damping;
        private float stoppingDistance;      
        private  Vector3 lookDir;
        public Animator anim;
        public Vector3 offsets = new Vector3(0,0,0);

        void Start(){
            if(playerData_SO.butterfly_is_free==true){
                transform.position = playerData_SO.butterfly_current_position;
            }
        }
        void Update()
        {
            playerData_SO.butterfly_current_position = transform.position;
            //stoppingDistance = y+0.5f;
            stoppingDistance = offsets.y + 0.5f;
            
            if (playerData_SO.butterfly_is_free==true)
            {
                FollowPlayer();
            }
        }
        void FollowPlayer()
        {
            if (followTarget != null)
            {
                float dis = Vector3.Distance(transform.position, followTarget.transform.position);           
                if (dis > followDistance && dis > stoppingDistance)
                {
                    Vector3 temp = followTarget.transform.position;
                    //lookDir = temp + new Vector3(x,y,z);
                    lookDir = temp + offsets;

                    transform.LookAt(lookDir);
                    Vector3 move = Vector3.forward * Time.deltaTime * damping;
                    transform.Translate(move);
                    anim.SetBool("fly",true);
                }
            }
            
        }
    }
}
