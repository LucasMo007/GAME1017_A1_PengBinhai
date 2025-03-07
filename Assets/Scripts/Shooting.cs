using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float projcetileLifetime = 5f;

    public bool isFiring;

    Coroutine firingCoroutine;
    void Start()
    {
        
    }

 
    void Update()
    {
        Fire();
    }

    void Fire()  
    {     
        if (isFiring && firingCoroutine == null ) 
        { 
         firingCoroutine = StartCoroutine(FireContinuously());

        }
      else if (!isFiring && firingCoroutine != null)
        { 
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }


    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                              transform.position, 
                                              Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projcetileLifetime);
            yield return new WaitForSeconds(fireRate);

        }
    }
}
