using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Selet : MonoBehaviour
{
    public GameObject creat;
    public GameObject creatBk;
    public Text[] slotText;
    public Text newPlayerName;

    bool[] saveFile = new bool[3];

    void Start()
    {
     for(int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.instance.path + $"{i}"))
            {
                saveFile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name;
            }
            else
            {
                slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();
    }

  public  void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        if(saveFile[number])
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else
        {
            Creat();
        }
    }

    public void Creat()	
    {
        creat.gameObject.SetActive(true);
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        if (!saveFile[DataManager.instance.nowSlot])	
        {
            DataManager.instance.nowPlayer.name = newPlayerName.text; 
            DataManager.instance.SaveData(); 
        }
        SceneManager.LoadScene(1);
    }
}
