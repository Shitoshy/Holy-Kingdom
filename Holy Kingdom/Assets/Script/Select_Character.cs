using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Character : MonoBehaviour {
    /*
    public List<GameObject> characterList;
    public int index = 0;

	// Use this for initialization
	void Start () {
        GameObject[] characters = Resources.LoadAll<GameObject>("Prefab");
        foreach(GameObject c in characters)
        {
            GameObject _char = Instantiate(c) as GameObject;
            _char.transform.SetParent(GameObject.Find("CharacterList").transform);

            characterList.Add(_char);
            _char.SetActive(false);
            characterList(index).SetActive(true);
        }
		
	}
	
    public void Next()
    {
        characterList[index].SetActive(false);
        if (index == characterList.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        characterList[index].SetActive(true);
    }

    public void Previous()
    {
        characterList[index].SetActive(false);
        if (index == 0)
        {
            index = characterList.Count-1;
        }
        else
        {
            index--;
        }
        characterList[index].SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
    */
}
