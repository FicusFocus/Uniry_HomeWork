using UnityEngine;

public class PlayerKiller : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            player.DestroyPlayer();
    }
}