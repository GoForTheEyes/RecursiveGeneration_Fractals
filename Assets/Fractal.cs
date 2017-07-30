using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {


    public Mesh mesh;
    public Material material;

    public int maxDepth;
    [Tooltip("size reduction from one fractal to its childs")]
    public float childScale;

    private int depth=0; //levels from initial fractal


	// Use this for initialization
	void Start () {
        //add a meshfilter and rendered to the object
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth<maxDepth)
        {
            new GameObject("Fractal Child").
                AddComponent<Fractal>().Initialize(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Initialize (Fractal parent)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        //local scale so it is 1/2 of its parent size
        transform.localScale = Vector3.one * childScale;
        //parent local size is 1, we then move another 1/2 of the new child
        //(because anchor is at the middle)
        transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);


    }

}
