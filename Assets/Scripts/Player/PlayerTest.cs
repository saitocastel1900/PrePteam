using System;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        TryGetComponent(out _animator);
    }

    private void Update()
    {
        var horizontal = UnityEngine.Input.GetAxis("Horizontal");
        var vertical = UnityEngine.Input.GetAxis("Vertical");
        var velocity = new Vector3(horizontal,0, vertical).normalized;
        var speed = UnityEngine.Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        
        Debug.Log(velocity.magnitude);
        _animator.SetFloat("Speed",velocity.magnitude*speed,0.1f,Time.deltaTime);
    }
}
