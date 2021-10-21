using System;
using System.IO;
using System.Collections.Generic;

public class CodeList
{
	public class Code
    {
		private uint lineAmount;
		private String cheat;
		private String description;

		public Code(String cheat, String description)
        {
			this.cheat = cheat;
			this.description = description;
        }

		public String getCheat()
        {
			return this.cheat;
        }

		public String getDescription()
        {
			return this.description;
        }

		public uint getLineAmount()
        {
			return this.lineAmount;
        }

    }

	private List<CodeList> list;
	private int amount;
	public CodeList(FileStream codeList)
	{

	}

	public CodeList()
    {
		this.amount = 0;
		this.list = new List<CodeList>();
    }

	public void clear()
    {
		this.list = null;
		this.amount = 0;
    }

	public void addCode(String cheat, String description)
    {
		Code entry = new Code(cheat, description);
		this.list.Add(entry);
		this.amount++;
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
}
