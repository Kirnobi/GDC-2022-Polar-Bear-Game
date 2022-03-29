using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private UnityEvent<string> onCollision;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collidable = collision.collider.GetComponent<ICollidable>();
        if (collidable == null) return;
        onCollision.Invoke(collidable.GetMessageOnCollision());
    }
}
