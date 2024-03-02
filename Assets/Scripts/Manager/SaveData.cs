using TMPro;
using System.IO;
using UnityEngine;

[SerializeField ]
public class Data
{
    public string _name;
    public int _puntaje;
}
public class SaveData : MonoBehaviour
{
    public TMP_Text _nametxt, _puntajetxt;
    private string dataFilePath = "Assets/DataJSON.json";
   

    public void SaveDataToJson()
    {
        Data data = new Data();
        data._name = ControladorPuntuacion.Instance.name;
        data._puntaje = ControladorPuntuacion.Instance._puntuacion;
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(dataFilePath, jsonData);
    }
    public void LoadDataFrom()
    {
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            Data data = JsonUtility.FromJson<Data>(jsonData);
            _nametxt.text = "" + data._name;
            _puntajetxt.text = "" + data._puntaje;
        }
    }
}

