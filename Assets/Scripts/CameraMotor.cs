using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;

    // distances to move before camera also moves
    public float boundX = 0.3f;
    public float boundY = 0.15f; 

    // called after Update() and FixedUpdate()
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero; // difference between this and next frame

        // check if we're inside the bounds on x axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) {
            if (transform.position.x < lookAt.position.x) {
                delta.x = deltaX - boundX;
            } else {
                delta.x = deltaX + boundX;
            }
        }

        // check if we're inside the bounds on y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) {
            if (transform.position.y < lookAt.position.y) {
                delta.y = deltaY - boundY;
            } else {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3 (delta.x, delta.y, 0);
    }
}
