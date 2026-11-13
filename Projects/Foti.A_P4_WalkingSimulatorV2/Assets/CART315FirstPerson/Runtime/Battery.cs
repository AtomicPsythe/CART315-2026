using UnityEngine;

namespace Cart315.FirstPerson
{
        public class Battery : MonoBehaviour
    {
        // how much a single battery recharges
        [SerializeField] private float _rechargeAmount = 40f;

        // battery audio on interaction
        [SerializeField] private AudioClip _pickupSound;
        [SerializeField] private float _pickupVolume = 0.6f;

        private void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            // checks if the player is touching the battery to interact with it
            FlashlightController flashlight = other.GetComponentInParent<FlashlightController>();
            if (flashlight != null)
            {
                flashlight.AddBattery(_rechargeAmount);

                if (_pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(_pickupSound, transform.position, _pickupVolume);
                }

                Destroy(gameObject);
            }
        }
    }
}