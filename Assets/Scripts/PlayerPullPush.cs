using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPullPush : MonoBehaviour
{


    public float pushPower = 0.2F;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Hit");
        Rigidbody body = hit.collider.attachedRigidbody;

        // The function should do nothing if the box / collision has any of these properties.
        if (body == null || body.isKinematic || hit.moveDirection.z < -0.3f || hit.transform.name != "Box")
            return;

        Debug.Log("Player has hit box.");

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
