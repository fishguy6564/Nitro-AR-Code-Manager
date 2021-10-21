using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitro_AR_Cheat_Manager
{
	public class CodeList
	{

		private List<Code> list;
		private int amount;
		public CodeList(FileStream codeList)
		{

		}

		public CodeList()
		{
			this.amount = 0;
			this.list = new List<Code>();
		}

		public void addCode(String name, String cheat, String description, int lineAmount, bool isEnabled)
		{
			Code entry = new Code(name, cheat, description, lineAmount, isEnabled);
			this.list.Add(entry);
			this.amount++;
		}

		public void addCode(Code cheatcode)
        {
			this.list.Add(cheatcode);
			this.amount++;
        }

		public void insertCode(Code cheatCode)
        {
			int index = this.list.IndexOf(cheatCode);
			this.list.Insert(index, cheatCode);
        }

		public void removeCode(int index)
		{
			Code deletedCode = this.list[index];
			this.list.Remove(deletedCode);
		}

		public void interpretFile(FileStream codeList)
		{
			return; //Todo
		}

		public Code getCode(int index)
        {
			return this.list[index];
        }

		public override String ToString()
        {
			String accumulator = "";

			foreach(Code cheat in list)
            {
				accumulator += cheat.ToString() + "\n";
            }

			return accumulator;
        }

		public List<byte> convertIntByte(int value)
        {
			List<byte> codeBinary = new List<byte>();
			for (int i = 0; i < 4; i++)
			{
				codeBinary.Add((byte)(value & 0xFF));
				value = value >> 8;
			}
			return codeBinary;
		}

		public byte[] getBinaryFormat()
        {
			List<byte> listBinary = new List<byte>();
			List<byte> headBinary;
			int lineCount = 0;

			foreach(Code cheat in list)
            {
				if (cheat.isCodeEnabled())
				{
					listBinary.AddRange(cheat.getBinaryFormat());
					lineCount += cheat.getLineAmount();
				}
            }

			headBinary = convertIntByte(lineCount * 2);
			headBinary.AddRange(listBinary);

			return headBinary.ToArray();
        }

		public String[] getStringList()
        {
			String[] nameList = new string[this.list.Count()];

			for(int i = 0; i < nameList.Length; i++)
            {
				nameList[i] = this.list[i].getName();
            }

			return nameList;
        }
	}
}
