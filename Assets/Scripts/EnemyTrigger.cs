using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.Reach();
        }   
    }
}
