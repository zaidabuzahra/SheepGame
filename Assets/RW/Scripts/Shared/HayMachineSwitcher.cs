using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    public GameObject BlueHayMachine;
    public GameObject YellowHayMachine;
    public GameObject RedHayMachine;


    private int SelectedIndex;
    public void OnPointerClick(PointerEventData eventData) 
    {
        SelectedIndex++; 
        SelectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length; 

        GameSettings.hayMachineColor = (HayMachineColor)SelectedIndex; 

        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                BlueHayMachine.SetActive(true);
                YellowHayMachine.SetActive(false);
                RedHayMachine.SetActive(false);
                break;

            case HayMachineColor.Yellow:
                BlueHayMachine.SetActive(false);
                YellowHayMachine.SetActive(true);
                RedHayMachine.SetActive(false);
                break;

            case HayMachineColor.Red:
                BlueHayMachine.SetActive(false);
                YellowHayMachine.SetActive(false);
                RedHayMachine.SetActive(true);
                break;
        }
    }
}
