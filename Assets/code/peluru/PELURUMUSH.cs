using UnityEngine;

public class PELURUMUSH : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika menyentuh objek dengan tag "Boundary"
        if (other.CompareTag("Boundary")) // Unity built-in → untuk membandingkan tag objek
        {
            Destroy(gameObject); // Unity built-in → hapus objek dari scene
        }
    }
}
