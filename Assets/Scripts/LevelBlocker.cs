using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelBlocker : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] public TextMeshProUGUI message;
 
    public GameObject mensajeObjeto;


    void Start()
    {

        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
     
       
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerInventory != null)
        {
            if (playerInventory.inventory.slots[0].count >= 7 )
            {
                Destroy(gameObject);
            }
            else{
              
                mensajeObjeto.SetActive(true);
                message.text = "You need 7 blue books to open this door";
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        mensajeObjeto.SetActive(false);
    }


}


