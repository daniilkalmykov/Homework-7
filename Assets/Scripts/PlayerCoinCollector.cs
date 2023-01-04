using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
        }
    }
}
