using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitro_AR_Cheat_Manager
{
	public class Code
	{
		private int lineAmount;
		private String name;
		private String cheat;
		private String description;
		private bool isEnabled;

		public Code(String name, String cheat, String description, int lineAmount, bool isEnabled)
		{
			this.name = name;
			this.cheat = cheat;
			this.description = description;
			this.lineAmount = lineAmount;
			this.isEnabled = isEnabled;
		}

		public Code()
        {
			this.cheat = "";
			this.description = "";
			this.lineAmount = 0;
        }

		public void update(String name, String cheat, String description, int lineAmount, bool isEnabled)
        {
			this.name = name;
			this.cheat = cheat;
			this.description = description;
			this.lineAmount = lineAmount;
			this.isEnabled = isEnabled;
		}

		public String getCheat()
		{
			return this.cheat;
		}

		public String getDescription()
		{
			return this.description;
		}

		public String getName()
        {
			return this.name;
        }

		public int getLineAmount()
		{
			return this.lineAmount;
		}

		public bool isCodeEnabled()
        {
			return this.isEnabled;
        }

		public override String ToString()
        {
			String accumulator = "";
			if (this.isEnabled) accumulator += "*";
			accumulator += "[" + this.name + "]\r\n";
			accumulator += this.cheat + "\r\n\n";

			if (!this.description.Equals(""))
            {
				accumulator += this.description;
            }

			return accumulator;
        }

		private List<String> getCodeFromString(String s)
		{
			String[] codeSplit;
			String accumulator = "";
			List<String> lines = new List<String>();

			foreach (Char character in s)
			{
				if (character == 0xA)
				{
					accumulator = accumulator.Replace("\r", "");
					codeSplit = accumulator.Split(' ');

					foreach(String split in codeSplit)
                    {
						lines.Add(String.Copy(split));
                    }
					accumulator = "";
				}
				else accumulator += character;
			}

			if(!accumulator.Equals(""))
            {
				accumulator = accumulator.Replace("\r", "");
				codeSplit = accumulator.Split(' ');
				foreach (String split in codeSplit)
				{
					lines.Add(String.Copy(split));
				}
			}
			
			return lines;
		}

		public List<byte> getBinaryFormat()
        {
			List<byte> codeBinary = new List<byte>();

			List<String> codeStrings = getCodeFromString(this.cheat);

			foreach(String code in codeStrings)
            {
				int value = Convert.ToInt32(code, 16);

				for(int i = 0; i < 4; i++)
                {
					codeBinary.Add((byte)(value & 0xFF));
					value = value >> 8;
                }
            }
			return codeBinary;
        }

		public void setEnabled(bool isEnabled)
        {
			this.isEnabled = isEnabled;
        }

	}
}
