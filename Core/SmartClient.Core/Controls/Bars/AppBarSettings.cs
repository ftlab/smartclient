using System;
using System.Collections.Generic;
using System.IO;

namespace SmartClient.Core.Controls.Bars
{
    public static class AppBarSettings
    {
        private static readonly HashSet<string> _pinned = new HashSet<string>();

        private static readonly Queue<string> _last = new Queue<string>();

        static AppBarSettings()
        {
            ReadSettings();
        }

        public static void SaveSettings()
        {
            var pinned = string.Join(";", _pinned);
            var last = string.Join(";", _last);
            File.WriteAllText("appbar.settings", pinned + Environment.NewLine + last);
        }

        public static void ReadSettings()
        {
            if (File.Exists("appbar.settings") == false)
                return;

            var text = File.ReadAllText("appbar.settings");
            _pinned.Clear();
            _last.Clear();
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
                foreach (var item in lines[0].Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    SetPinned(item);
            if (lines.Length > 1)
                foreach (var item in lines[1].Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    SetLast(item);
        }

        public static bool SetPinned(string itemName)
        {
            var res = _pinned.Add(itemName);
            if (res) SaveSettings();
            return res;
        }

        public static bool SetUnpinned(string itemName)
        {
            var res = _pinned.Remove(itemName);
            if (res) SaveSettings();
            return res;
        }

        public static void SetLast(string itemName)
        {
            if (_last.Count > 2)
                _last.Dequeue();
            _last.Enqueue(itemName);

            SaveSettings();
        }

        public static bool IsPinned(string itemName) => _pinned.Contains(itemName);

        public static bool IsLast(string itemName) => _last.Contains(itemName);

        internal static void SwitchPin(string itemName)
        {
            var isPinned = IsPinned(itemName);
            if (isPinned) SetUnpinned(itemName);
            else SetPinned(itemName);
        }
    }
}
