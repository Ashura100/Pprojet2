using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    UIDocument uIDocument;

    VisualElement root;
    TextField email;
    TextField password;
    TextField emailPop;
    TextField passPop;
    Button button;

    private float validateSlide;
    private float easeTimeSeconds = 1.2f;

    // Start is called before the first frame update
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        email = root.Q<TextField>("EmailText");
        emailPop = root.Q<TextField>("MailPop");
        password = root.Q<TextField>("PassText");
        passPop = root.Q<TextField>("PassPop");
        button = root.Q<Button>("Login");

        button.clicked += Clickable_clicked;
    }

    void Update()
    {
        root.style.top = Length.Percent(10 + validateSlide);
    }

    private void Clickable_clicked()
    {
        Login();
        Debug.Log("click");
    }

    public void Login()
    {
        string _email = email.text;
        string _password = password.text;

        if(_email == "homelander@aol.com" && _password == "john1972")
        {
            DOTween.To(() => validateSlide, x => validateSlide = x, -110, easeTimeSeconds).SetEase(Ease.OutBounce);
            emailPop.value = "Welcome";
            email.style.color = Color.green;
            passPop.value = null;
        }
        else if(_email == "Enter text..." && _password == "Enter text...")
        {
            emailPop.value = "Write mail";
            emailPop.style.color = Color.white;
            passPop.value = "Witre password";
            passPop.style.color = Color.white;
        }
        else
        {
            emailPop.value = "Wrong mail or not reconized";
            emailPop.style.color = Color.red;
            passPop.value = "Wrong password, try again";
            passPop.style.color = Color.red;
        }
    }
}
