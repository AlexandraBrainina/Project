using UnityEngine;

namespace Powerups
{
    public class Powerup : MonoBehaviour
    {
        public PowerupEffect powerupEffect;

        private void OnTriggerEnter(Collider collision)
        {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
            //playSoundEffect
            //
        }
    }
}