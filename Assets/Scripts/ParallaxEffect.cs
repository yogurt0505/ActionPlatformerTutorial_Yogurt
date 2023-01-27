using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    //Starting positionfor the parallax game object
    Vector2 startingPosition;

    //Start Z value of the parallax game object
    float startingZ;

    //Distance that the camera has moved from the starting position of the parallax object
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    //The further thr object from the player, the faster the ParallaxEffect object will move.
    //Drag it's z value closer to the target to make it move slower.
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);

    }
}
