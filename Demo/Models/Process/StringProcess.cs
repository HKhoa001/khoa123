using System.Text.RegularExpressions;

namespace Demo.Models.Process
{
    public class StringProcess
    {
        public String AutoGenerateCode(string strInput)
        {
            string strResult = "", numPart = "", strPart = "";
            //tach phan so tu strInput
            numPart = Regex.Match(strInput, @"\d+").Value;
            //tach phan tu chu
            strPart = Regex.Match(strInput, @"\D+").Value;
            //tang phan so len 1 don vi
            int intPart = (Convert.ToInt32(numPart) + 1);
            //bo sung cac ky tu 0 con thieu
            for (int i = 0; i < numPart.Length - intPart.ToString().Length; i++)
            {
                strPart += "0";
            }
            strResult = strPart + intPart;
            return strResult;
        }

        internal dynamic AutoGenerateCode(int stdID)
        {
            throw new NotImplementedException();
        }
    }
}