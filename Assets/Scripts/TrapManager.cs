using UnityEngine;

public class TrapManager : MonoBehaviour

{
    public bool plateState = false;
    
    [Header("PlateSprite")]
    [SerializeField] private SpriteRenderer plate;
    [SerializeField] private Sprite activatePlate;
    [SerializeField] private Sprite desactivatePlate;
    [Header("TrapSprite")]
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            plateState = true;
            plate.sprite = activatePlate;
            animator.SetBool("IsOpening", true);
        }
        //else
        //{
        //    plateState = false;
        //    plate.sprite = desactivatePlate;
        //    animator.SetBool("IsOpening", false);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        plateState = false;
        plate.sprite = desactivatePlate;
        animator.SetBool("IsOpening", false);
    }
}
