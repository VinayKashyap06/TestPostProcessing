using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaController : MonoBehaviour
{

    [SerializeField]
    private GameObject teleportObject;

    [SerializeField]
    private GameObject animateObject;

    private GameObject pointA;
    private GameObject pointB;

    private Vector3 currentPos;
    private Vector3 pointAPos;
    private Vector3 pointBPos;
    private bool isPlaying;

    
    void Start()
    {
        if(teleportObject==null)
            teleportObject = GameObject.Find("TeleportObject");
        currentPos = teleportObject.transform.localPosition;

        if(animateObject==null)
            animateObject = GameObject.Find("AnimateObj");

        pointA = GameObject.Find("PointA");
        pointAPos = pointA.transform.localPosition;

        pointB = GameObject.Find("PointB");
        pointBPos = pointB.transform.localPosition;

        isPlaying = true;

    }

    public void OnTeleportButtonPressed()
    {
        if (currentPos == pointAPos)
        {
            teleportObject.transform.localPosition = pointBPos;
            currentPos = pointBPos;
        }
        else
        {
            teleportObject.transform.localPosition = pointAPos;
            currentPos = pointAPos;
        }

    }

    public void OnAnimateButtonPressed()
    {
        isPlaying = !isPlaying;

        if (!isPlaying)
            animateObject.GetComponent<Animation>().Play();
        else
            animateObject.GetComponent<Animation>().Stop();

    }
    public void OnReturnButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
