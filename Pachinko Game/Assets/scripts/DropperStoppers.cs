using UnityEngine;
public class DropperStoppers : MonoBehaviour
{
    [SerializeField]
    private float leftBoundry = -5.0f;
    [SerializeField]
    private float rightBoundry = 5.0f;
    [SerializeField]
    private float downBoundry = -5.0f;
    [SerializeField]
    private float upperBoundry = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, leftBoundry, rightBoundry);
        position.y = Mathf.Clamp(position.y, downBoundry, upperBoundry);
        transform.position = position;
    }
}
