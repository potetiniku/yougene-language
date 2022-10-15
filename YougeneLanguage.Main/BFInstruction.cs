namespace YougeneLanguage.Main;

internal enum BFInstruction
{
	AdvancePointer,
	RetreatPointer,
	IncrementValue,
	DecrementValue,
	OutputCharacter,
	InputCharacter,
	JumpToClose,
	JumpToOpen
}
