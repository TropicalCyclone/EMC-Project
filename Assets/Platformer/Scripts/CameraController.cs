using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector2 Offset;
    public Vector2 minBound, maxBound;
    private void Update()
    {
        if (Player.transform.position.x > minBound.x && Player.transform.position.x < maxBound.x 
            )
        {
            transform.position = new Vector3(Player.position.x + Offset.x, transform.position.y, transform.position.z); ;
        }

    }
}
