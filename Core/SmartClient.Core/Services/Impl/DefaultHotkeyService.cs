using SmartClient.Core.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartClient.Core.Services.Impl
{
    public class DefaultHotkeyService : IHotkeyService
    {
        private readonly Dictionary<Control, Dictionary<Keys, List<Action>>> _hotkeys = new Dictionary<Control, Dictionary<Keys, List<Action>>>();

        public IHotkeyService Register(Control control, Keys key, Action handler)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            Dictionary<Keys, List<Action>> handlers;
            if (_hotkeys.TryGetValue(control, out handlers) == false)
            {
                handlers = new Dictionary<Keys, List<Action>>();
                _hotkeys.Add(control, handlers);

                if (control is ISupportKeyProcess)
                    ((ISupportKeyProcess)control).KeyProcess += Control_KeyProcess;
                else
                    control.PreviewKeyDown += Control_PreviewKeyDown;

                control.Disposed += Control_Disposed;
            }

            if (handlers.ContainsKey(key))
                handlers[key].Add(handler);
            else
                handlers.Add(key, new List<Action>() { handler });

            return this;
        }

        public IHotkeyService UnRegister(Control control)
        {
            if (control is ISupportKeyProcess)
                ((ISupportKeyProcess)control).KeyProcess -= Control_KeyProcess;
            else
                control.PreviewKeyDown -= Control_PreviewKeyDown;

            control.Disposed -= Control_Disposed;
            if (_hotkeys.ContainsKey(control))
                _hotkeys.Remove(control);

            return this;
        }

        public IHotkeyService UnRegister(Control control, Keys key)
        {
            Dictionary<Keys, List<Action>> handlers;
            if (_hotkeys.TryGetValue(control, out handlers)
                && handlers.ContainsKey(key))
            {
                handlers.Remove(key);
                if (handlers.Count < 1) UnRegister(control);
            }
            return this;
        }

        private void Control_Disposed(object sender, EventArgs e)
        {
            UnRegister((Control)sender);
        }

        private void Control_KeyProcess(object sender, KeyEventArgs e)
        {
            var control = (Control)sender;
            ProcessKey(control, e.KeyData);
        }

        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var control = (Control)sender;
            ProcessKey(control, e.KeyData);
        }

        private void ProcessKey(Control control, Keys key)
        {
            if (_hotkeys.ContainsKey(control) == false) throw new InvalidOperationException("DefaultHotkeyService");

            var handlers = _hotkeys[control];
            List<Action> actions;
            if (handlers.TryGetValue(key, out actions))
                actions.ForEach(x => x.Invoke());
        }
    }
}
