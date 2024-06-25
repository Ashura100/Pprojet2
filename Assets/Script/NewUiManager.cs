using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class NewUiManager : MonoBehaviour
{
    [SerializeField]
    UIDocument mainMenu;
    [SerializeField]
    VisualTreeAsset elementListe;

    VisualElement root;
    Button button;
    ListView list;

    List<int> items = new List<int>();

    private void Awake()
    {
        root = mainMenu.rootVisualElement;
        button = root.Q<Button>("Ajouter");
        list = root.Q<ListView>("liste");

        button.clicked += ButtonClicked;
    }

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
