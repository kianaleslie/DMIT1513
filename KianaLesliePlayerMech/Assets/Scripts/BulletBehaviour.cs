using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ApplyDamage(damage);
        }
        gameObject.SetActive(false);
    }
}