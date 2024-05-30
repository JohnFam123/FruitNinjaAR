using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Blade2 : MonoBehaviour
{
    private Camera mainCamera;
    private bool slicing;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;

    public Vector3 direction { get; private set; }
    public float minSlideVelocity = 0.01f;
    public float sliceForce = 5f;

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }

    }

    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;
        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;   
        bladeTrail.Clear();   
    }

    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }
    private void OnUnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }
       
    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        //bladeCollider.enabled = velocity > minSlideVelocity;
        //bladeTrail.enabled = velocity > 0.0001f;
        //if (velocity < minSlideForce) { velocity = minSlideForce; }

        transform.position = newPosition;
    }
}
