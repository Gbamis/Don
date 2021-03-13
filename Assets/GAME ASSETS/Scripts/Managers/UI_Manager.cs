using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gbamis
{
    public class UI_Manager : MonoBehaviour
    {
        public Image playerHealthUI;

        void Start(){
            EventData_SO.OnHealthChanched +=UpdatePlayerHealthUI;
        }

        void UpdatePlayerHealthUI(float value){
            float va = value/100;
            playerHealthUI.fillAmount = va;
        }
        
    }
}
