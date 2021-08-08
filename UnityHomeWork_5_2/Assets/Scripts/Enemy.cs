using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
