using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    private int framecnt=0;
    private int framecntend;
    private int scjudge=1;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = this.gameObject.transform.position;
        int xn = Random.Range(-20,20);
        int yn = Random.Range(-20,20);
		this.gameObject.transform.position = new Vector3 (pos.x + xn, pos.y, pos.z + yn);
    }

    // Update is called once per frame
    void Update()
    {
        if(framecnt==0){
            framecntend=60*Random.Range(1,4);
        }

        if(framecnt==framecntend){
            framecnt=0;
            scjudge*=-1;
            Debug.Log("change");
        }

        if(scjudge==1){
            transform.position += transform.forward * 0.025f;
            Debug.Log("strate");
        }else{
            transform.Rotate(0,1,0);
            Debug.Log("turn");
        }

        framecnt++;
    }

}
