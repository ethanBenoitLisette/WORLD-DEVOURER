using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{

    public GameObject Shop;
    // Start is called before the first frame update
    void Start()
    {
        Shop = GameObject.Find("ShopPanel");
        Shop.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerObject")
        {
            Shop.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerObject")
        {
            Shop.SetActive(false) ;
        }
    }
}
