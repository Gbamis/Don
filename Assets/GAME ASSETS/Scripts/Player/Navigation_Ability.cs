using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Gbamis
{
    public class Navigation_Ability : Player
    {
        NavMeshPath path;
        LineRenderer line;

        public GameObject targetSprite;
        Transform mouseClicked;
        RaycastHit hit;

        public InventoryDataStore_SO inventoryDataStore_SO;
        public PlayerData_SO playerData;


        void Start()
        {
           transform.position = playerData.player_current_position;
            //line = GetComponent<LineRenderer>();

            path = new NavMeshPath();

            /*line.startWidth = 0.07f;
            line.endWidth = 0.07f;
            line.startColor = targetSprite.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            line.endColor = targetSprite.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            */

            targetSprite.SetActive(false);
        }
        void Update()
        {
           playerData.player_current_position = transform.position;
            if (isThrowing == false)
            {
                Move();
            }
        }

        void FixedUpdate()
        {
            if (isThrowing == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        

                        if (InventoryEvent_SO.mouseIsOverUIElement == false)
                        {
                            mouseClicked = hit.transform;
                            targetSprite.SetActive(true);
                            targetSprite.transform.position = hit.point;
                            agent.destination = hit.point;
                            
                        }

                    }
                }
            }
        }

        void Move()
        {
            animator.SetFloat("move", agent.velocity.magnitude);
            if (agent.velocity.magnitude > 1)
            {
                if (controller != null || controller.enabled == false)
                {
                    controller.Move(agent.desiredVelocity * Time.deltaTime);
                }
            }
        }
        void DrawPathToTarget(RaycastHit hit)
        {

            NavMesh.CalculatePath(transform.position, hit.point, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.numCornerVertices = 90;
            line.SetPositions(path.corners);

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Consumable"))
            {
                other.gameObject.SetActive(false);
                StartCoroutine(reE(other.gameObject));

                Consumable_SO con = other.gameObject.GetComponent<ConsumableGameObject>().consumable;


                if (con.consumableType != Consumable_SO.ConsumableType.COIN)
                {

                    inventoryDataStore_SO.addConsumable(con);
                }
                ///Unit test
               playerData.player_health = playerData.player_health - 10;
                EventData_SO.HealthChanged(playerData.player_health);
            }

            if (other.CompareTag("LightFly"))
            {
                playerData.butterfly_is_free = true;
            }
        }

        IEnumerator reE(GameObject o)
        {
            int rand = Random.Range(2,10);
            yield return new WaitForSeconds(rand);
            o.SetActive(true);
        }

    }
}
