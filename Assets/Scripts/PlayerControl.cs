using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 movement;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 pos;

    void Start()
    {
        InitCamera();
        pos = transform.localPosition;
        Debug.Log(pos);
    }

    void Update()
    {
        PlayerMove();
    }

    void InitCamera()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
        Debug.Log(minBounds);
        Debug.Log(maxBounds);

    }

    void PlayerMove()
    {
        Vector2 moveInput = movement * moveSpeed * Time.deltaTime;
        // Vector2 newPos = new Vector2();
        // newPos.x = Mathf.Clamp(pos.x + moveInput.x, minBounds.x, maxBounds.x);
        // newPos.y = Mathf.Clamp(pos.y + moveInput.y, minBounds.y, maxBounds.y);
        // Debug.Log(pos.y);
        // Debug.Log(pos.y);

        // transform.localPosition = newPos;
        transform.localPosition = moveInput;
    }



    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
