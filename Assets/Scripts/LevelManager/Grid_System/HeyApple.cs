using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeyApple : MonoBehaviour
{
    [SerializeField] private string Anchor;

    public void RealignApple()
    {
	GameObject AnchorTile = GameObject.Find(Anchor);
	if (AnchorTile != null)
	{
	    GetComponent<Transform>().position = AnchorTile.GetComponent<Transform>().position;
	}else
	{
	    Debug.Log("Couldn't find tile " + Anchor);
	}
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	RealignApple();        
	Destroy(GetComponent<HeyApple>());
    }
}
