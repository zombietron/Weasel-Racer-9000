using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySelectedCarOnClick : MonoBehaviour
{
    [SerializeField] GameObject[] cars;

    public void Start()
    {
        swapCar(GameManager.Manager.CarChoice);
    }
    public void swapCar(int num)
    {
        GameManager.Manager.CarChoice = num;
        foreach(GameObject car in cars)
        {
            int id = car.GetComponent<VehicleIdentifier>().carNum;
            if (id == num)
            {
                car.SetActive(true);
            }
            else
                car.SetActive(false);
        }
    }
}
