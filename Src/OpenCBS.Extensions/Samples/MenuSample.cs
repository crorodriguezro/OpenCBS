// Copyright © 2013 Open Octopus Ltd.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace OpenCBS.Extensions.TestExtensions
{
    /// <summary>
    /// This class is only for testing the main menu extensibility.
    /// It is handy to have it in the same solution to play with MEF.
    /// 
    /// To enable this menu item make sure the two attributes below are uncommented.
    /// If, on the other hand, you want to disable it, comment out the attributes.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IMenu))]
    public class MenuSample : IMenu
    {
        public MenuSample()
        {
            Item = new ToolStripMenuItem { Text = "TEST "};
            Item.Click += (sender, args) => MessageBox.Show("Hello, this is a test message");
        }

        public string InsertAfter
        {
            get { return "mnuClients"; }
        }

        public ToolStripMenuItem Item { get; private set; }
    }
}
