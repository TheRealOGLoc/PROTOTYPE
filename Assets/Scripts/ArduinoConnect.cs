using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoConnect : MonoBehaviour
{
    public SerialPort serialPort;
    private string dataFlow;
    private string[] dataSet;
    private int? xRaw = null;
    private int? yRaw = null;
    private int? zRaw = null;

    // Start is called before the first frame update
    void Start()
    {
        serialPort = new SerialPort("COM3", 9600);
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        GetCoordinate();
        //Debug.Log(ConvertYCoordinate());
    }

    void GetCoordinate() //change to IEmu?
    {
        if (serialPort.IsOpen)
        {
            dataFlow = serialPort.ReadLine();
            Debug.Log(dataFlow);
            dataSet = dataFlow.Split(' ');
            if (dataSet.Length == 3 && dataSet[0].Length < 4)
            {
                for (int i = 0; i < dataSet.Length; i++)
                {
                    if (i == 0)
                    {
                        xRaw = int.Parse(dataSet[i]);
                    }
                    else if (i == 1)
                    {
                        yRaw = int.Parse(dataSet[i]);
                    }
                    else if (i == 2)
                    {
                        zRaw = int.Parse(dataSet[i]);
                    }
                }
            }
        }
    }

    public float ConvertYCoordinate()
    {
        if (yRaw == null)
        {
            return 0.0f;
        }
        else if (yRaw > 153)
        {
            return 1.0f;
        }
        else if (yRaw < 103)
        {
            return -1.0f;
        }
        else
        {
            return ((float)(yRaw - 128) / 25.0f);
        }
    }
}
