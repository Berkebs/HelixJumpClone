using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    public List<GameObject> parts;

    [SerializeField]
    private GameObject failPlacePrefab;
    public void PrepareSimple(int nonActiveAmount,int failPlaceAmount)
    {


        int index=Random.Range(0,parts.Count);// non 4 index 3
        for (int i = 0; i < nonActiveAmount; i++)
        {
            GameObject item = parts[index];
            item.SetActive(false);
            index++;
            if (index>=parts.Count)
            {
                index = 0;
            }
        }
        for (int i = 0; i < failPlaceAmount; i++)
        {

            int indexf = Random.Range(0, parts.Count);

            if (!parts[indexf].activeInHierarchy)
            {
                i--;
                return;
            }

            GameObject item = parts[indexf];
            Quaternion itemTransform=item.transform.rotation;
            item.SetActive(false);
            GameObject t = Instantiate(failPlacePrefab,this.gameObject.transform);
            t.transform.rotation= itemTransform;
            
        }
    }

    public void PassedPlace() 
    {
        this.gameObject.SetActive(false);
    }
}
