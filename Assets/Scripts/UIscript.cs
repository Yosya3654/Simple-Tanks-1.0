using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public GameObject mapselect;
    public GameObject mainbuttons;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Arena1()
    {
        SceneManager.LoadScene(1);
    }
    public void Arena2()
    {
        SceneManager.LoadScene(2);
    }
    public void Arena3()
    {
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        mainbuttons.transform.localScale = Vector3.one;
        mapselect.transform.localScale = Vector3.zero;
    }
    public void Selectmap()
    {
        mainbuttons.transform.localScale = Vector3.zero;
        mapselect.transform.localScale = Vector3.one;
    }
}
