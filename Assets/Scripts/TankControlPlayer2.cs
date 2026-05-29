using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TankControlPlayer2 : MonoBehaviour
{
    [Header("Основной код")]
    public Sprite basesprite;
    public Sprite firesprite;
    public SpriteRenderer playerSR;
    public GameObject playerObject;
    public float speed = 2f;
    private Rigidbody2D rb;
    bool gover = false;
    bool gohor = false;
    bool firecd = false;
    [Header("UI")]
    public GameObject player;
    public GameObject player2;
    public GameObject enemy;
    public bool PVP = false;
    public GameObject failtitle;
    public GameObject wintitle;
    public GameObject pvp1title;
    public GameObject pvp2title;
    public GameObject frame;

    void Update()
    {
        KeyBoard();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float hor = 0;
        float ver = 0;

        // Читаем нажатия клавиш IJKL
        if (Input.GetKey(KeyCode.I)) ver = 1;      // Вверх
        else if (Input.GetKey(KeyCode.K)) ver = -1; // Вниз

        if (Input.GetKey(KeyCode.L)) hor = 1;      // Вправо
        else if (Input.GetKey(KeyCode.J)) hor = -1; // Влево

        // Определяем приоритет движения (чтобы не ходить по диагонали, если нажаты обе оси)
        // В вашем коде была логика с gohor/gover — здесь она упрощена:
        Vector2 velocity = Vector2.zero;

        if (ver != 0)
        {
            velocity = new Vector2(0, ver * speed);
        }
        else if (hor != 0)
        {
            // Умножение на -1 сохранено из вашего оригинала
            velocity = new Vector2(hor * (-1 * speed), 0);
        }

        rb.linearVelocity = velocity;
        if (hor != 0 && gohor == false)
        {
            gohor = true;
        }
        else if (hor == 0 && gohor == true)
        {
            gohor = false;
        }
        if (ver != 0 && gover == false)
        {
            gover = true;
        }
        else if (ver == 0 && gover == true)
        {
            gover = false;
        }
        if (gover == true)
        {
            rb.linearVelocity = new Vector2(0, ver * speed);
        }
        if (gohor == true)
        {
            rb.linearVelocity = new Vector2(hor * (-1 * speed), 0);
        }

        if (rb.linearVelocity.x < 0)
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (rb.linearVelocity.x > 0)
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (rb.linearVelocity.y > 0)
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rb.linearVelocity.y < 0)
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    void KeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.O) && firecd == false)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        firecd = true;
        playerSR.sprite = firesprite;
        if (playerObject.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0, 0.55f, 0)), Vector2.up, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    if (PVP == true)
                    {
                        frame.transform.localScale = Vector3.one;
                        pvp2title.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (playerObject.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0, 0.55f, 0)), Vector2.down, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    if (PVP == true)
                    {
                        frame.transform.localScale = Vector3.one;
                        pvp2title.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (playerObject.transform.rotation == Quaternion.Euler(0, 0, -90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0.55f, 0, 0)), Vector2.right, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    if (PVP == true)
                    {
                        frame.transform.localScale = Vector3.one;
                        pvp2title.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (playerObject.transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0.55f, 0, 0)), Vector2.left, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    if (PVP == true)
                    {
                        frame.transform.localScale = Vector3.one;
                        pvp2title.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
        playerSR.sprite = basesprite;
        yield return new WaitForSeconds(1.4f);
        firecd = false;
    }
}
