using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VDC
{
    public class EncryptText
    {
        public static void Main(String FileName, string text)
        {
            text = text.Replace("\r", "");
            int counta = 0;
            byte[] b = new byte[text.Length + 123];
            string signature = Properties.Settings.Default.datfilesignature.Replace("\r\n", " ").PadRight(123);
            for (int i = 0; i < signature.Length; i++)
                b[i] = (byte)signature[i];
            for (int i = 123; i < b.Length; i++)
            {
                b[i] = EncryptByte(counta, (byte)text[i - 123]);
                counta++;
                if (counta > 36)
                    counta = 0;
            }
            FileStream finp = new FileStream(FileName, FileMode.Create);
            finp.Write(b, 0, b.Length);
            finp.Close();
        }

        public static byte EncryptByte(int counta, byte b)
        {
            String plainEncryptionKey = "odBearBecauseHeIsVeryGoodSiuHungIsAGo";
            b += (byte)plainEncryptionKey[counta];
            return b;
        }
    }

    //by Someone else
    public class DecryptFile
    {
        public static string Main(String FileName)
        {
            string text = "";
            FileStream finp = new FileStream(FileName, FileMode.Open);
            int counta = 0;
            int b;
            finp.Seek(123, SeekOrigin.Begin);
            while ((b = finp.ReadByte()) != -1)
            {
                text += (char)DecryptByte(counta, (byte)b);
                counta++;
                if (counta > 36)
                    counta = 0;
            }
            finp.Close();
            return text;
        }

        public static byte DecryptByte(int counta, byte b)
        {
            String plainEncryptionKey = "odBearBecauseHeIsVeryGoodSiuHungIsAGo";
            b -= (byte)plainEncryptionKey[counta];
            return b;
        }
    }
}