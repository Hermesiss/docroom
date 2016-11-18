using UnityEngine;
using System.Collections;

public class DisplaySwitch : MonoBehaviour {

    public float moveTime; //переменная для задания таймера анимации
    //public Material DispLitMat;
    public GameObject DisplayObj;

    private bool shelfDown;
    private float time;
    private GameObject currentText;
    private float ColorBr;
    private GameObject textPress;
    private GameObject textPress2;
    private GameObject textWait;
    private GameObject player;
    private float blinkColorOverTime;

    // Use this for initialization

    void Start()
    {
        textPress = transform.FindChild("textPress").gameObject;
        textPress2 = transform.FindChild("textPress2").gameObject;
        textWait = transform.FindChild("textWait").gameObject;

        DisplayObj.SetActive(false);

        player = GameObject.Find("FirstPersonCharacter");

        shelfDown = false;
        time = Time.time - moveTime;

        blinkColorOverTime = PlayerScript.ColorNear / PlayerScript.BlinkTime * 2;
    }



    // Update is called once per frame
    void Update()
    {
        Blink();
        HideText();
        if (Vector3.Distance(player.transform.position, this.transform.position) > PlayerScript.Distance) //объект дальше заданного радиуса
        {
            //ColorBr = 0.0F;
            currentText = null;
        }
        else// if (Vector3.Distance(player.transform.position, this.transform.position) < PlayerScript.Distance) //объект ближе
        {
            
            if (Time.time - time > moveTime)
            {
                currentText = null;
            }
        }
        ColoriseIt();

    }


    public void Move()
    {
        if (Time.time - time > moveTime)
        {
            currentText = textWait;
            time = Time.time;
            shelfDown = !shelfDown;
            /*float boolFloat = shelfDown ? 0 : 1.0F;
            DisplayObj.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(boolFloat, boolFloat, boolFloat, 1));
            boolFloat = shelfDown ? 0 : 0.4F;
            DisplayObj.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(boolFloat, boolFloat, boolFloat, 1));*/
            DisplayObj.SetActive(shelfDown);
        }
    }

   
    public void See()
    {
        
        if (Time.time - time > moveTime)
        {
            ColorBr = PlayerScript.ColorSee;
            if (shelfDown==false) currentText = textPress;
            else currentText = textPress2;
        }
        currentText.SetActive(true);
    }

    void Blink()
    {
        if (currentText == null)
        {
            if (Time.time - PlayerScript.BlinkTimer > PlayerScript.BlinkTime / 2)
            {
                ColorBr = PlayerScript.ColorNear - blinkColorOverTime * (Time.time - PlayerScript.BlinkTimer - PlayerScript.BlinkTime / 2);
            }
            else if (Time.time - PlayerScript.BlinkTimer < PlayerScript.BlinkTime / 2)
            {
                ColorBr = blinkColorOverTime * (Time.time - PlayerScript.BlinkTimer);
            }
        }
    }
    void ColoriseIt ()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(ColorBr, ColorBr, ColorBr, 1));
    }

    void HideText ()
    {

        if (currentText != textPress)
        {
            textPress.SetActive(false);
        }
        if (currentText != textPress2)
        {
            textPress2.SetActive(false);
        }
        if (currentText != textWait)
        {
            textWait.SetActive(false);
        }
    }
}
