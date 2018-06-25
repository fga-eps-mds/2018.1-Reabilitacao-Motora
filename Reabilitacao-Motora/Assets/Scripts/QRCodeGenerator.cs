using ZXing;
using ZXing.QrCode;
using UnityEngine;
using UnityEngine.UI;

public class QRCodeGenerator : MonoBehaviour
{

    [SerializeField]
    Text screenInfo;
    
    string text;
    protected Texture2D myQR;

    private static Color32[] Encode(string textForEncoding, int width, int height) {
        var writer = new BarcodeWriter {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions {
            Height = height,
            Width = width
            }
        };

        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text) {
        var encoded = new Texture2D (256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    public void OnGUI(){
        
        if (GlobalController.showQrCode == true && screenInfo.text != "")
        {
            myQR = generateQR(screenInfo.text);
            int w = Screen.width;
            int h = Screen.height;
            if (GUI.Button(new Rect(w / 3.25f, h / 1.35f, w / 8, w / 8), myQR, GUIStyle.none)) { }
        }
        
    }
}