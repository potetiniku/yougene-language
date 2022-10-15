using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YougeneLanguage.Main;

internal class BFInterpreter
{
	public BFInterpreter(IReadOnlyDictionary<BFInstruction, string> instructionSet, int memolySize)
	{
		InstructionSet = instructionSet;
		MemolySize = memolySize;
		Memory = new int[MemolySize];
	}

	public readonly IReadOnlyDictionary<BFInstruction, string> InstructionSet;
	public readonly int MemolySize;

	public int[] Memory { get; private set; }
	public int Pointer { get; private set; }
	public int ProgramCounter { get; private set; }

	public void Execute(string code)
	{
		BFInstruction[] instructions = Parse(code);

		Memory = new int[MemolySize];
		Pointer = 0;
		ProgramCounter = 0;

		for (ProgramCounter = 0; ProgramCounter < instructions.Length; ProgramCounter++)
		{
			ExecuteCurrentInstruction(instructions);
		}
	}

	private void ExecuteCurrentInstruction(IReadOnlyList<BFInstruction> instructions)
	{
		BFInstruction instruction = instructions[ProgramCounter];

		switch (instruction)
		{
			case BFInstruction.AdvancePointer:
				Pointer++;
				break;
			case BFInstruction.RetreatPointer:
				Pointer--;
				break;
			case BFInstruction.IncrementValue:
				Memory[Pointer]++;
				break;
			case BFInstruction.DecrementValue:
				Memory[Pointer]--;
				break;
			case BFInstruction.OutputCharacter:
				System.Console.Write((char)Memory[Pointer]);
				break;
			case BFInstruction.InputCharacter:
				Memory[Pointer] = System.Console.Read();
				break;
			case BFInstruction.JumpToClose:
				if (Memory[Pointer] == 0)
				{
					// 対応する]までPCを進める
					int nestingDepth = 1;
					while (nestingDepth > 0)
					{
						ProgramCounter++;
						if (instructions[ProgramCounter] == BFInstruction.JumpToClose) nestingDepth++;
						if (instructions[ProgramCounter] == BFInstruction.JumpToOpen) nestingDepth--;
					}
				}
				break;
			case BFInstruction.JumpToOpen:
				if (Memory[Pointer] != 0)
				{
					// 対応する]までPCを戻す
					int nestingDepth = 1;
					while (nestingDepth > 0)
					{
						ProgramCounter--;
						if (instructions[ProgramCounter] == BFInstruction.JumpToOpen) nestingDepth++;
						if (instructions[ProgramCounter] == BFInstruction.JumpToClose) nestingDepth--;
					}
				}
				break;
		}
	}

	private BFInstruction[] Parse(string code)
	{
		string pattern = string.Join('|', InstructionSet.Values);
		return Regex.Split(code, $"({pattern})")
			.Where(s => s != string.Empty)
			.Select(i => InstructionSet.First(pair => pair.Value == i).Key)
			.ToArray();
	}
}
