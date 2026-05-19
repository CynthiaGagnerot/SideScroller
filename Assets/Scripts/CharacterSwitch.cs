using Unity.Cinemachine;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{

    public PlayerMovementPlatformer playerController;
    public PlayerMovementPlatformer player2Controller;
    public bool player1Active = true;
    public bool isCalling = false; 
    private void Awake()
    {
        player1Active = true;
        playerController.enabled = true;
        player2Controller.enabled = false;
        playerController.GetComponentInChildren<CinemachineCamera>().enabled = true;
        player2Controller.GetComponentInChildren<CinemachineCamera>().enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCharacter();
    }
    public void SwitchCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (player1Active)
            {
                playerController.enabled = false;
                player2Controller.enabled = true;
                player1Active = false;
                playerController.GetComponentInChildren<CinemachineCamera>().enabled = false;
                player2Controller.GetComponentInChildren<CinemachineCamera>().enabled = true;
            }
            else
            {
                playerController.enabled = true;
                player2Controller.enabled = false;
                player1Active = true;
                playerController.GetComponentInChildren<CinemachineCamera>().enabled = true;
                player2Controller.GetComponentInChildren<CinemachineCamera>().enabled = false;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("sip détecté");
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (collision.gameObject.tag == "Sip")
            {
                isCalling = !isCalling;
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                Collider2D col = collision.gameObject.GetComponent<Collider2D>();
                if (rb.gravityScale > 0)
                {
                    rb.gravityScale = 0;
                    rb.bodyType = RigidbodyType2D.Static;
                    col.isTrigger = true;
                }
                else
                {

                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 0.75f;
                    col.isTrigger = false;
                }

            }
        }
        
    }

}
