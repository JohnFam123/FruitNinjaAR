using System.Collections;
using UnityEngine;

public class Fruit2 : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;

    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
    }

    private void Slice (Vector3 direction, Vector3 position, float force)
    {
        FindObjectOfType<GameManager>().IncreaseScore();

        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;
        FindObjectOfType<BladeSound>().PlayBladeSound();

        float angle = Mathf.Atan2(position.y, position.x)* Mathf.Rad2Deg;

        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player")){
            Blade2 blade = other.GetComponent<Blade2>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}
