using UnityEngine;

public class WTscript : MonoBehaviour
{
    public bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTriggered = true;
        }
        else if(collision is null || collision.gameObject.tag != "Wall")
        {
            isTriggered = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTriggered = false;
        }
    }
}
