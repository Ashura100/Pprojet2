using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UITest
{
    // A Test behaves as an ordinary method
    [Test]
    public void UITestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UITestDocunmentExist()
    {
        SceneManager.LoadScene(0);
        yield return null;
        GameObject go = GameObject.Find("UIDocument");
        UIDocument uIDocument = go.GetComponent<UIDocument>();
        Assert.IsNotNull(uIDocument);
    }

    [UnityTest]
    public IEnumerator UITestButtonExist()
    {
        SceneManager.LoadScene(0);
        yield return null;
        GameObject go = GameObject.Find("UIDocument");
        UIDocument uIDocument = go.GetComponent<UIDocument>();
        Button button = uIDocument.rootVisualElement.Q<Button>("Button");
        Assert.IsNotEmpty(button.text);
    }
}
