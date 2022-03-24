using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private UnityEvent<string> onCollision;
    [SerializeField, Tooltip("All collisions with objects that have this tag will trigger the UI")] private string collidableDisplayTag;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        // Check for tag rather than component b/c GetComponent is expensive.
        if (!collider.CompareTag(collidableDisplayTag)) return;
        var collidable = collider.GetComponent<ICollidable>();

        onCollision.Invoke(collidable.GetMessageOnCollision());
    }
}
