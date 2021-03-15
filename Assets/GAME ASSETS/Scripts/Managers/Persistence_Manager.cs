using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gbamis
{
    public class Persistence_Manager : MonoBehaviour
    {
        private static Persistence_Manager m_instance;
        public static Persistence_Manager Instance{
            get{return m_instance;}
        }

        private void Awake(){
            m_instance = this;
        }

        List<Object> Assests = new List<Object>();
        public void QuitGame(){

        }

    }
}

