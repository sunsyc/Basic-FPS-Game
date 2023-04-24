using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    // one shoot will result in 1 damage
    public int health = 3;
    public Vector3 RespawnPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
            Debug.Log("HIIIIIIIIIIIIIT!");
        {
            health--;
            if (health <= 0)
            {
                health = 3;
                Respawn();
                //Destroy(gameObject);
            }
        }
    }
    public void Respawn()
    {
        transform.position = RespawnPosition;
    }


}
