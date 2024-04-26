using UnityEngine;

public class PlayerCamFollow : MonoBehaviour
{
    public Vector3 offset;
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Awake()
    {
        offset= new Vector3(0f, 2f, -11f);
    }
    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
