using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gbamis
{
    public class Inventory_Ability : Player
    {
        //public InventoryEvent_SO inventoryEvent_SO;

        public Material playerMaterial;
        private Transform mouseClicked;
        private RaycastHit hit;

        public GameObject countDownHUD;
        public Image countDownProgress;
        public PlayerData_SO playerData;

        public float spawnHieght;
        private float timmer = 2;
        Collider[] colliders;

        void Start()
        {
            InventoryEvent_SO.OnInvisibilityInUse += PlayerInvisible;
            InventoryEvent_SO.OnInvisibilityDisabled += PlayerVisible;

            InventoryEvent_SO.OnConsumableInUse += Throw;

            countDownHUD.SetActive(false);
            colliders = GetComponents<Collider>();
        }

        void PlayerInvisible()
        {
            foreach(Collider c in colliders){
                c.enabled = false;
            }
            //controller.enabled = false;
            playerMaterial.SetFloat("Transparency_Strength", 0);
        }
        void PlayerVisible()
        {
            StartCoroutine(Disable());
        }
        IEnumerator Disable()
        {
            yield return new WaitForSeconds(7);
            foreach(Collider c in colliders){
                c.enabled = true;
            }
            playerMaterial.SetFloat("Transparency_Strength", 1);

            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }


        void Throw(Consumable_SO con_type)
        {
            //COIN,HEALTH, GRENADE,AXE,INVISIBILITY,SHIELD,POISION_DUST,TAP_AND_FOLLOW_CHARM
            isThrowing = true;
            con_type.consumableLevel -= 0.5f;
        }
        void Update()
        {
            if (countDownHUD.activeSelf == true)
            {
                countHudLookAtCamera();
            }
            if (isThrowing == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        playerData.tapLocation = hit.point;
                        if (InventoryEvent_SO.mouseIsOverUIElement == false)
                        {
                            mouseClicked = hit.transform;
                            transform.LookAt(hit.point);
                            agent.transform.LookAt(hit.point);

                            animator.SetTrigger("throw");
                            StartCoroutine(reset());
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            countDownHUD.SetActive(true);
                            dropPoision();
                        }

                    }
                }
                StartCoroutine(DisableThrow());
            }
        }
        IEnumerator reset()
        {
            yield return new WaitForEndOfFrame();
            animator.ResetTrigger("throw");
        }
        IEnumerator DisableThrow()
        {
            yield return new WaitForSeconds(3);
            isThrowing = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        public void disable()
        {
            isThrowing = false;
        }

        void countHudLookAtCamera()
        {
            countDownHUD.transform.LookAt(Camera.main.transform);
            if (timmer < 0.1f)
            {
                countDownHUD.SetActive(false);
                timmer = 2;
                

            }
            timmer -= Time.deltaTime;

            countDownProgress.fillAmount = timmer / 2;
        }
        void dropPoision()
        {
            GameObject clone = InventoryPool.Instance.RequestPoisionFromPool();
            if (clone != null)
            {
                Vector3 intPoint = playerData.tapLocation;
                intPoint.y += spawnHieght;
                clone.transform.position = intPoint;
                clone.SetActive(true);

            }
        }
    }

}