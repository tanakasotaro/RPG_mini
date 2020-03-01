using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_move : MonoBehaviour
{

    public int moveflag = 0;
    public Text texts;
    public GameObject panels;
    public GameObject player;
    public GameObject king;
    public GameObject In1; 
    public GameObject In2; 
    public GameObject Out;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn()；
    }

    // Update is called once per frame
    void Update()
    {
        if(moveflag==0){
            if(Input.GetKey("up")){
                transform.position += transform.forward * 0.2f;
            }

            if(Input.GetKey("down")){
                transform.position -= transform.forward * 0.2f;
            }

            if(Input.GetKey("right")){
                transform.Rotate(0,5,0);
            }

            if(Input.GetKey("left")){
                transform.Rotate(0,-5,0);
            }
            panels.SetActive(false);
            texts.enabled=false;
        }else{
            if(moveflag==1){
                texts.text="部屋に入りますか？";
                panels.SetActive(true);
                texts.enabled=true;
                if(Input.GetKey(KeyCode.Y)){
                    SceneManager.LoadScene("KingScene");
                }

                if(Input.GetKey(KeyCode.N)){
                    moveflag=0;
                }

            }

            if(moveflag==2){
                texts.text="外の敵を3体倒してボスに向かえ";
                panels.SetActive(true);
                texts.enabled=true;
                if(Input.GetKey(KeyCode.Y)){
                    moveflag=0;
                }

            }

            if(moveflag==3){
                texts.text="外に出ますか?";
                panels.SetActive(true);
                texts.enabled=true;
                if(Input.GetKey(KeyCode.Y)){
                    SceneManager.LoadScene("SampleScene");
                }
                if(Input.GetKey(KeyCode.N)){
                    moveflag=0;
                }

            }

        }
        
    }

    void OnCollisionEnter(Collision obj){
        if(obj.gameObject.tag=="in"){
            moveflag=1;
        }

        if(obj.gameObject.tag=="king"){
            moveflag=2;
        }

        if(obj.gameObject.tag=="out"){
            moveflag=3;
        }

        if(obj.gameObject.tag=="enemy"){
            //moveflag=4;
            SceneManager.LoadScene("BattleScene");
        }

    }
}
