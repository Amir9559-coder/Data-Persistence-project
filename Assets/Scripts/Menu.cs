using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Menu : MonoBehaviour
{
    [SerializeField] Text nameInput;
    public string nameInputTX;
    public string bestScoreName;
    public int bestScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreName = GetComponent<Text>().text;
        bestScore = 0;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string bestScoreName;
        public int bestScore;
    }

    public void SaveText()
    {
        SaveData data = new SaveData();
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }
    public void LoadText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;
        }
        else
        {
            bestScore = 0;
            bestScoreName = nameInputTX;
        }
    }
    public void StartButton()
    {
        nameInputTX = nameInput.text;
        LoadText();
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
