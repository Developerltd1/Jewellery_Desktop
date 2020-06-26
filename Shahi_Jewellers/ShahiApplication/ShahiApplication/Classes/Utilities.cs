using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication.Classes
{
    class Utilities
    {
        public static void _Asterisk(string AsteriskTEXT)
        {
            MessageBox.Show(AsteriskTEXT, "Asterisk",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }      
        public static void _Error(string ErrorTEXT)
        {
            MessageBox.Show(ErrorTEXT, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void _Exclamation(string ExclamationTEXT)
        {
            MessageBox.Show(ExclamationTEXT, "Exclamation",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void _Hand(string HandTEXT)
        {
            MessageBox.Show(HandTEXT, "Hand",
            MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        public static void _Information(string InformationTEXT)
        {
            MessageBox.Show(InformationTEXT, "Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void _None(string NoneTEXT)
        {
            MessageBox.Show(NoneTEXT, "None",
            MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static void _Question(string QuestionTEXT)
        {
            MessageBox.Show(QuestionTEXT, "Question",
            MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public static void _Stop(string StopTEXT)
        {
            MessageBox.Show(StopTEXT, "Stop",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void _Warning(string WarningTEXT)
        {
            MessageBox.Show(WarningTEXT, "Warning",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
       
       
       
       
    }
}
