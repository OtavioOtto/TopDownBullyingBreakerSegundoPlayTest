using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteiraCollider : MonoBehaviour
{
    [Header("Carteira Configs")]
    public string item;
    public GameObject carteira;
    public SpriteRenderer carteiraRenderer;
    [Header("Collider Verifier")]
    [SerializeField] private bool playerIsInside = false;
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Transform child = transform.GetChild(0);
        carteiraRenderer = carteira.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (playerIsInside) {

            Transform child = transform.GetChild(0);

            if (Input.GetButtonDown("VERDE0") && child.gameObject.activeSelf)
            {
                playerController.GotItem(item);
                DeleteChild();
                carteiraRenderer.color = Color.white;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsInside = false;
        }
    }
    public void DeleteChild()
    {
        transform.GetChild(0).gameObject.SetActive(false);

    }
}