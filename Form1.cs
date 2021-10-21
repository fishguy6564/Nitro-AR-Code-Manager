using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nitro_AR_Cheat_Manager
{
    public partial class Form1 : Form
    {
        private CodeList codes;
        private String g_filePath = "";
        public Form1()
        {
            InitializeComponent();
            initializeVariables();
        }

        public void initializeVariables()
        {
            codes = new CodeList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private bool isName(String line)
        {
            Regex rx = new Regex(@"^\[.*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(line)) return true;
            return false;
        }
        
        private bool isCode(String line)
        {
            Regex rx = new Regex(@"^[\da-fA-F]{8}\s[\da-fA-F]{8}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(line)) return true;
            return false;
        }

        private bool isDescription(String line)
        {
            return false;
        }

        private void interpretTextFile(String codeList)
        {
            String nameAccumulator = "";
            String codeAccumulator = "";
            String descriptionAccumulator = "";
            int lineAccumulator = 0;
            bool isEnabled = false;
            Code currentCode = null;

            codeList = removeEmptyLines(codeList);
            List<String> codeListLines = getLinesFromString(codeList);

            foreach(String line in codeListLines)
            {
                if(isName(line.Replace("*", "")))
                {
                    if (currentCode == null) currentCode = new Code();
                    else
                    {
                        currentCode.update(nameAccumulator, codeAccumulator, descriptionAccumulator, lineAccumulator, isEnabled);
                        codes.addCode(currentCode);
                        currentCode = new Code();
                    }

                    nameAccumulator = "";
                    codeAccumulator = "";
                    descriptionAccumulator = "";
                    lineAccumulator = 0;
                    isEnabled = line.Contains("*");

                    nameAccumulator += line.Replace("[", "").Replace("]", "").Replace("*", "");

                }
                else if(isCode(line))
                {
                    codeAccumulator += line + "\r\n";
                    lineAccumulator++;
                }
                else
                {
                    descriptionAccumulator += line.Replace("*\\", "").Replace("\\*", "");
                }
            }

            currentCode.update(nameAccumulator, codeAccumulator, descriptionAccumulator, lineAccumulator, isEnabled);
            codes.addCode(currentCode);
        }

        private void updateList()
        {
            String[] nameList = this.codes.getStringList();
            cheatListBox.Items.Clear();

            for(int i = 0; i < nameList.Length; i++)
            {
                cheatListBox.Items.Add(nameList[i]);
                cheatListBox.SetItemChecked(i, codes.getCode(i).isCodeEnabled());
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int selectedCheat = cheatListBox.SelectedIndex;
            if(selectedCheat != -1)
            {
                CheatEditor editor = new CheatEditor(this.codes.getCode(selectedCheat), this.codes);
                editor.ShowDialog();
                updateList();
            } 
        }

        private void addCodeButton_Click(object sender, EventArgs e)
        {
            CheatEditor editor = new CheatEditor(null, this.codes);
            editor.ShowDialog();
            updateList();
        }

        private void cheatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cheatListBox.SelectedIndex;
            if(selectedIndex != -1)
            {
                Code cheat = codes.getCode(selectedIndex);
                cheatTextBox.Text = cheat.getCheat();
                descriptionTextBox.Text = cheat.getDescription();
            }
        }

        private void saveBinaryToFile(String filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                byte[] listBinary = codes.getBinaryFormat();
                writer.Write(listBinary);
                writer.Close();
            }
        }

        private void saveListToFile(String filepath)
        {
            using (StreamWriter writer = File.CreateText(filepath))
            {
                writer.Write(codes.ToString());
                writer.Close();
            }
        }

        private void openListFromFile(String filepath)
        {
            using (StreamReader reader = File.OpenText(filepath))
            {
                String codeList = reader.ReadToEnd();
                interpretTextFile(codeList);
                reader.Close();
                updateList();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openListDialog.ShowDialog() == DialogResult.OK)
            {
                String filepath = Path.GetFullPath(openListDialog.FileName);
                openListFromFile(filepath);
                this.g_filePath = filepath;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.g_filePath.Equals(""))
            {
                if (saveListDialog.ShowDialog() == DialogResult.OK)
                {
                    String filepath = Path.GetFullPath(saveListDialog.FileName);
                    saveListToFile(filepath);
                    this.g_filePath = filepath;
                }
            }
            else saveListToFile(this.g_filePath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveListDialog.ShowDialog() == DialogResult.OK)
            {
                String filepath = Path.GetFullPath(saveListDialog.FileName);
                saveListToFile(filepath);
                this.g_filePath = filepath;
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credits credit = new Credits();
            credit.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = cheatListBox.SelectedIndex;
            if(selectedIndex != -1)
            {
                cheatListBox.Items.RemoveAt(selectedIndex);
                codes.removeCode(selectedIndex);
            }
        }

        private void cheatListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int selectedIndex = cheatListBox.SelectedIndex;
            if(selectedIndex != -1)
            {
                Code cheat = codes.getCode(selectedIndex);

                if (cheatListBox.GetItemCheckState(selectedIndex) != CheckState.Checked) cheat.setEnabled(true);
                else cheat.setEnabled(false);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            if (saveBinaryDialog.ShowDialog() == DialogResult.OK)
            {
                String filepath = Path.GetFullPath(saveBinaryDialog.FileName);
                saveBinaryToFile(filepath);
            }
            
        }
    }
}
