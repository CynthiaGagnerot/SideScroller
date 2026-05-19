using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
    public Rigidbody2D rb; //Ne pas oublier d'activer la gravity scale du rigidbody et d'ajouter un collider
    public float speed = 1;
    public float jumpforce = 1;
    public float jumpdetector = 1.5f;
    public LayerMask mask; //Quels layer seront affect� par le raycast attention a ne pas ajouter le layer de votre perso sinon le raycast va trouver le perso avant de trouver le sol
    public bool isGrounded;
    public Animator animator;
    [SerializeField] private Transform childT;

    public void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;
        isGrounded = CheckGround();
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                print("Space");
                vDirection += jumpforce;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hDirection += -1;
            Debug.Log("Test Cam");
            childT.transform.localEulerAngles = new Vector3 (0, 180, 0);
            transform.localEulerAngles = new Vector3 (0, 180, 0);
            Debug.Log("Test Cam 2");
            
        }
      

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hDirection += 1;
            Debug.Log("Test Cam");
            childT.transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            Debug.Log("Test Cam 2");

        }
       
     
            
        


            rb.linearVelocity = new Vector2(hDirection * speed, rb.linearVelocityY + vDirection); //On set up la velocit� horizontal 
        if (rb.linearVelocity.x !=0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (rb.linearVelocity.y > 0f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if(rb.linearVelocity.y < 0f)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }

        else animator.SetBool("IsFalling", false);
    }


    public bool CheckGround()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), jumpdetector, mask);
        if (rayCastHit)
        {
            print("raycasthit");
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(transform.position, Vector3.down * jumpdetector);
    }
}