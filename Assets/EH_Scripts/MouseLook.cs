using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
    float angle;
    Vector3 mousePos;
    LineRenderer aimLine;
    SpriteRenderer cursor;
    public Sprite meleeCursor;
    public Sprite rangeCursor;
	// Use this for initialization
	void Start () {        
        Cursor.visible = false;
        aimLine = this.transform.FindChild("Sight").GetComponent<LineRenderer>();
        cursor = this.transform.FindChild("Cursor").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - this.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    void FixedUpdate() {
        transform.rotation = Quaternion.AngleAxis(angle+90, new Vector3(0, 0, 1)); // Vector3.forward
        aimLine.SetPosition(0, this.transform.position);
        aimLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));
        setCursor();
        cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void setCursor()
    {
        switch (Player.style)
        {
            case 0:
                cursor.sprite = meleeCursor;
                break;
            case 1:
                cursor.sprite = rangeCursor;
                break;
        }
    }
}
