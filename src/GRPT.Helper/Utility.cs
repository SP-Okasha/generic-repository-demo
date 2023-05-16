namespace GRPT.Helper
{

    public static class Utility
    {

        public static string EncryptPassword(this string password)
        {
            byte[] encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }


        public static string DecryptPassword(this string encryptedPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptedPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }


        public static string ToJson<T>(this T data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static T ToObject<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }


        public enum HttpActions
        {
            Get,
            Post,
            Put,
            Delete,
        }

        public enum DataListType
        {
            Employee,
            EmployeeWithEmployeeCode,
            Department
        }
    }
}