using UnityEngine;

namespace Gbamis
{
    public class CameraSwitch_Ability : MonoBehaviour
    {
        public GameObject idleCam,viewCam;

        void Start(){
            viewCam.SetActive(false);
        }
        void Update(){
            if(Input.GetKey(KeyCode.Space)){
                viewCam.SetActive(true);
            }
            else{
                viewCam.SetActive(false);
            }
        }
    }
}
