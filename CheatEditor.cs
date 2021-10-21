using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nitro_AR_Cheat_Manager
{
    public partial class CheatEditor : Form
    {
        private Code selectedCheat;
        private CodeList cheatList;
        public CheatEditor(Code selectedCheat, CodeList cheatList)
        {
            InitializeComponent();
            this.selectedCheat = selectedCheat;
            this.cheatList = cheatList;
            initializeComponents();
        }


        private void initializeComponents()
        {
            if (this.selectedCheat != null)
            {
                nameText.Text = this.selectedCheat.getName();
                codeText.Text = this.selectedCheat.getCheat();
                descriptionText.Text = this.selectedCheat.getDescription();
                lineCountLabel.Text = this.selectedCheat.getLineAmount().ToString();
            }
        }
        public String removeEmptyLines(String s)
        {
            return Regex.Replace(s, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }

        private List<String> getLinesFromString(String s)
        {
            String accumulator = "";
            List<String> lines = new List<String>();

            foreach (Char character in s)
            {
                if (character == 0xA)
                {
                    accumulator = accumulator.Replace("\r", "");
                    lines.Add(String.Copy(accumulator));
                    accumulator = "";
                }
                else accumulator += character;
            }
            lines.Add(String.Copy(accumulator));
            return lines;
        }

        //Validates format of cheat with regular expressions
        private bool validateCheat(String cheat)
        {
            Regex rx = new Regex(@"^[\da-fA-F]{8}\s[\da-fA-F]{8}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            List<String> stringLines;

            cheat = removeEmptyLines(cheat);
            stringLines = getLinesFromString(cheat);

            foreach (String line in stringLines)
            {
                if (!rx.IsMatch(line)) return false;
            }
            return true;
        }

        private void saveCheatButton_Click(object sender, EventArgs e)
        {
            String cheatName = nameText.Text;
            String cheatCode = codeText.Text;
            String description = descriptionText.Text;
            int lineAmount = Convert.ToInt32(lineCountLabel.Text);

            if (validateCheat(cheatCode))
            {
                if (this.selectedCheat == null) this.cheatList.addCode(cheatName, cheatCode, description, lineAmount, false);
                else this.selectedCheat.update(cheatName, cheatCode, description, lineAmount, false);
                this.Close();
            }
            else MessageBox.Show("Cheat Code is not in the proper format!");
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void codeText_TextChanged(object sender, EventArgs e)
        {
            List<String> stringLines;

            int lineCount = 0;
            String cheat = codeText.Text;
            Regex rx = new Regex(@"^[\da-fA-F]{8}\s[\da-fA-F]{8}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            cheat = removeEmptyLines(cheat);
            stringLines = getLinesFromString(cheat);
            

            foreach (String line in stringLines)
            {
                if (rx.IsMatch(line)) lineCount++;
            }

            lineCountLabel.Text = lineCount.ToString();
        }
    }
}
