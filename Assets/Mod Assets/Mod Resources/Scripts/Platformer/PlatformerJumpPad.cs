using UnityEngine;
using ntdotjsx.Mechanics;

public class ntdotjsxJumpPad : MonoBehaviour
{
    public float verticalVelocity;

    void OnTriggerEnter2D(Collider2D other)
    {
        var rb = other.attachedRigidbody;
        if (rb == null) return;
        var player = rb.GetComponent<PlayerController>();
        if (player == null) return;
        AddVelocity(player);
    }

    void AddVelocity(PlayerController player)
    {
        player.velocity.y = verticalVelocity;
    }
}
