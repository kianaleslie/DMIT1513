using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    int damage = 10;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioSource explosionSound;

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ApplyDamage(damage);
        }
        explosion.Play();
        explosionSound.Play();
        gameObject.SetActive(false);
    }
}