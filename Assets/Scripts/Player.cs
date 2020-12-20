using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In m")] [SerializeField] float yMin = -5f;
    [Tooltip("In m")] [SerializeField] float yMax = 5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger!");
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControlThrow = yThrow * positionPitchFactor;
        float pitch = pitchDueToPosition + pitchDuetoControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, yMin, yMax);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
