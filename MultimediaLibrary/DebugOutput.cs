using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Controls;

namespace MultimediaLibrary
{
    public class DebugOutput : TextWriter
    {
        TextBox textBox = null;

        public DebugOutput(TextBox output)
        {
            textBox = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(value.ToString());
            }));
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
