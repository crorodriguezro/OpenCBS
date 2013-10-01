using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCBS.GUI.Localization
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs args)
        {
            base.OnLoad(args);
            Translate(this, LanguageParser.Dictionary);
        }

        private IEnumerable<Control> GetControls(Control control, Type type = null)
        {
            var controls = control.Controls.Cast<Control>();
            if (type == null)
                return controls.SelectMany(ctrl => GetControls(ctrl, type)).Concat(controls);
            else
                return controls.SelectMany(ctrl => GetControls(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void Translate(Control frm, Dictionary<string, string> translator)
        {
            var elements = GetControls(frm, null);
            foreach (var ctrl in elements)
            {
                foreach (var item in translator)
                {
                    if (ctrl.Text == item.Key || ctrl.Text.Contains(item.Key))
                        ctrl.Text = item.Value;
                }
            }
        }
    }
}
