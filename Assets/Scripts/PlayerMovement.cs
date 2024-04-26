using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody myRigidboy;
    Transform myTransform;
    AudioSource myAudioSource;
    TrailRenderer myTrailRenderer;


    [SerializeField] int thrustingMultiplier,rotationMultiplier;
    [SerializeField] ParticleSystem leftThrustVFX, rightThrustVFX, mainThrustVFX;
    [SerializeField] Animator canDashAnim;
    [SerializeField] AudioClip thrustSFX,dashSFX;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    private void Awake()
    {
        myRigidboy = GetComponent<Rigidbody>();       
    }

    void Start()
    {
        myTransform=GetComponent<Transform>();
        myAudioSource = GetComponent<AudioSource>();
        myTrailRenderer = GetComponent<TrailRenderer>();    
        thrustingMultiplier = 1150;
        rotationMultiplier = 100;
        canDashAnim.SetBool("CanDash", true);

    }

    void Update()
    {
        if (isDashing){ return;}
        CouldPlayerDash();
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidboy.AddRelativeForce(Vector3.up*thrustingMultiplier*Time.deltaTime);
            
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.PlayOneShot(thrustSFX);
                mainThrustVFX.Play();
                GetComponent<FuelManager>().Fuel();
            }
          
        }
        else 
        {
            
            mainThrustVFX.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Rotate(Vector3.forward *rotationMultiplier* Time.deltaTime);// saat yönünün tersine dönüþ
            
            if (!rightThrustVFX.isPlaying)
            {
                rightThrustVFX.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myTransform.Rotate(Vector3.back * rotationMultiplier* Time.deltaTime);// saat yönünde dönüþ
            if (!leftThrustVFX.isPlaying)
            {
                leftThrustVFX.Play();
            }
        }
        else
        {
            rightThrustVFX.Stop();
            leftThrustVFX.Stop();
        }
    }

    void CouldPlayerDash()
    {

        if (Input.GetKeyDown(KeyCode.E)  && canDash)
        {
            StartCoroutine(ProcessDash(1));  
            myAudioSource.PlayOneShot(dashSFX);
        }
        else if (  Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            StartCoroutine(ProcessDash(-1));
            myAudioSource.PlayOneShot(dashSFX);
        }
        
    }

     IEnumerator ProcessDash(int direction)
    {
        GetComponent<FuelManager>().FuelAfterDash();
        canDash = false;
        canDashAnim.SetBool("CanDash", false);
        isDashing = true;
        myRigidboy.useGravity = false;
        myRigidboy.velocity = new Vector3(transform.localScale.x * dashingPower*direction, 0f,0f);
        myTrailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        myTrailRenderer.emitting = false;
        myRigidboy.useGravity=true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        canDashAnim.SetBool("CanDash", true);
    }

   
}
