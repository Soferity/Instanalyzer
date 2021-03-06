﻿using Instanalyzer.Helpers;
using Instanalyzer.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Instanalyzer.Views.UC.Login.ETC
{
    public partial class Account : UserControl
    {
        private readonly string _Name, _Surname, _Username;
        private readonly Image _PPhoto = null;
        private readonly Sex.SexType _Sex = Sex.SexType.Unknown;

        public Account(string Name = "Name", string Surname = "Surname", string Username = "Username", string PPhoto = null, Sex.SexType Sex = Sex.SexType.Unknown)
        {
            InitializeComponent();
            _Name = Name;
            _Surname = Surname;
            _Username = Username;
            PPTT.SetToolTip(PP, Username + "\n" + Name + " " + Surname);
            if (!string.IsNullOrEmpty(PPhoto) && File.Exists(PPhoto))
            {
                PP.Image = Image.FromFile(PPhoto);
                _PPhoto = Image.FromFile(PPhoto);
            }
            else
            {
                switch (Sex)
                {
                    case Helpers.Sex.SexType.Unknown:
                        PP.Image = Properties.Resources.Unknown;
                        _Sex = Helpers.Sex.SexType.Unknown;
                        break;
                    case Helpers.Sex.SexType.Female:
                        PP.Image = Properties.Resources.Female;
                        _Sex = Helpers.Sex.SexType.Female;
                        break;
                    case Helpers.Sex.SexType.Male:
                        PP.Image = Properties.Resources.Male;
                        _Sex = Helpers.Sex.SexType.Male;
                        break;
                }
            }
        }

        private void PP_Click(object sender, EventArgs e)
        {
            User.Name = _Name;
            User.Surname = _Surname;
            User.Username = _Username;
            User.PPhoto = _PPhoto;
            User.Sex = _Sex;
            Window.WindowMode = Window.WindowType.Wait;
        }
    }
}
