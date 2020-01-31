using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PasswordManagement
{
    class Utils
    {
        private const String uniqueLetters = @"[^A-Za-z0-9]";
        private const String alphabetLetters = @"[a-zA-Z]";
        private const String numberLetters = @"[0-9]";
        private static Regex uniqueRegex = new Regex(uniqueLetters);
        private static Regex alphabetRegex = new Regex(alphabetLetters);
        private static Regex numberRegex = new Regex(numberLetters);

        public static readonly String appName = "PWHub";
        public static readonly String version = "1.1.1v";
        public static readonly String developer = "션쿠";
        private static readonly DateTime InitialTimestampFlag = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        public static void log(String str)
        {
            String finalStr = "["+getDetailedCurrentFormattedTimeString() + "] " + str;
            Console.WriteLine(finalStr);
        }

        public static String getDetailedCurrentFormattedTimeString()
        {
            return getDetailedDateTimeFormattedString(getCurrentTimeMillis());
        }

        public static String getCurrentFormattedTimeString()
        {
            return getDateTimeFormattedString(getCurrentTimeMillis());
        }

        public static String getDevelopmentInfo()
        {
            return appName + " " + version + " by " + developer;
        }

        public static String getDefaultWindowTitle()
        {
            return "[" + developer + "]" + appName + " " + version;
            //return appName + " " + version + " _" + developer;
        }

        //Long형 시간을 포매팅하여 리턴
        public static String getDateTimeFormattedString(long time)
        {
            DateTime timestamp = InitialTimestampFlag.AddMilliseconds(time).ToLocalTime();
            return timestamp.ToString("yyyy-MM-dd tt h:mm");
        }
        public static String getDetailedDateTimeFormattedString(long time)
        {
            DateTime timestamp = InitialTimestampFlag.AddMilliseconds(time).ToLocalTime();
            return timestamp.ToString("yyyy-MM-dd tt h:mm:ss.fff");
        }
        public static long getCurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - InitialTimestampFlag).TotalMilliseconds + 9;
        }
        public static String getRandomKey()
        {
            const int keyLength = 15;

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] randBytes = new byte[keyLength];
            provider.GetBytes(randBytes);

            return Convert.ToBase64String(randBytes);
        }
        public static void getPasswordSecurity(String password, Label label, Button confirm)
        {
            String res = "", response;
            int score = 0;
            int length = password.Length;

            if (length >= 10)
            {
                score += 50;
            }
            else
            {
                score += 5 * length;
                res += " [길이: " + length + "]";
            }

            if (uniqueRegex.IsMatch(password))
            {
                score += 30;
            }
            else
            {
                res += " [특수문자 포함X]";
            }

            if(alphabetRegex.IsMatch(password) && numberRegex.IsMatch(password))
            {
                score += 20;
            }
            else
            {
                res += " [영문+숫자 포함X]";
            }


            if (score < 30) response = "매우 위험";
            else if (score < 50) response = "다소 위험";
            else if (score < 70) response = "권장하지 않음";
            else if (score <= 85) response = "안전";
            else response = "매우 안전";

            //50점 이상만 통과
            confirm.IsEnabled = score >= 50;

            double rate = (double)score / 100;
            int red = (int)(255 * (1 - rate));
            int green = (int)(180 * rate);

            response += "(" + score + ")" + res ;
            label.Content = response;
            label.Foreground = convertStringToColor(red, green, 0);
        }

        public static SolidColorBrush convertStringToColor(String color)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        public static SolidColorBrush convertStringToColor(int r, int g, int b)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(getColorCodeFromRGB(r,g,b)));
        }

        private static String getColorCodeFromRGB(int r, int g, int b)
        {
            return "#" + r.ToString("X02") + g.ToString("X02") + b.ToString("X02");
        }
    }
}
