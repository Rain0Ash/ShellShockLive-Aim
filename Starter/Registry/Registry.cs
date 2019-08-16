// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO;
using System.Security;
using Common;
using Microsoft.Win32;
using SharpDX;

namespace Ruler.Starter.Registry
{
    internal struct RegistrySettings
    {
        internal String ID;
        internal String Key;
        internal String LanguageCode;
        internal Int32 MonitorID;
        internal Boolean IsDisguise;
        internal Boolean DontUseRegistry;
        internal Boolean DontShowAnymore;
        internal String BuildDateTimeHash;

        internal RegistrySettings(String id = null, String key = null, String languageCode = null, Int32 monitorID = 0, Boolean isDisguise = false, Boolean dontUseRegistry = true, Boolean dontShowAnymore = false, String buildDateTimeHash = null)
        {
            ID = id ?? Licence.FreeID;
            Key = key ?? Licence.FreeKey;
            LanguageCode = languageCode ?? Localization.DefaultCulture;
            MonitorID = monitorID;
            IsDisguise = isDisguise;
            DontUseRegistry = dontUseRegistry;
            DontShowAnymore = dontShowAnymore;
            BuildDateTimeHash = buildDateTimeHash ?? Licence.Sha256(Settings.Version);
        }
    }
    
    internal static class Registry
    {
        private const String RegKeyID = @"ID";
        private const String RegKeyKey = @"Key";
        private const String RegKeyLanguageCode = @"LanguageCode";
        private const String RegKeyMonitorID = @"MonitorID";
        private const String RegKeyIsDisguise = @"IsDisguise";
        private const String RegKeyUseRegistry = @"UseRegistry";
        private const String RegKeyShow = @"Show";
        private const String RegKeyBuildDateTimeHash = @"BuildDateTimeHash";

        private const String SubKey = @"Software\\Ruler";
        internal static RegistrySettings GetRegistry(Boolean isStandart = false)
        {
            if (isStandart) return new RegistrySettings(null);
            
            try
            {
                RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey) ?? throw new NullReferenceException();
                Int32.TryParse(GetRegistryValue(ref currentUserKey, RegKeyMonitorID), out Int32 monitorID);
                RegistrySettings registrySettings = new RegistrySettings(
                    GetRegistryValue(ref currentUserKey, RegKeyID),
                    GetRegistryValue(ref currentUserKey, RegKeyKey),
                    GetRegistryValue(ref currentUserKey, RegKeyLanguageCode), 
                    monitorID,
                    ToBoolean(GetRegistryValue(ref currentUserKey, RegKeyIsDisguise)),
                    !ToBoolean(GetRegistryValue(ref currentUserKey, RegKeyUseRegistry)),
                    !ToBoolean(GetRegistryValue(ref currentUserKey, RegKeyShow)),
                    GetRegistryValue(ref currentUserKey, RegKeyBuildDateTimeHash));
                
                currentUserKey.Close();
                return registrySettings;
            }
            catch(Exception ex) when 
                (ex is NullReferenceException || ex is ObjectDisposedException ||
                 ex is SecurityException)
            {
                return new RegistrySettings(null);
            }
        }

        internal static Boolean SetRegistry(RegistrySettings registrySettings)
        {
            try
            {
                RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(SubKey) ?? throw new NullReferenceException();
                currentUserKey.SetValue(RegKeyID, registrySettings.ID ?? Licence.FreeID);
                currentUserKey.SetValue(RegKeyKey, registrySettings.Key ?? Licence.FreeKey);
                currentUserKey.SetValue(RegKeyLanguageCode, registrySettings.LanguageCode);
                currentUserKey.SetValue(RegKeyMonitorID, registrySettings.MonitorID.ToString());
                currentUserKey.SetValue(RegKeyIsDisguise, registrySettings.IsDisguise);
                currentUserKey.SetValue(RegKeyUseRegistry, !registrySettings.DontUseRegistry);
                currentUserKey.SetValue(RegKeyShow, !registrySettings.DontShowAnymore);
                currentUserKey.SetValue(RegKeyBuildDateTimeHash, registrySettings.BuildDateTimeHash);
                
                currentUserKey.Close();
                return true;
            }
            catch (Exception ex) when
                 (ex is ObjectDisposedException || ex is SecurityException ||
                  ex is UnauthorizedAccessException || ex is IOException)
            {
                return false;
            }
        }

        internal static Boolean RemoveRegistry()
        {
            try
            {
                if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SubKey) != null)
                    Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(SubKey);
                return true;
            }
            catch (Exception ex) when
            (ex is IOException || ex is SecurityException ||
             ex is ObjectDisposedException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static String GetRegistryValue(ref RegistryKey registryKey, String key)
        {
            return registryKey.GetValue(key)?.ToString();
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