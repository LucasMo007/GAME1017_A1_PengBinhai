using UnityEngine;

public class CouscousPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 1;
    [SerializeField] AudioClip pickupSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerCouscous playerCouscous = other.GetComponent<PlayerCouscous>();
            if (playerCouscous != null)
            {
                playerCouscous.AddAmmo(ammoAmount);
            }

           
            if (pickupSFX != null)
            {
                //AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
                MainController.Instance.SoundManager.PlayClipAtCamera(pickupSFX);
            }

            Destroy(gameObject);
        }
    }
}
