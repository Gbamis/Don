using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis{
    public class SFX_Manager : MonoBehaviour
    {
        public AudioSource gameTheme,alarmFX;

        private static SFX_Manager m_instance;
        public static SFX_Manager Instance{get{return m_instance;}}

        private void Awake(){
            m_instance = this;
            gameTheme.Play();

            EventData_SO.OnPlayerSighted +=PlayAlarm;
        }

        private void PlayAlarm(){
            alarmFX.Play();
        }
    }
}   
