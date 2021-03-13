
using UnityEngine;

namespace Gbamis
{
    [CreateAssetMenu(fileName="EventData", menuName="Scriptable Objects/EventData")]
    public class EventData_SO : ScriptableObject
    {
        //////////////////////////////////
        ////////Event Data////////////////

        public delegate void Health(float value);
        public static event Health OnHealthChanched;
        
        public static void HealthChanged(float healthValue){
            OnHealthChanched(healthValue);
        }

    }

}