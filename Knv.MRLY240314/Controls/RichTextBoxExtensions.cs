﻿
namespace Knv.MRLY240314.Controls
{ 
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            if (addNewLine)
                text += Environment.NewLine;

            if (box.IsDisposed)
                return;

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
