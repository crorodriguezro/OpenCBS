using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.Interface.Service;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class BaseView : Form
    {
        private readonly ITranslationService _translationService;
        private readonly Dictionary<Component, string> _map = new Dictionary<Component, string>();

        public BaseView() : this(null)
        {
        }

        public BaseView(ITranslationService translationService)
        {
            _translationService = translationService;
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        public void Translate()
        {
            if (_translationService == null) return;
            foreach (var pair in _map)
            {
                if (pair.Key is Control)
                    (pair.Key as Control).Text = _translationService.Translate(pair.Value);
                else if (pair.Key is ColumnHeader)
                    (pair.Key as ColumnHeader).Text = _translationService.Translate(pair.Value);
                else if (pair.Key is ToolStripButton)
                    (pair.Key as ToolStripButton).Text = _translationService.Translate(pair.Value);
            }
            Invalidate(true);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            InitControlKeyMap();
            Translate();
        }
    
        protected static IEnumerable<Control> GetControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(GetControls).Concat(controls);
        }
    
        private void InitControlKeyMap()
        {
            var validTypes = new[]
            {
                typeof (Label),
                typeof (Button),
                typeof (CheckBox),
                typeof (RadioButton),
                typeof (GroupBox),
                typeof (TreeListView),
                typeof (ObjectListView),
                typeof (ToolStrip),
                typeof (TabControl)
            };
            foreach (var control in GetControls(this).Where(c => validTypes.Contains(c.GetType())))
            {
                if (control is TreeListView)
                {
                    var listView = control as TreeListView;
                    for (var i = 0; i < listView.Columns.Count; i++)
                    {
                        var column = listView.Columns[i];
                        _map.Add(column, column.Text);
                    }
                }
                else if (control is ObjectListView)
                {
                    var listView = control as ObjectListView;
                    for (var i = 0; i < listView.Columns.Count; i++)
                    {
                        var column = listView.Columns[i];
                        _map.Add(column, column.Text);
                    }
                }
                else if (control is ToolStrip)
                {
                    var toolStrip = control as ToolStrip;
                    foreach (var button in toolStrip.Items.OfType<ToolStripButton>())
                    {
                        _map.Add(button, button.Text);
                    }
                }
                else if (control is TabControl)
                {
                    var tabControl = control as TabControl;
                    foreach (var tabPage in tabControl.TabPages.OfType<TabPage>())
                    {
                        _map.Add(tabPage, tabPage.Text);
                    }
                }
                else
                {
                    _map.Add(control, control.Text);
                }
            }
            _map.Add(this, Text);
        }
    }
}
