using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorLines : MonoBehaviour {

    public GameObject pontoX;
    public GameObject pontoY;
    public Vector2 coord = new Vector2(9999,9999);
    public float lineSpeed = 1f;

    private Vector2 original;

    // Use this for initialization
    void Start () {
        original = coord;
	}
	
	// Update is called once per frame
	void Update () {
        DrawLine(pontoX);
        DrawLine(pontoY);

        if (coord != original)
        {
            if (coord.x < 0)
            {
                Debug.Log("x<0");
                if (pontoX.transform.position.x >= coord.x)
                    pontoX.transform.Translate(new Vector3(coord.x, 0, 0) * Time.deltaTime * lineSpeed);
            }
            else if (coord.x > 0)
            {
                Debug.Log("x>0");
                if (pontoX.transform.position.x <= coord.x)
                    pontoX.transform.Translate(new Vector3(coord.x, 0, 0) * Time.deltaTime * lineSpeed);
            }
            if (coord.y < 0)
            {
                Debug.Log("y");
                if (pontoY.transform.position.y >= coord.y)
                    pontoY.transform.Translate(new Vector3(0, coord.y, 0) * Time.deltaTime * lineSpeed);
            }
            else if (coord.y > 0)
            {
                if (pontoY.transform.position.y <= coord.y)
                    pontoY.transform.Translate(new Vector3(0, coord.y, 0) * Time.deltaTime * lineSpeed);
            }

        }



	}
    private void DrawLine(GameObject ponto)
    {
        var go = ponto;
        var lr = ponto.GetComponent<LineRenderer>();

        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, go.transform.position);
    }
}
