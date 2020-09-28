namespace PierreARNAUDET.Core.PlayerPreferences.Helpers
{
    using System;
    using UnityEngine;

    public static class PlayerPrefsHelper
    {
        public static void Delete(string key)
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        public static bool Has(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static void Set<T>(string key, T value)
        {
            // Regarding the type, we call the expected function
            if (value is float)
            {
                PlayerPrefs.SetFloat(key, (float)Convert.ToDouble(value));
            }
            else if (value is int)
            {
                PlayerPrefs.SetInt(key, Convert.ToInt32(value));
            }
            else if (value is bool)
            {
                PlayerPrefs.SetInt(key, Convert.ToInt32(value));
            }
            else
            {
                PlayerPrefs.SetString(key, value.ToString());
            }

            PlayerPrefs.Save();
        }

        public static T Get<T>(string key, T defaultValue)
        {
            var res = defaultValue;

            // If hasKey, we check for its value
            if (Has(key))
            {
                // Regarding the type, we call the expected function
                if (defaultValue is float)
                {
                    res = (T)Convert.ChangeType(PlayerPrefs.GetFloat(key), typeof(T));
                }
                else if (defaultValue is int)
                {
                    res = (T)Convert.ChangeType(PlayerPrefs.GetInt(key), typeof(T));
                }
                else if (defaultValue is bool)
                {
                    bool value = PlayerPrefs.GetInt(key) == 1;
                    res = (T)Convert.ChangeType(value, typeof(T));
                }
                else
                {
                    var value = PlayerPrefs.GetString(key);
                    if (typeof(T).IsEnum)
                    {
                        res = (T)Enum.Parse(typeof(T), value);
                    }
                    else
                    {
                        res = (T)Convert.ChangeType(value, typeof(T));
                    }
                }
            }

            return res;
        }
    }
}