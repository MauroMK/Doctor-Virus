using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // That's the player
    public Transform lookAt;

    [SerializeField] private float boundX = 0.15f;
    [SerializeField] private float boundY = 0.05f;

    private void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        Vector3 delta = Vector3.zero;

        // Checks if we'are inside the bounds on the X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // Checks if we'are inside the bounds on the Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY)
        {
            if(transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
