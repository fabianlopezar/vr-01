using TMPro;
using System.IO;
using UnityEngine;

[SerializeField ]
public class Data
{
    public string _name;
    public int puntaje;
}
public class SaveData : MonoBehaviour
{
    public TMP_Text _nametxt, _puntajetxt;
    private string dataFilePath = "Assets/DataJSON.json";
   
}

