using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraScript : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 2f;
    float cameraVeticalRotation = 0f;

    // Animation Trees
    public Animator cowboyHatAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis("Mouse X")* mouseSensitivity;
        float InputY = Input.GetAxis("Mouse Y")* mouseSensitivity;

        cameraVeticalRotation -= InputY;
        cameraVeticalRotation = Mathf.Clamp(cameraVeticalRotation, -90, 90);
        transform.localEulerAngles = Vector3.right * cameraVeticalRotation;

        player.Rotate(Vector3.up * InputX);

        // Raycast

        RaycastHit hit;
        Ray playerRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(playerRay,out hit, 10000f))
        {
            Debug.Log("Hit");
            //Here are all the animators
            if (hit.collider.name == ("Cowboy Hat"))
            {
                cowboyHatAnimator.SetBool("isTriggered", true);
                Debug.Log("hit hat");
            }
            if (hit.collider.name != ("Cowboy Hat"))
            {
                cowboyHatAnimator.SetBool("isTriggered", false);
            }
        }

    }
}
