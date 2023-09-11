﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MP3_YoutubeConverter
{
    public partial class AlertForm : Form
    {
        #region FIELDS AND ENUMS

        private int x, y;

        // Defines a public enumeration named Action with three possible values: wait, start, and close.
        // This enumeration represents different states of the alert form.
        public enum Action
        {
            wait,
            start,
            close
        }

        // Defines a public enumeration named Type with four possible values: Success, Warning, Error, and Info.
        // This enumeration represents different types of alerts.
        public enum Type
        {
            Success,
            Warning,
            Error,
            Info
        }

        private AlertForm.Action action;

        #endregion

        public AlertForm()
        {
            InitializeComponent();
        }
    }
}

