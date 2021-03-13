
using UnityEngine;

namespace Gbamis
{
    public class SFX_Ability : MonoBehaviour
    {
        public AudioSource footstepSFX;

        public void playFootSteep(){
            footstepSFX.Play();
        }
    }
}
