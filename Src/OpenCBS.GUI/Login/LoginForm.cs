// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
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

using System.Windows.Forms;
using OpenCBS.CoreDomain;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Services;

namespace OpenCBS.GUI.Login
{
    public partial class LoginForm : Form
    {
        private readonly string _userName;
        private readonly string _password;

        public LoginForm(string userName, string password)
        {
            InitializeComponent();
            Setup();
            _userName = userName;
            _password = password;
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            startButton.Click += (sender, args) => Start();
        }

        private void LoadForm()
        {
            if (_userName != null)
                usernameTextbox.Text = _userName;

            if (_password != null)
                passwordTextbox.Text = _password;

            usernameTextbox.Focus();
        }

        private void Start()
        {
            if (!UserIsValid())
                SetUser();
            else
                MessageBox.Show(MultiLanguageStrings.GetString(
                    Ressource.PasswordForm,
                    "messageBoxUserPasswordBlank.Text"), "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetUser()
        {
            var user = ServicesProvider
                .GetInstance()
                .GetUserServices()
                .Find(usernameTextbox.Text, passwordTextbox.Text);

            if (user == null)
            {
                MessageBox.Show(MultiLanguageStrings.GetString(Ressource.PasswordForm, "messageBoxUserPasswordIncorrect.Text"), "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                passwordTextbox.Focus();
                passwordTextbox.SelectAll();
            }
            else
            {
                User.CurrentUser = user;
                Close();
            }
        }

        private bool UserIsValid()
        {
            return string.IsNullOrEmpty(usernameTextbox.Text) || string.IsNullOrEmpty(passwordTextbox.Text);
        }
    }
}
