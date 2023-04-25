using UnityEngine;

// Author: Yinchu
public class SpeedPickup : MonoBehaviour
{
    public float speedBoost = 1.5f; // Set the value for how much speed the player gains upon pickup

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMotor>().IncreaseSpeed(speedBoost);
            Destroy(gameObject);
        }
    }

}
