using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement3D : MonoBehaviour {

    float speed;
  
    float moveVertical, moveHorizontal;
    float speedH = 2.0f;

    private float pitch;
   


    void Start ()
    {
        speed = 10f;
	}
	
	void FixedUpdate ()
    {
        moveHorizontal=Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
       
        pitch += speedH * Input.GetAxis("Mouse X");
        
        transform.eulerAngles = new Vector3(0,pitch,0);
        transform.Translate(moveHorizontal, 0, moveVertical);
       

	}

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
    }
}
