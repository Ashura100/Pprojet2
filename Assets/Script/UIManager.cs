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
    [SerializeField]
    GameObject uiDocument1;
    [SerializeField]
    GameObject uiDocument2;

    VisualElement root;
    VisualElement uiBackground;
    TextField email;
    TextField password;
    TextField emailPop;
    TextField passPop;
    Button button;

    private float validateSlide;
    private float easeTimeSeconds = 1.2f;

    //activation des éléments de l'ui
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        uiBackground = root.Q<VisualElement>("UiBackground");
        email = root.Q<TextField>("EmailText");
        emailPop = root.Q<TextField>("MailPop");
        password = root.Q<TextField>("PassText");
        passPop = root.Q<TextField>("PassPop");
        button = root.Q<Button>("Login");

        button.clicked += Clickable_clicked;
    }

    void Update()
    {
        uiBackground.style.top = Length.Percent(10 + validateSlide);
    }

    //fait appel à la fonction login quand on clique sur le bouton
    private void Clickable_clicked()
    {   
        Debug.Log("click");
        Login();
    }

    //prend en compte les mails et mot de passe écrit et si ils correspondent au condition pour se connecter avec des messages d'érreurs
    //et une animation dotween pour faire disparaitre l'interface si le mail et le mot de passe sont bon
    public void Login()
    {
        string _email = email.text;
        string _password = password.text;

        if(_email == "homelander@aol.com" && _password == "john1972")
        {
            DOTween.To(() => validateSlide, x => validateSlide = x, -110, easeTimeSeconds).SetEase(Ease.OutBounce).OnComplete(()=> { uiDocument1.SetActive(false); uiDocument2.SetActive(true); });
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
