using UnityEngine;

public class DisplayMyCollision : MonoBehaviour, ICollidable
{
    [SerializeField] private string collisionText;

    public string GetMessageOnCollision()
    {
        return collisionText;
    }
}
