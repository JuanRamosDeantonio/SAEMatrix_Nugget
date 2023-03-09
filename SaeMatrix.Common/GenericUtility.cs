using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace SAE.Matrix.Common
{
    using Entities;

    public static class GenericUtility
    {
        #region Converts

        public static HttpRequestHeaders ConvertToHttpHeaders(this Dictionary<string, string> queryParameters, HttpRequestMessage message)
        {
            queryParameters.ToList().ForEach(a => message.Headers.Add(a.Key, a.Value));
            return message.Headers;
        }

        public static string ConvertToQueryString(this Dictionary<string, string> queryParameters)
        {
            return string.Join("&", queryParameters.
                Select(a => $"{System.Web.HttpUtility.UrlEncode(a.Key)}={System.Web.HttpUtility.UrlEncode(a.Value)}"));
        }

        public static string ConvertToQueryString(this Dictionary<string, string> queryParameters, string url)
        {
            foreach (KeyValuePair<string, string> item in queryParameters)
            {
                url = url.Replace("{" + item.Key + "}", item.Value);
            }
            return url.ToString();
        }

        #endregion

        #region Comunes

        public static IEnumerable<double> DoubleRange(double min, double max, double step)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                double value = min + step * i;
                if (value > max)
                {
                    break;
                }
                yield return value;
            }
        }
        public static bool IsEmpty<T>(this List<T> data)
        {
            return data == null || data.Count == 0;
        }
        public static bool IsEmpty(this string me)
        {
            return string.IsNullOrWhiteSpace(me);
        }
        public static bool IsEmpty(this object me)
        {
            return me == null;
        }
        public static string ToTitleCase(this string s)
        {
            // make the first letter of each word uppercase
            var titlecase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());
            // match any letter after an apostrophe and make uppercase
            titlecase = Regex.Replace(titlecase, "[^A-Za-z0-9 ](?:.)", m => m.Value.ToUpper());
            // look for 'S at the end of a word and make lower
            titlecase = Regex.Replace(titlecase, @"('S)\b", m => m.Value.ToLower());
            return titlecase;
        }
        public static DateTime ToDateTime(this string data)
        {
            if (!string.IsNullOrWhiteSpace(data) && DateTime.TryParse(data, out _))
                return Convert.ToDateTime(data);

            return DateTime.MinValue;
        }
        public static decimal ToDecimal(this string data)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                var data1 = decimal.TryParse(data.Replace(",", "."), out _);
                var data2 = decimal.TryParse(data.Replace(".", ","), out _);

                if (data1 || data2)
                {
                    return Convert.ToDecimal(data.Replace(".", ","));
                }
                return -1;
            }

            return -1;
        }
        public static decimal? ToDecimalNull(this string data)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                var data1 = decimal.TryParse(data.Replace(",", "."), out _);
                var data2 = decimal.TryParse(data.Replace(".", ","), out _);

                if (data1 || data2)
                {
                    return Convert.ToDecimal(data.Replace(".", ","));
                }
                return null;
            }

            return null;
        }
        public static Int32 ToInt(this string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return 0;
            }
            else
            {
                var data1 = int.TryParse(data.Replace(",", "."), out _);
                var data2 = int.TryParse(data.Replace(".", ","), out _);

                if (data1 || data2)
                {
                    return Convert.ToInt32(data);
                }
            }

            return -1;
        }
        public static Int32? ToIntNull(this string data)
        {
            int value;
            bool isValid = int.TryParse(data, out value);
            if (isValid)
            {
                return value;
            }
            return null;
        }
        public static bool IsValidFormat(this string data, string regularExpression)
        {
            return Regex.IsMatch(data, regularExpression);
        }
        public static string GetSerializedEntity<T>(this T entity)
        {
            try
            {
                return JsonConvert.SerializeObject(entity);
            }
            catch (Exception) { return null; }
        }
        public static ResponseBase<T> ResponseBaseCatch<T>(bool validation, Exception ex, HttpStatusCode status)
        {
            ResponseBase<T> retval = new ResponseBase<T>();
            if (validation)
            {
                retval.Code = (int)status;
                retval.Message = ex.Message;
            }
            
            return retval;
        }

        #endregion
    }
}