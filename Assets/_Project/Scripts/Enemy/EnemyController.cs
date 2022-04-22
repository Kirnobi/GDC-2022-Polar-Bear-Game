using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Header("Config"), Range(1, 3)] private float minSpeedValue;
    [SerializeField, Range(3, 6)] private float maxSpeedValue;
    [SerializeField] private string targetTag;

    private float _moveSpeed;

    private void Awake()
    {
        if (target != null) return;
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        _moveSpeed = Random.Range(minSpeedValue, maxSpeedValue);
    }

    private void Update()
    {
        var desiredPosition = Vector2.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        desiredPosition.y = transform.position.y;
        transform.position = desiredPosition;
    }

}

