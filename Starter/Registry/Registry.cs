using System;
using System.Security;
using Common;
using Microsoft.Win32;

namespace Ruler.Starter.Registry
{
    internal struct RegistrySettings
    {
        internal String ID;
        internal String Key;
        internal String LanguageCode;
        internal Boolean IsDisguise;
        internal Boolean DontShowAnymore;
        internal RegistrySettings(String id = null, String key = null, String languageCode = @"en", Boolean isDisguise = false, Boolean dontShowAnymore = false)
        {
            ID = id ?? Licence.FreeID;
            Key = key ?? Licence.FreeKey;
            LanguageCode = languageCode;
            IsDisguise = isDisguise;
            DontShowAnymore = dontShowAnymore;
        }
    }
    
    internal static class Registry
    {
        private const String SubKey = @"Software\\Ruler";
        internal static RegistrySettings GetRegistry()
        {
            try
            {
                RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey);
                return new RegistrySettings(
                    GetRegistryValue(ref currentUserKey, "ID"),
                    GetRegistryValue(ref currentUserKey, "Key"),
                    GetRegistryValue(ref currentUserKey, "LanguageCode"),
                    ToBoolean(GetRegistryValue(ref currentUserKey, "IsDisguise")),
                    !ToBoolean(GetRegistryValue(ref currentUserKey, "Show")));
            }
            catch(Exception ex) when (ex is ObjectDisposedException || ex is SecurityException)
            {
                return new RegistrySettings();
            }
        }

        internal static void SetRegistry(RegistrySettings registrySettings)
        {
            RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(SubKey);
            
        }

        private static String GetRegistryValue(ref RegistryKey registryKey, String key)
        {
            return registryKey.GetValue(key).ToString();
        }
        
        private static Boolean ToBoolean(this String value)
        {
            switch (value.ToLower())
            {
                case  "true":
                case "t":
                case "+":
                case "1":
                    return true;
                default:
                    return false;
            }
        }
    }
}