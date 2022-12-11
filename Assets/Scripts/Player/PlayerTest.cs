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
        
    }
}
