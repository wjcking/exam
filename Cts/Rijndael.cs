using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cts
{
    /**//// <summary>
    /// Rijndael
    /// </summary>
    public class Rijndael
    {

        private RijndaelManaged myRijndael;
        public string Key;
        public string IV;
        /**//// <summary>
        /// 对称加密类的构造函数
        /// </summary>
        public Rijndael(string key)
        {
            myRijndael = new RijndaelManaged();
            Key = key;
            IV="67^%*(&(*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
        }
        /**//// <summary>
        /// 对称加密类的构造函数
        /// </summary>
        public Rijndael(string key, string iv)
        {
            myRijndael = new RijndaelManaged();
            Key = key;
            IV = iv;
        }
        /**//// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey()
        {
            string sTemp = Key;
            myRijndael.GenerateKey();
            byte[] bytTemp = myRijndael.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /**//// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV()
        {
            string sTemp = IV;
            myRijndael.GenerateIV();
            byte[] bytTemp = myRijndael.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /**//// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public string Encrypt(string Source)
        {
            try
            {
                byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
                MemoryStream ms = new MemoryStream();
                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();
                ICryptoTransform encrypto = myRijndael.CreateEncryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();
                ms.Close();
                byte[] bytOut = ms.ToArray();
                return Convert.ToBase64String(bytOut);
            }
            catch (Exception ex)
            {
                //throw new Exception("在文件加密的时候出现错误！错误提示： \n" + ex.Message);
                throw ex;
            }
        }
        /**//// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public string Decrypt(string Source)
        {
            try
            {
                byte[] bytIn = Convert.FromBase64String(Source);
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();
                ICryptoTransform encrypto = myRijndael.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                //throw new Exception("解密出现错误！提示：\n \n" + ex.Message);
                throw ex;
            }
        }
        /**//// <summary>
        /// 加密方法byte[] to byte[]
        /// </summary>
        /// <param name="Source">待加密的byte数组</param>
        /// <returns>经过加密的byte数组</returns>
        public byte[] Encrypt(byte[] Source)
        {
            try
            {
                byte[] bytIn = Source;
                MemoryStream ms = new MemoryStream();
                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();
                ICryptoTransform encrypto = myRijndael.CreateEncryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();
                ms.Close();
                byte[] bytOut = ms.ToArray();
                return bytOut;
            }
            catch (Exception ex)
            {
                throw new Exception("在文件加密的时候出现错误！错误提示： \n" + ex.Message);
            }
        }
        /**//// <summary>
        /// 解密方法byte[] to byte[]
        /// </summary>
        /// <param name="Source">待解密的byte数组</param>
        /// <returns>经过解密的byte数组</returns>
        public byte[] Decrypt(byte[] Source)
        {
            try
            {
                byte[] bytIn = Source;
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();
                ICryptoTransform encrypto = myRijndael.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return UTF8Encoding.UTF8.GetBytes(sr.ReadToEnd());
            }
            catch (Exception ex)
            {
                throw new Exception("在文件解密的时候出现错误！错误提示： \n" + ex.Message);
            }
        }


        /**//// <summary>
        /// 加密方法File to File
        /// </summary>
        /// <param name="inFileName">待加密文件的路径</param>
        /// <param name="outFileName">待加密后文件的输出路径</param>
       
        public void Encrypt(string inFileName, string outFileName)
        {
            try
            {
                //byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
                //MemoryStream ms = new MemoryStream();

                FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();

                byte[] bin = new byte[100]; 
                long rdlen = 0;              
                long totlen = fin.Length;   
                int len;                     

                ICryptoTransform encrypto = myRijndael.CreateEncryptor();
                CryptoStream cs = new CryptoStream(fout, encrypto, CryptoStreamMode.Write);
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    cs.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                cs.Close();
                fout.Close();
                fin.Close();    

            }
            catch (Exception ex)
            {
                throw new Exception("在文件加密的时候出现错误！错误提示： \n" + ex.Message);
            }
        }
        /**//// <summary>
        /// 解密方法File to File
        /// </summary>
        /// <param name="inFileName">待解密文件的路径</param>
        /// <param name="outFileName">待解密后文件的输出路径</param>
        public string Decrypt(string inFileName, string outFileName)
        {
            FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            CryptoStream cs = null;

            try
            {
                fout.SetLength(0);

                byte[] bin = new byte[100];
                long rdlen = 0;
                long totlen = fin.Length;
                int len;
                myRijndael.Key = GetLegalKey();
                myRijndael.IV = GetLegalIV();
                ICryptoTransform encrypto = myRijndael.CreateDecryptor();
                cs = new CryptoStream(fout, encrypto, CryptoStreamMode.Write);

                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    cs.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }

                cs.Close();
                fout.Close();
                fin.Close();
                
                return string.Empty;
            }
            catch (Exception ex)
            {

                cs.Close();
                fout.Close();
                fin.Close();
                return ex.Message;           
            }
        }

    }
}