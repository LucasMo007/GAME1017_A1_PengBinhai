using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    Vector2 rawInput;
    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 delta = rawInput * movespeed * Time.deltaTime;

        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }

}



