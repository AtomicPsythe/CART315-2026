using UnityEngine;

public class Battery : MonoBehaviour
{
    // how much a single battery recharges
    [SerializeField] private float _rechargeAmount = 40f;
    //[SerializeField] private float _rotateSpeed = 50f;

    private void Update()
    {
        //transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
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
