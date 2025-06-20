using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    Vector2 rawInput;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    [SerializeField] GameObject couscousMissilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioClip catRoarClip;

    PlayerCouscous playerCouscous;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooting shooter;

    void Awake()
    {
        shooter = GetComponent<Shooting>();
        playerCouscous = GetComponent<PlayerCouscous>();
    }
    void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void InitBounds()
    {   Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void move()
    {
        Vector2 delta = rawInput * movespeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x+paddingLeft, maxBounds.x-paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y+paddingBottom, maxBounds.y-paddingTop);
        transform.position = newPos;
    }
    void OnCouscousFire(InputValue value)
    {
        if (value.isPressed && playerCouscous.CanFire())
        {
            Instantiate(couscousMissilePrefab, firePoint.position, Quaternion.identity);
            playerCouscous.UseAmmo();

            if (catRoarClip != null)
            {
                AudioSource.PlayClipAtPoint(catRoarClip, Camera.main.transform.position);
            }
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
       
    }
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}



