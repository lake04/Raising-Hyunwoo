using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text name;
    public Text level;
    public Text coin;
    public GameObject[] item;
  
    void Start()
    {
        name.text += DataManager.instance.nowPlayer.name;
        level.text += DataManager.instance.nowPlayer.level.ToString();
        coin.text += DataManager.instance.nowPlayer.coin.ToString();
        ItemSetting(DataManager.instance.nowPlayer.item);
        
    }

    private void Update()
    {

        CoinUp();
    }
    public void LevelUp()
    {
       
        DataManager.instance.nowPlayer.level++;
        if (DataManager.instance.nowPlayer.level >= DataManager.instance.nowPlayer.leveled)
        {
            DataManager.instance.nowPlayer.level = 0;
            DataManager.instance.nowPlayer.leveled += 5;
            level.text = "레벨 :" + DataManager.instance.nowPlayer.level.ToString() + "/" + DataManager.instance.nowPlayer.leveled.ToString();
            CoinUp();
        }
        level.text = "레벨 :"+DataManager.instance.nowPlayer.level.ToString() + "/"+DataManager.instance.nowPlayer.leveled.ToString();      
    }

    public void CoinUp()
    {
        DataManager.instance.nowPlayer.coin+= 100 * Time.deltaTime;
        coin.text = "코인 :" + DataManager.instance.nowPlayer.coin.ToString();

    }

    public void Save()
    {
        DataManager.instance.SaveData();
        SceneManager.LoadScene(0);
    }

    public void ItemSetting(int number)
    {
        for(int i=0; i<item.Length;i++)
        {
            if(number == 1)
            {
                item[i].SetActive(true);
                DataManager.instance.nowPlayer.item = number;
            }
            else
            {
                item[i].SetActive(false);
            }
        }
    }
}
