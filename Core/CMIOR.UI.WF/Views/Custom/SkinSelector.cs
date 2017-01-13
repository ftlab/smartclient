using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraBars.Helpers;
using System.Configuration;
using DevExpress.Utils;
using CMIOR.UI.WF.Container;

namespace CMIOR.UI.WF.Views.Custom
{
    public partial class SkinSelector : XtraUserControl
    {
        private bool _loading;

        public SkinSelector()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _loading = true;
            try
            {
                SkinHelper.InitSkinGallery(galleryControl1, true, true, true);

                fontEdit1.EditValue = AppearanceObject.DefaultFont.Name;
                spinEdit1.EditValue = AppearanceObject.DefaultFont.Size;
            }
            finally
            {
                _loading = false;
            }
        }

        private void galleryControl1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            var skin = (string)e.Item.Tag;
            if (string.IsNullOrEmpty(skin) == false)
            {
                ServiceContainer.Default
                    .UserSettingsService
                    .Set("uiskin", skin);
            }
        }

        private void fontEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var fontName = fontEdit1.EditValue as string;
            if (!_loading && string.IsNullOrEmpty(fontName) == false)
            {
                AppearanceObject.DefaultFont = new Font(fontName, AppearanceObject.DefaultFont.Size);

                ServiceContainer.Default
                    .UserSettingsService
                    .Set("fontname", fontName);
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var fontSize = Convert.ToSingle(spinEdit1.Value);
            if (!_loading && fontSize > 0)
            {
                AppearanceObject.DefaultFont = new Font(AppearanceObject.DefaultFont.Name, fontSize);

                ServiceContainer.Default
                    .UserSettingsService
                    .Set("fontsize", fontSize.ToString());
            }
        }
    }
}
