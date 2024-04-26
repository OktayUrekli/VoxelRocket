using UnityEngine;

public class AreaEffector3D : MonoBehaviour
{
    Transform effector;
    [SerializeField] float force=5f;
    [SerializeField] LayerMask effectedObjLayer;
    Vector3 direction;
    float zRotation;

    private void Awake()
    {
        effector = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        zRotation = effector.transform.localEulerAngles.z;
        direction = FindRotation();
    }
    void Update()
    {

        Collider[] colliders= Physics.OverlapBox(effector.transform.position,effector.transform.localScale,
            Quaternion.Euler(0,0,0),effectedObjLayer);

        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direction*force * Time.deltaTime,ForceMode.Force);
            }
        }
    }

    Vector3 FindRotation()
    {
        float y=Mathf.Sin(zRotation);
        float x=Mathf.Cos(zRotation);
        
        return new Vector3(x,y,0);
    }
}
