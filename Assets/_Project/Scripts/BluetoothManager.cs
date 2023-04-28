using System;
using UnityEngine;

public class BluetoothManager : MonoBehaviour
{
    [SerializeField] private string deviceName;
    
    private static bool _isConnected;

    private void Start()
    {
        _isConnected = false;
        BluetoothService.CreateBluetoothObject();
        ConnectDevice(deviceName);

        Application.wantsToQuit += ApplicationOnwantsToQuit;
    }

    private void ConnectDevice(string device)
    {
        if (_isConnected) return;

        _isConnected = BluetoothService.StartBluetoothConnection(device);
        print($"Está conectado: {_isConnected}");
    }

    private void Update()
    {
        if (!_isConnected) return;

        try
        {
            string data = BluetoothService.ReadFromBluetooth();
            if (data.Length <= 1) return;
            
            print($"Data Received: {data}");

        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    
    public new static void SendMessage(string message)
    {
        if (_isConnected)
        {
            BluetoothService.WritetoBluetooth(message);
        }
    }

    private void StopConnection()
    {
        if (_isConnected)
        {
            BluetoothService.StopBluetoothConnection();
            _isConnected = false;
        }
    }

    private bool ApplicationOnwantsToQuit()
    {
        StopConnection();
        return true;
    }

    private void OnApplicationQuit()
    {
        StopConnection();
    }
}
