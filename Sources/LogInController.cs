using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogInController : MonoBehaviour
{
    [SerializeField]
    TMP_Text[] input;
    
    [SerializeField]
    TMP_InputField password;
    DBLoader db;

    static public int Option=-1;
    void Start()
    {
        db=GameObject.FindObjectOfType<DBLoader>();
    }

    public void Update(){

        if(Option==0){ //없는 아이디일 시 회원가입 버튼 옆에 만들어야함.
                input[1].text="The ID does not exist...";
        }else if(Option==2){ //비밀번호가 틀릴 시
                input[1].text="Passwords do not match...";
        }else if(Option==1){  //맞는 아이디일 때
            SceneManager.LoadScene("MainHome");
        }
    }
    
    public void OnClick(){
        string id=input[0].text;
        string passwd=password.text;
        if(passwd==""){
            input[1].gameObject.SetActive(true);
            input[1].text="please fill out the form...";
        }
        else{
            StartCoroutine(db.GetUser(id,passwd));

            if(Option!=1){  //맞는 아이디가 아닐때
                input[1].gameObject.SetActive(true);
            }
        }
    }

    public void OnSignUpClick(){
        SceneManager.LoadScene("SignupHome");
    }
}
