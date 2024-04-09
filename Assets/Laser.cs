using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform FirePoint;

    public float BeamLength = 20f;

    public LayerMask WhatIsShootable;

    public LineRenderer lineRenderer;
    private bool isShooting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            isShooting = true;
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
            lineRenderer.enabled = false;
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Vector3 endPos;

        if(Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 10, WhatIsShootable))
        {
            endPos = hit.point;
            Debug.Log("Shoot at " + hit.transform.name);
            Destroy(hit.transform.gameObject);
        }
        else
        {
            endPos = transform.position + FirePoint.forward * BeamLength;
        }
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, endPos);
        lineRenderer.enabled = true;
    }
}