using Unity.VisualScripting;
using UnityEngine;

public class PannelManager : MonoBehaviour
{
    
    public bool Proxi = false; //proxi = a proximite
    public bool dialogueManagerState = false;

    public GameObject Ebutton;
    public GameObject dialogueManagerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Proxi == true && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueManagerState == false)
            {
                dialogueManagerState = true;
                dialogueManagerObj.SetActive(dialogueManagerState);
            }

            else
            {
                dialogueManagerState = false;
                dialogueManagerObj.SetActive(dialogueManagerState);
            }

        }
        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sip"))
        {
            Proxi = true;
            Ebutton.SetActive(true);
        }       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sip"))
        {
            Proxi = false;
            Ebutton.SetActive(false);
        }
    }

}
