using UnityEngine;

public class DestroyState : State
{
    private void Start()
    {
        Destroy(gameObject);
    }
}
