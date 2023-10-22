using UnityEngine;

public class PaintableObject : MonoBehaviour
{
    public Material colour;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paintball"))
        {
            //colour change
            GetComponent<Renderer>().material = colour;

            // Destroy the cannonBall
            Destroy(collision.gameObject);
        }
    }
}
