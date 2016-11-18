using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public static float Distance = 2.5f;
    public Texture2D crosshairImage;
    public static float ColorNear = 0.15F;
    public static float ColorSee = 0.2F;
    public static float BlinkTime = 3F;
    public static float BlinkTimer;


    private Ray ray;
    private RaycastHit hit;
    private GameObject currentUsable;

    // Use this for initialization
    void Start () {

        BlinkTimer = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        RayCast();
        LockCursor();

        if (Time.time - BlinkTimer > PlayerScript.BlinkTime)
        {
            BlinkTimer = Time.time;
            //ColorBr = PlayerScript.ColorNear;
        }
    }

    void RayCast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * Distance, Color.red);
        if (Physics.Raycast(ray, out hit, Distance))
        {
            currentUsable = hit.collider.gameObject;
            if (hit.collider.tag == "usable")
            {
                currentUsable.SendMessage("See");
                if (Input.GetKeyDown("e"))
                {
                    currentUsable.SendMessage("Move");
                }
            }
        }
    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }

    void LockCursor ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

