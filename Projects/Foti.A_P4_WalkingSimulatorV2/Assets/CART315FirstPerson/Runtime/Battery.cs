using UnityEngine;

namespace Cart315.FirstPerson
{
        public class Battery : MonoBehaviour
    {
        // how much a single battery recharges
        [SerializeField] private float _rechargeAmount = 40f;

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
                Destroy(gameObject);
            }
        }
    }
}