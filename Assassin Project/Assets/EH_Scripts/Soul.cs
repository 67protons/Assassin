using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

	void Start () {
        Invoke("disappear", .9f);
	}

    void disappear()
    {
        Destroy(this.gameObject);
    }
}
