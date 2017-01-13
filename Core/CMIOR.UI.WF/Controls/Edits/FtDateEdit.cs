using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Accessibility;
using DevExpress.XtraEditors.Mask;
using System.Diagnostics;
using DevExpress.Utils;

namespace CMIOR.UI.WF.Controls.Edits
{
    [ToolboxItem(true)]
    public class FtDateEdit : DateEdit
    {
        private string _inputText;

        static FtDateEdit() { RepositoryItemFtDateEdit.RegisterFtDateEdit(); }

        public FtDateEdit()
        {
        }

        public override string EditorTypeName => nameof(FtDateEdit);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemFtDateEdit Properties
        {
            get { return base.Properties as RepositoryItemFtDateEdit; }
        }

        protected override void OnMaskBox_TextValidated(object sender, EventArgs e)
        {
            base.OnMaskBox_TextValidated(sender, e);

            var box = (MaskBox)sender;
            if (box == null) throw new NullReferenceException(nameof(box));
            _inputText = box.EditText;

            Debug.WriteLine(_inputText);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            DateTime dt;
            if (string.IsNullOrEmpty(_inputText) == false
                && DateTime.TryParse(_inputText, out dt) == false)
                e.Cancel = true;

            base.OnValidating(e);
        }

        protected override bool OnInvalidValue(Exception sourceException)
        {
            Text = _inputText;
            return base.OnInvalidValue(sourceException);
        }
    }

    [UserRepositoryItem("RegisterFtDateEdit")]
    public class RepositoryItemFtDateEdit : RepositoryItemDateEdit
    {
        private DateEditMode _editMode;

        static RepositoryItemFtDateEdit() { RegisterFtDateEdit(); }

        public RepositoryItemFtDateEdit()
        {
            EditMode = DateEditMode.Date;
        }

        public override string EditorTypeName => nameof(FtDateEdit);

        public DateEditMode EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                DisplayFormat.FormatType = FormatType.DateTime;
                EditFormat.FormatType = FormatType.DateTime;
                string mask;

                if (value == DateEditMode.Date)
                    mask = "dd.MM.yyyy";
                else if (value == DateEditMode.DateAndTime)
                    mask = "dd.MM.yyyy HH:mm:ss";
                else throw new NotSupportedException(value.ToString());

                Mask.EditMask =
                EditMask =
                DisplayFormat.FormatString =
                EditFormat.FormatString = mask;
            }
        }

        public static void RegisterFtDateEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(
                new EditorClassInfo(
                nameof(FtDateEdit)
                , typeof(FtDateEdit)
                , typeof(RepositoryItemFtDateEdit)
                , typeof(DateEditViewInfo)
                , new ButtonEditPainter()
                , true
                , img
                , typeof(PopupEditAccessible)));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemFtDateEdit source = item as RepositoryItemFtDateEdit;
                if (source == null) return;
                EditMode = source.EditMode;
            }
            finally
            {
                EndUpdate();
            }
        }
    }

    public enum DateEditMode
    {
        Date,
        DateAndTime
    }
}
