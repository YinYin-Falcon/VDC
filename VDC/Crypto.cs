using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VDC
{
    //Programmed by Someone else

    public class DecryptFile
    {
        public static string Main(String FileName)
        {
            string text = "";
            try
            {
                FileStream finp = new FileStream(FileName, FileMode.Open);
                int counta = 0;
                int b;
                byte d;
                finp.Seek(123, SeekOrigin.Begin);
                while ((b = finp.ReadByte()) != -1)
                {
                    d = DecryptByte(counta, (byte)b);
                    counta++;
                    if (counta > 36)
                    {
                        counta = 0;
                    }
                    text += (char)d;
                }
                finp.Close();
            }
            catch { }
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