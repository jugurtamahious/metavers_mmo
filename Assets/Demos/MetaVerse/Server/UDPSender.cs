using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPSender : MonoBehaviour
{
    public string serverIP = "127.0.0.1"; // Adresse IP du destinataire
    public int serverPort = 25001;       // Port du destinataire

    private UdpClient udpClient;

    private void Start()
    {
        udpClient = new UdpClient();
        Debug.Log("UDP Sender initialisé");
    }

    public void SendData(string message)
    {
        try
        {
            // Conversion des data en bytes
            byte[] data = Encoding.UTF8.GetBytes(message);

            // Envoi des données
            udpClient.Send(data, data.Length, serverIP, serverPort);

            Debug.Log(serverIP + " " + serverPort);
            // Debug.Log($"Data envoyé: {message}");
        }
        catch (SocketException ex)
        {
            Debug.LogError($"UDP send error: {ex.Message}");
        }
    }

    private void OnApplicationQuit()
    {
        // Fermeture du client UDP
        udpClient?.Close();
    }
}