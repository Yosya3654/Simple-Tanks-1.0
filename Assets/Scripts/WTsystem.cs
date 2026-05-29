using UnityEngine;
using System.Collections;

public class WTsystem : MonoBehaviour
{
    public GameObject rttgameObject;
    public GameObject rbtgameObject;
    public GameObject lttgameObject;
    public GameObject lbtgameObject;
    GameObject NPC;
    Rigidbody2D rb2d;
    EnemyScript enemyScript;
    bool rttbool;
    bool rbtbool;
    bool lbtbool;
    bool lttbool;
    bool wt;
    bool cg;
    bool checkblock = false;
    public bool ver = false;
    void Start()
    {
        NPC = transform.parent.gameObject;
        rb2d = NPC.GetComponent<Rigidbody2D>();
        enemyScript = NPC.GetComponent<EnemyScript>();
    }
    void Update()
    {
        rttbool = rttgameObject.GetComponent<WTscript>().isTriggered;
        rbtbool = rbtgameObject.GetComponent<WTscript>().isTriggered;
        lttbool = lttgameObject.GetComponent<WTscript>().isTriggered;
        lbtbool = lbtgameObject.GetComponent<WTscript>().isTriggered;
        wt = NPC.GetComponent<EnemyScript>().walltouch;
        cg = NPC.GetComponent <EnemyScript>().cdgo;
        /*
        if ((rttbool == true || rbtbool == true || (rttbool == true && rbtbool == true)) || (lttbool == true || lbtbool == true || (lttbool == true && lbtbool == true)))
        {
            if (enemyScript.angle >= -90 && enemyScript.angle <= 90)
            {

                rb2d.linearVelocity = new Vector2(0, 1 * enemyScript.speed);
                NPC.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (enemyScript.angle <= 270 && enemyScript.angle > 90)
            {
                rb2d.linearVelocity = new Vector2(0, -1 * enemyScript.speed);
                NPC.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        */
        if( rttbool == true && lttbool == false && ver == false)
        {
            rb2d.linearVelocity = new Vector2(1 * enemyScript.speed, 0);
            NPC.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (rttbool == false && lttbool == true && ver == false)
        {
            rb2d.linearVelocity = new Vector2(-1 * enemyScript.speed, 0);
            NPC.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (rttbool == true && lttbool == true && ver == false)
        {
            if (enemyScript.angle >= -90 && enemyScript.angle < 90)
            {
                rb2d.linearVelocity = new Vector2(0, 1 * enemyScript.speed);
                NPC.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (enemyScript.angle < 90 && enemyScript.angle >= -90)
            {
                rb2d.linearVelocity = new Vector2(0, -1 * enemyScript.speed);
                NPC.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else if((rttbool == true && rbtbool == true) || (lttbool == true && lbtbool == true) && ver == false)
        {
            if(NPC.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                rb2d.linearVelocity = new Vector2(0, 1 * enemyScript.speed);
            }
            if (NPC.transform.rotation == Quaternion.Euler(0, 0, -90))
            {
                rb2d.linearVelocity = new Vector2(1 * enemyScript.speed, 0);
            }
            if (NPC.transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                rb2d.linearVelocity = new Vector2(0, 1 * enemyScript.speed);
            }
            if (NPC.transform.rotation == Quaternion.Euler(0, 0, 180))
            {
                rb2d.linearVelocity = new Vector2(0, -1 * enemyScript.speed);
            }
        }
        else if(wt == true)
        {
            if (NPC.transform.rotation == Quaternion.Euler(0, 0, 0) && NPC.transform.rotation == Quaternion.Euler(0, 0, -180))
            {
                if (enemyScript.angle >= 90 && enemyScript.angle < -90)
                {
                    rb2d.linearVelocity = new Vector2(0, -1 * enemyScript.speed);
                    NPC.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                else if (enemyScript.angle < 90 && enemyScript.angle >= -90)
                {
                    rb2d.linearVelocity = new Vector2(0, 1 * enemyScript.speed);
                    NPC.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
            ver = true;
            cg = true;
        }
        else if(wt == false)
        {
            StartCoroutine(CheckEuler());
        }
    }
    IEnumerator CheckEuler()
    {
        if (checkblock == false)
        {
            checkblock = true;
            yield return new WaitForSeconds(1);
            ver = false;
            cg = false;
            checkblock = false;
        }
    }
}
