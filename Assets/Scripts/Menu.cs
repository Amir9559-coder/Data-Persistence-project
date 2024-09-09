using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{
    [SerializeField] Text nameInput;
    //What player will type is name text.
    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        StoreText();
    }
    public string StoreText()
    {
        nameText.text = nameInput.text;
        return nameText.text;
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
