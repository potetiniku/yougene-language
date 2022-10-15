namespace YougeneLanguage.Main;

internal class Program
{
	private static void Main(string[] args)
	{
		if (args.Length != 1)
		{
			Console.WriteLine("使い方: 第1引数に実行するファイルのパスを指定してください。");
			Console.WriteLine(@"例: .\YougeneLanguage.exe example.yg");
			return;
		}

		var interpreter = new BFInterpreter(new Dictionary<BFInstruction, string>()
		{
			{ BFInstruction.AdvancePointer, "もん!" },
			{ BFInstruction.RetreatPointer, "capa" },
			{ BFInstruction.IncrementValue, "ゴ" },
			{ BFInstruction.DecrementValue, "ちゃんか" },
			{ BFInstruction.OutputCharacter, "だし!" },
			{ BFInstruction.InputCharacter, "安直だね～" },
			{ BFInstruction.JumpToClose, "あ!今お蕎麦のエール貰っちゃった!" },
			{ BFInstruction.JumpToOpen, "アニャちゃんそれうどんだよ!" }
		}, 1024);

		interpreter.Execute(File.ReadAllText(args[0]));
	}
}
