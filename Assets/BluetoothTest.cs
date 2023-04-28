using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BluetoothTest : MonoBehaviour
{
    public Text deviceName;
    public Text dataToSend;
    private bool IsConnected;
    public static string dataRecived = "";
    
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        IsConnected = false;
        BluetoothService.CreateBluetoothObject();

        yield return new WaitForSeconds(3);
        
        StartButton();

        yield return new WaitForSeconds(3);
        
        SendButton("A");
        
        yield return new WaitForSeconds(3);
        
        SendButton("E");
        
        yield return new WaitForSeconds(3);
        
        StopButton();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsConnected) return;
        
        try
        {
            string datain = BluetoothService.ReadFromBluetooth();
            if (datain.Length > 1)
            {
                dataRecived = datain;
                print($"Data Received: {dataRecived}");
            }

        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void StartButton()
    {
        if (IsConnected) return;
        
        IsConnected = BluetoothService.StartBluetoothConnection("LigaBot");
        print($"Está conectado: {IsConnected}");
    }

    public void SendButton(string message)
    {
        if (IsConnected)
        {
            BluetoothService.WritetoBluetooth(message);
        }
    }

    public void StopButton()
    {
        if (IsConnected)
        {
            BluetoothService.StopBluetoothConnection();
        }
    }
}
