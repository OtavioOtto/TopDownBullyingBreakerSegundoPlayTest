using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed;
    [Header("Player Properties")]
    public static Transform spawnPoint;
    public float rotacaoSpeed = 720;
    private Rigidbody2D rb;
    public bool canMove = true;
    public static PlayerController player;

    [Header("Item Quantities")]
    public static int curativoQuant;
    public static int sucoQuant;
    public static int frutaQuant;
    public static int brocheQuant;
    public static int oculosQuant;
    public static int jaquetaQuant;
    public static int cadernoQuant;
    public static int lapisQuant;
    public static int tesouraQuant;

    [Header("Equipped Items")]
    public static string currentWeapon;
    public static string currentDefenseItem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if(canMove)
        HandleMovement();

    }

    public void HandleMovement()
    {

        if (Input.GetButton("HORIZONTAL0") || Input.GetButton("VERTICAL0"))
        {
            float moveInputX = Input.GetAxis("HORIZONTAL0");
            float moveInputY = Input.GetAxis("VERTICAL0");
            rb.velocity = new Vector2(moveInputX * walkSpeed, moveInputY * walkSpeed);
        }

    }

    public void GotItem(string name)
    {
        if (name == "curativo")
            curativoQuant++;

        else if (name == "suco")
            sucoQuant++;

        else if (name == "fruta")
            frutaQuant++;

        else if (name == "caderno")
            cadernoQuant++;

        else if (name == "lapis")
            lapisQuant++;

        else if (name == "tesoura")
            tesouraQuant++;

        else if (name == "broche")
            brocheQuant++;

        else if (name == "oculos")
            oculosQuant++;

        else if (name == "jaqueta")
            jaquetaQuant++;
    }
    public void ChangeSpawnPoint(Transform newSpawn) {

        spawnPoint = newSpawn;

    }


    public static float GetWeaponDamage()
    {
        float damage = 0;
        if (currentWeapon == "caderno") {
            damage = 2;
        }

        else if (currentWeapon == "lapis")
        {
            damage = 3;
        }

        else if (currentWeapon == "tesoura")
        {
            damage = 6;
        }
        return damage;

    }

    public static float GetItemDefense()
    {
        float defense = 0;
        if (currentDefenseItem == "broche")
        {
            defense = 3;
        }

        else if (currentDefenseItem == "oculos")
        {
            defense = 5;
        }

        else if (currentDefenseItem == "jaqueta")
        {
            defense = 9;
        }
        return defense;

    }

    public float GetItemHealValue(string item)
    {
        float healValue = 0;
        if (item == "broche")
        {
            healValue = 10;
        }

        else if (item == "oculos")
        {
            healValue = 15;
        }

        else if (item == "jaqueta")
        {
            healValue = 20;
        }
        return healValue;

    }

    public void SetCurrentWeapon(string item)
    {
        if (currentWeapon == "caderno") {
            cadernoQuant++;
        }

        else if (currentWeapon == "lapis")
        {
            lapisQuant++;
        }

        else if (currentWeapon == "tesoura")
        {
            tesouraQuant++;
        }
        item = currentWeapon;
        if (currentWeapon == "caderno")
        {
            cadernoQuant--;
        }

        else if (currentWeapon == "lapis")
        {
            lapisQuant--;
        }

        else if (currentWeapon == "tesoura")
        {
            tesouraQuant--;
        }

    }

    public void SetCurrentDefenseItem(string item)
    {
        if (currentDefenseItem == "broche")
        {
            brocheQuant++;
        }

        else if (currentDefenseItem == "oculos")
        {
            oculosQuant++;
        }

        else if (currentDefenseItem == "jaqueta")
        {
            jaquetaQuant++;
        }
        item = currentDefenseItem;
        if (currentDefenseItem == "broche")
        {
            brocheQuant--;
        }

        else if (currentDefenseItem == "oculos")
        {
            oculosQuant--;
        }

        else if (currentDefenseItem == "jaqueta")
        {
            jaquetaQuant--;
        }

    }

    public void UseHealItem(string item)
    {
        if (item == "curativo")
        {
            curativoQuant--;
        }

        else if (item == "suco")
        {
            sucoQuant--;
        }

        else if (item == "fruta")
        {
            frutaQuant--;
        }

    }


}
