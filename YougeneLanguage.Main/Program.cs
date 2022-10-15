namespace YougeneLanguage.Main;

internal class Program
{
	private static void Main(string[] args)
	{
		var interpreter = new BFInterpreter(new Dictionary<BFInstruction, string>()
		{
			{ BFInstruction.AdvancePointer, "ポチ" },
			{ BFInstruction.RetreatPointer, "capa" },
			{ BFInstruction.IncrementValue, "もん!" },
			{ BFInstruction.DecrementValue, "ちゃんか" },
			{ BFInstruction.OutputCharacter, "だし!" },
			{ BFInstruction.InputCharacter, "安直だね～" },
			{ BFInstruction.JumpToClose, "あ!今お蕎麦のエール貰っちゃった!" },
			{ BFInstruction.JumpToOpen, "アニャちゃんそれうどんだよ!" }
		}, 1024);

		interpreter.Execute(File.ReadAllText(args[0]));
	}
}
