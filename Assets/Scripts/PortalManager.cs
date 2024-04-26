using System.Collections;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] Transform otherPortal;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Vector3.Distance(other.gameObject.transform.position, transform.position)>0.5f)
            {
                StartCoroutine(Travel(other.gameObject));
            }
        }
    }

    IEnumerator Travel(GameObject player)
    {
        player.GetComponent<Animator>().SetBool("InPortal", true);
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<Rigidbody>().Sleep();
        yield return new WaitForSeconds(0.4f);
        player.transform.position = otherPortal.position;// +new Vector3(4f,0,0);
        player.GetComponent<Animator>().SetBool("InPortal", false);
        yield return new WaitForSeconds(0.4f);
        player.GetComponent<Rigidbody>().WakeUp();

    }
}
