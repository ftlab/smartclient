using SmartClient.Core.Container;
using System;
using System.Collections.Generic;
using System.IO;

namespace SmartClient.Core.Controls.Bars
{
    public static class AppBarSettings
    {
        private static readonly HashSet<string> _pinned = new HashSet<string>();

        private static readonly Queue<string> _last = new Queue<string>();

        private static string PinnedViewsSettings = "Bar_PinnedViews";

        private static string LastViewsSettings = "Bar_LastViews";

        static AppBarSettings()
        {
            ReadSettings();
        }

        public static void SaveSettings()
        {
            var pinned = string.Join(";", _pinned);
            var last = string.Join(";", _last);

            ServiceContainer.Default
                .UserSettingsService
                .Set<string>(PinnedViewsSettings, pinned);
            ServiceContainer.Default
                .UserSettingsService
                .Set<string>(LastViewsSettings, last);
        }

        public static void ReadSettings()
        {
            _pinned.Clear();
            _last.Clear();

            var pinned = ServiceContainer.Default
                .UserSettingsService
                .Get<string>(PinnedViewsSettings);
            if (string.IsNullOrEmpty(pinned) == false)
            {
                foreach (var item in pinned.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    SetPinned(item);
            }

            var last = ServiceContainer.Default
                .UserSettingsService
                .Get<string>(LastViewsSettings);
            if (string.IsNullOrEmpty(last) == false)
            {
                foreach (var item in last.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    SetLast(item);
            }
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
            if (_last.Contains(itemName)) return;
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
