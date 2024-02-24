using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float ControlPitchFacotr = -10f;
    [SerializeField] float positionYawFactor = -10f;
    [SerializeField] float ControlRollFacotr = -10f;
    Vector2 movement;


    void Update()
    {
        ProcessTranslation();
        ProcessRotaton();
    }

    void ProcessRotaton()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = movement.y * ControlPitchFacotr;

        float pitch =  pitchDueToPosition + pitchDueToControl; 
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = movement.x * ControlRollFacotr;
        
        transform.localRotation = Quaternion.Euler(pitch, roll, yaw);
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * moveSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXpos + xOffset, -xRange, xRange);

        float yOffset = movement.y * moveSpeed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYpos + yOffset, -yRange + 5.3f, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }



    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log(movement);
    }
}
