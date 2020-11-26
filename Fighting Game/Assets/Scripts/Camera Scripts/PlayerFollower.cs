using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Missing target ref", this);
            return;
        }

        // position computation
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = playerTransform.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = playerTransform.position + offsetPosition;
        }

        // rotation computation
        if (lookAt)
        {
            transform.LookAt(playerTransform);
        }
        else
        {
            transform.rotation = playerTransform.rotation;
        }

    }
}
