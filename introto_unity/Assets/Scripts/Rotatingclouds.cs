using UnityEngine;

public class Rotatingclouds : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private float rotation = 0.0f;
    // Update is called once per frame
    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);

    }
}
