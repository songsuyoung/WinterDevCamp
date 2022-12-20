using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SignUpController : MonoBehaviour
{

    string id;
    string passwd;
    string Conformpasswd;
    string email;
    
    [SerializeField]
    TMP_Text[] input;

    [SerializeField]
    TMP_InputField[] inputfield;

    // Start is called before the first frame update
    DBLoader db;
    bool isSuccess=false;

    static public bool isFailed=false;
    void Start()
    {
        db=GameObject.FindObjectOfType<DBLoader>();
    }

    public void OnClick(){
        passwd=inputfield[0].text;
        Conformpasswd=inputfield[1].text;

        Debug.Log(passwd);
        if(passwd.CompareTo(Conformpasswd)!=0){
            input[2].gameObject.SetActive(true);
        }else{
            input[2].text="Please click the login button...";
            isSuccess=true;
            id=input[0].text;
            email=input[1].text;
            StartCoroutine(db.SetUser(id,passwd,email));

            if(isFailed){
                input[2].text="This username is already in use....";
            }else{
                input[2].text="Success....";
                SceneManager.LoadScene("SigninHome");
            }
        }
    }

    public void OnLoginButClick(){
        if(!isFailed){
            SceneManager.LoadScene("SigninHome");
        }else{
            input[2].text="please fill out the form...";
        }
    }
}
