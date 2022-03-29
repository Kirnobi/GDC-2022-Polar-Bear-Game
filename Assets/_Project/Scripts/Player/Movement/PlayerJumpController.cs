using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController player;
    [SerializeField]
    private string matchTag = "Jumpable";

    private Animator _animator;
    private void Awake()
    {
        _animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == matchTag)
        {
            player.setJumps(player.getMaxJumps());
            _animator.SetBool("IsJumping", false);
        }
    }
}
