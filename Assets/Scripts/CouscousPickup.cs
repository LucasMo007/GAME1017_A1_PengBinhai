using UnityEngine;

public class CouscousPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 1;
    [SerializeField] AudioClip pickupSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰到的是不是玩家
        if (other.CompareTag("Player"))
        {
            PlayerCouscous playerCouscous = other.GetComponent<PlayerCouscous>();
            if (playerCouscous != null)
            {
                playerCouscous.AddAmmo(ammoAmount);
            }

            // 播放音效
            if (pickupSFX != null)
            {
                AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
            }

            Destroy(gameObject);
        }
    }
}
