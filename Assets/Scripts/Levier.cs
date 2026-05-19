using Unity.VisualScripting;
using UnityEngine;

public class Levier : MonoBehaviour
{
    public bool LeverState=false;
    public bool Proxi=false; //proxi = a proximite
    public GameObject toMove;
    public Transform posDesactivee;
    public Transform posActivee;
    public float activeSpeed;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Proxi == true && Input.GetKeyDown(KeyCode.E))
        {
            if (LeverState == false)
            {
                LeverState = true;
                animator.SetTrigger("Activate");
            }

            else
            {
                LeverState = false;
                animator.SetTrigger("Activate");
            }

        }
        if (LeverState ==true)
        {
            var diffX = toMove.transform.position.x - posActivee.position.x;
            var diffY = toMove.transform.position.y - posActivee.position.y ;
            if ((diffX != 0) || (diffY != 0))
            {
                toMove.transform.position = new Vector3((toMove.transform.position.x + diffX * activeSpeed), (toMove.transform.position.y - diffY * activeSpeed), 0);
            }
        }
        else
        {
            var diffX = posDesactivee.position.x - toMove.transform.position.x;
            var diffY = posDesactivee.position.y - toMove.transform.position.y;
            if ((diffX != 0) || (diffY != 0))
            {
                toMove.transform.position = new Vector3((toMove.transform.position.x + diffX * activeSpeed), (toMove.transform.position.y + diffY * activeSpeed), 0);
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Proxi = true;

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Proxi = false;
    }

}
