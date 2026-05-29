using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Основной код")]
    public float speed;
    public GameObject enemyObject;
    public GameObject target;
    public Sprite firesprite;
    public Sprite basesprite;
    public SpriteRenderer enemySR;
    public bool firecd = false;
    [Header("Второстепенный код")]
    public bool winner = false;
    public float angle;
    public GameObject rttgameObject;
    public GameObject rbtgameObject;
    public GameObject lttgameObject;
    public GameObject lbtgameObject;
    public GameObject wtsys;
    public Quaternion lasteuler = Quaternion.Euler(0,0,0);
    public bool walltouch = false;
    public bool cdgo = false;
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
    Vector3 direction;
    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool rttbool;
    bool rbtbool;
    bool lbtbool;
    bool lttbool;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rttbool = rttgameObject.GetComponent<WTscript>().isTriggered;
        rbtbool = rbtgameObject.GetComponent<WTscript>().isTriggered;
        lttbool = lttgameObject.GetComponent<WTscript>().isTriggered;
        lbtbool = lbtgameObject.GetComponent<WTscript>().isTriggered;
        if (target != null) { direction = target.transform.position - transform.position; }
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //СВОБОДНОЕ ПЕРЕМЕЩЕНИЕ
        Go();
        CheckFire();
    }
    void Go()
    {
        if (angle > -45 && angle <= 45 && (rttbool == false && rbtbool == false && lttbool == false && lbtbool == false))
        {
            if (cdgo == false)
            {
                if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, -90))
                {
                    //rb.linearVelocity = new Vector2(0, -1 * speed);
                    rb.linearVelocity = new Vector2(1 * speed, 0);
                }
                else
                {
                    if (b1 == false)
                    {
                        StartCoroutine(CdGo());
                        StartCoroutine(Cd1());
                    }
                    if (b1 == true)
                    {
                        rb.linearVelocity = new Vector2(1 * speed, 0);
                        enemyObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                }
            }
        }
        else if (angle > 45 && angle <= 135 && (rttbool == false && rbtbool == false && lttbool == false && lbtbool == false))
        {
            if (cdgo == false)
            {
                if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    //rb.linearVelocity = new Vector2(0, -1 * speed);
                    rb.linearVelocity = new Vector2(0, 1 * speed);
                }
                else
                {
                    if (b2 == false)
                    {
                        StartCoroutine(CdGo());
                        StartCoroutine(Cd2());
                    }
                    if (b2 == true)
                    {
                        rb.linearVelocity = new Vector2(0, 1 * speed);
                        enemyObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }

            }
        }
        else if ((angle < -45 && angle >= -135) && (rttbool == false && rbtbool == false && lttbool == false && lbtbool == false))
        {
            if (cdgo == false)
            {
                if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 180))
                {
                    //rb.linearVelocity = new Vector2(0, -1 * speed);
                    rb.linearVelocity = new Vector2(0, -1 * speed);
                }
                else
                {
                    if (b3 == false)
                    {
                        StartCoroutine(CdGo());
                        StartCoroutine(Cd3());
                    }
                    if (b3 == true)
                    {
                        rb.linearVelocity = new Vector2(0, -1 * speed);
                        enemyObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }
            }
        }
        else
        {
            if (cdgo == false && (rttbool == false && rbtbool == false && lttbool == false && lbtbool == false))
            {
                if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 90))
                {
                    //rb.linearVelocity = new Vector2(0, -1 * speed);
                    rb.linearVelocity = new Vector2(-1 * speed, 0);
                }
                else
                {
                    if (b4 == false)
                    {
                        StartCoroutine(CdGo());
                        StartCoroutine(Cd4());
                    }
                    if (b4 == true)
                    {
                        rb.linearVelocity = new Vector2(-1 * speed, 0);
                        enemyObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
            }
        }
    }
    void CheckFire()
    {
        if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0, 0.55f, 0)), Vector2.up, 100);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player") && firecd == false)
                {
                    StartCoroutine(Fire());
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0, 0.55f, 0)), Vector2.down, 100);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player") && firecd == false)
                {
                    StartCoroutine(Fire());
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, -90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0.55f, 0, 0)), Vector2.right, 100);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player") && firecd == false)
                {
                    StartCoroutine(Fire());
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0.55f, 0, 0)), Vector2.left, 100);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player") && firecd == false)
                {
                    StartCoroutine(Fire());
                }
            }
        }
    }
    void SetWinner()
    {
        winner = true;
    }
    IEnumerator Fire()
    {
        firecd = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 1f));
        enemySR.sprite = firesprite;
        if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0, 0.55f, 0)), Vector2.up, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    SetWinner();
                    if (PVP == false)
                    {
                        frame.transform.localScale = Vector3.one;
                        failtitle.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0, 0.55f, 0)), Vector2.down, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    SetWinner();
                    if (PVP == false)
                    {
                        frame.transform.localScale = Vector3.one;
                        failtitle.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, -90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position + new Vector3(0.55f, 0, 0)), Vector2.right, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    SetWinner();
                    if (PVP == false)
                    {
                        frame.transform.localScale = Vector3.one;
                        failtitle.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        else if (enemyObject.transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            RaycastHit2D hit = Physics2D.Raycast((transform.position - new Vector3(0.55f, 0, 0)), Vector2.left, 100);
            if (hit.collider != null)
            {
                Debug.Log("Попадание" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.collider.gameObject);
                    SetWinner();
                    if (PVP == false)
                    {
                        frame.transform.localScale = Vector3.one;
                        failtitle.transform.localScale = Vector3.one;
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
        enemySR.sprite = basesprite;
        yield return new WaitForSeconds(1.4f);
        firecd = false;
    }
    IEnumerator CdGo()
    {
        cdgo = true;
        yield return new WaitForSeconds(0.25f);
        cdgo = false;
    }
    IEnumerator Cd4()
    {
        yield return new WaitForSeconds(0.25f);
        b1 = false;
        b2 = false;
        b3 = false;
        b4 = true;
    }
    IEnumerator Cd3()
    {
        yield return new WaitForSeconds(0.25f);
        b1 = false;
        b2 = false;
        b3 = true;
        b4 = false;
    }
    IEnumerator Cd2()
    {
        yield return new WaitForSeconds(0.25f);
        b1 = false;
        b2 = true;
        b3 = false;
        b4 = false;
    }
    IEnumerator Cd1()
    {
        yield return new WaitForSeconds(0.25f);
        b1 = true;
        b2 = false;
        b3 = false;
        b4 = false;
    }
}
