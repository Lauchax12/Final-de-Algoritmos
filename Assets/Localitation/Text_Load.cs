using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Text_Load : MonoBehaviour
{
    public static string ReadText(string doc = "English")
    {
        //creamos el path osea la ubicacion del archivo
        string path = Application.persistentDataPath + "/" + doc + ".txt";
        StreamReader reader = new StreamReader(path);
        string txt = reader.ReadToEnd();
        return txt;


    }
}
