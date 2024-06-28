using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class LogRoom : MonoBehaviour
{
    [SerializeField]
    UIDocument mainMenu;
    [SerializeField]
    VisualTreeAsset elementListe;
    [SerializeField]
    GameObject uiDocument;

    VisualElement root;
    VisualElement uiBackground;
    Button button;
    ListView list;

    List<int> items = new List<int>();

    private float validateSlide;
    private float easeTimeSeconds = 1.2f;

    private void Awake()
    {
        root = mainMenu.rootVisualElement;
        uiBackground = root.Q<VisualElement>("uibackground");
        button = root.Q<Button>("Ajouter");
        list = root.Q<ListView>("liste");

        button.clicked += ButtonClicked;
    }

    private void Start()
    {
        DOTween.To(() => validateSlide, x => validateSlide = x, 10, easeTimeSeconds).SetEase(Ease.OutBounce);
    }

    void Update()
    {
        uiBackground.style.top = Length.Percent(10 + validateSlide);
    }

    //crée une list de nouveau joueur quand on clique sur le bouton
    void ButtonClicked()
    {
        items.Add(items.Count);

        list.Clear();

        list.makeItem = () => elementListe.CloneTree();
        list.itemsSource = items;
        list.bindItem = (root, i) => root.Q<Label>().text = i.ToString() + "NewPlayer";
        list.itemHeight = 60;
        list.selectionType = SelectionType.None;
        list.Rebuild();
    }
}
