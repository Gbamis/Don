using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    [System.Serializable]
    public class Sight
    {
        public GameObject originParent;
        public RaycastHit hit;
        public Ray ray;

    }


    public class EnemySight_Ability : MonoBehaviour
    {
        public GameObject rayOrigin;
        public EnemyData_SO enemyData_SO;

        [Range(45, 180)] public float TAngle;
        [Range(3, 8)] public int RayCount;
        public float RayLength;
        private float leftAngle, midAngle;

        public List<Sight> sights;
        public List<bool> bools = new List<bool>();

        void Awake()
        {
            CreateSights();
            InitSights();
            
        }
        void CreateSights()
        {
            for (int i = 0; i < RayCount; i++)
            {
                Sight m_sights = new Sight();

                GameObject clone = Instantiate(rayOrigin);
                clone.transform.position = rayOrigin.transform.position;
                clone.transform.SetParent(transform);

                RaycastHit hit = new RaycastHit();

                m_sights.originParent = clone;
                m_sights.hit = new RaycastHit();

                sights.Add(m_sights);
                bools.Add(false);

            }
        }
      

        void InitSights()
        {
            midAngle = TAngle / RayCount;
            leftAngle = 0 - midAngle;

            foreach (Sight s in sights)
            {
                s.originParent.transform.rotation = Quaternion.Euler(0, leftAngle, 0);
                leftAngle = leftAngle + midAngle;
            }
        }
        void CastSights()
        {
            for (int i = 0; i < sights.Count; i++)
            {
                Vector3 origin = sights[i].originParent.transform.position;
                Vector3 dir = sights[i].originParent.transform.forward * RayLength;

                sights[i].ray.origin = sights[i].originParent.transform.position;
                sights[i].ray.direction = sights[i].originParent.transform.forward * RayLength;

                
                RaycastHit hit = sights[i].hit;

                if (Physics.Raycast(sights[i].ray, out hit, RayLength))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        
                        bools[i] = true;
                        enemyData_SO.playerPosition = hit.point;   
                    }
                    else
                    {
                       
                        bools[i] = false;
                    }
                    
                }
                else
                {
                    bools[i] = false;
                }
                Debug.DrawRay(origin, dir, Color.red);
            }
        }

        void SightValue(){
            
           
        }
        void Update(){
            InitSights();
            SightValue();
        }
        private void FixedUpdate()
        {
            CastSights();
        }
    }

}