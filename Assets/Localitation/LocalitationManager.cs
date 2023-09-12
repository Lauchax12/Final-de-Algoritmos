using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocalitationManager : MonoBehaviour
{
    public static LocalitationManager instance;
    private void Awake()
    {
        instance = this;
    }

    const string Spanish = "Spanish";
    const string English = "English";

    string actuallang = "";


    private void Start()
    {
        database.Add(Spanish, new Dictionary<string, string>());
        database.Add(English, new Dictionary<string, string>());
        actuallang = Spanish;
        Streamlanguage(actuallang);
    }

    Dictionary<string, Dictionary<string, string>> database = new Dictionary<string, Dictionary<string, string>>();

    void Streamlanguage(string lang)
    {
        //pisa el lenguaje
        actuallang = lang;
        //carga el texto
        LoadText();
    }

    public string GetText(string key)
    {
        return database[actuallang][key];
    }

    public void LoadText()
    {
        //esto m devuelve el documento text load
        string text = Text_Load.ReadText(actuallang);

        //aca empieza el tratamiento

        //separo entre renglones "Enters ('\n')"
        string[] rows = text.Split('\n');

        //recorro todos los renglones
        for (int i = 0; i < rows.Length; i++)
        {
            //separo entre comas ","
            string[] keyval = rows[i].Split(',');
            //obtengo el key
            string code = keyval[0];
            //obtengo el valor
            string val = keyval[1];


            if (!database[actuallang].ContainsKey(code))
            {
                //si no tenia la key lo añadia en ese lenguaje, en esa key, ese valor
                database[actuallang].Add(code, val);
            }
            else
            {
                //en caso de que si ya tenia esa key, lo actualizaria
                database[actuallang][code] = val;
            }


        }


    }

    public bool swichtlang = true;
    //cambio el idioma
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            swichtlang = !swichtlang;
            Streamlanguage(swichtlang ? English : Spanish);
        }


    }

}
