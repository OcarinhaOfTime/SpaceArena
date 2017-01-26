using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public float rotateSpeed = 5;
    public GameObject player;
    public GameObject fpCamera;
    public GameObject tpCamera;
    public Transform thirdPersonPosition;
    public bool ThirdPersonSmooth = false;
    private Vector2 center;
    private Vector3 offset;


    public CameraMode cameraMode;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        center = new Vector2(Screen.width / 2, Screen.height / 2);
        Cursor.lockState = CursorLockMode.None;
        ChangeCamera(CameraMode.ThirdPerson);

    }

    public void ChangeCamera(CameraMode mode)
    {
        this.cameraMode = mode;
        if (mode == CameraMode.ThirdPerson)
        {
            fpCamera.SetActive(false);
            tpCamera.SetActive(true);
        }
        else if (mode == CameraMode.FirstPerson)
        {
            fpCamera.SetActive(true);
            tpCamera.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector2 currentDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - center;
        currentDistance = new Vector2(currentDistance.x / center.x, currentDistance.y / center.y);

        //TODO: Smooth e deadzone
        //if (currentDistance.x > -.1f && currentDistance.x < .1f && currentDistance.y > -.1f && currentDistance.y < .1f) currentDistance = Vector2.zero;
        //else
        //{
        //    currentDistance.x -= .1f;
        //    currentDistance.y -= .1f;
        //}

        player.transform.Rotate(new Vector3(-currentDistance.y, currentDistance.x, 0f) * rotateSpeed);

        if (cameraMode == CameraMode.ThirdPerson)
        {
            //if (ThirdPersonSmooth)
            //{

            //    //TODO: arrumar o smooth

            //    float t = Time.deltaTime * rotateSpeed * Vector3.Distance(tpCamera.transform.position, thirdPersonPosition.transform.position);

            //    Vector3 newPosition = Vector3.Lerp(tpCamera.transform.position, thirdPersonPosition.transform.position, t);

            //    if (Vector3.Distance(newPosition, thirdPersonPosition.transform.position) > 2)
            //    {
            //        var aux = (thirdPersonPosition.transform.position - newPosition).normalized;
            //        newPosition = newPosition + (aux * 2);
            //    }

            //    tpCamera.transform.position = newPosition;

            //    tpCamera.transform.rotation = Quaternion.Slerp(tpCamera.transform.rotation, player.transform.rotation, t);
            //}
            //else
            //{
            tpCamera.transform.position = thirdPersonPosition.position;
            tpCamera.transform.rotation = thirdPersonPosition.rotation;
            //}
        }

    }

    public void RollLeft()
    {
        transform.Rotate(-transform.forward * rotateSpeed);
    }

    public void RollRight()
    {
        transform.Rotate(transform.forward * rotateSpeed);
    }

    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson
    }
}
