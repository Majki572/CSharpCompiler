//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from f:/GitHubRepository/CSharpCompiler/Compiler/Grammar/KermitLang.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class KermitLangLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, INTEGER=11, REAL=12, BOOL=13, STRING=14, NUMBER=15, INTEGER_NAME=16, 
		REAL_NAME=17, BOOL_NAME=18, STRING_NAME=19, NUMBER_NAME=20, ID=21, ADD=22, 
		SUB=23, MUL=24, DIV=25, COMMENT=26, WS=27;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "INTEGER", "REAL", "BOOL", "STRING", "NUMBER", "INTEGER_NAME", 
		"REAL_NAME", "BOOL_NAME", "STRING_NAME", "NUMBER_NAME", "ID", "ADD", "SUB", 
		"MUL", "DIV", "COMMENT", "WS"
	};


	public KermitLangLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public KermitLangLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'DECLARE'", "';'", "'ASSIGN'", "'PRINT'", "'READ_TO'", "'AND'", 
		"'OR'", "'XOR'", "'('", "')'", null, null, null, null, null, "'INTEGER'", 
		"'REAL'", "'BOOL'", "'STRING'", "'NUMBER'", null, "'+'", "'-'", "'*'", 
		"'/'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, "INTEGER", 
		"REAL", "BOOL", "STRING", "NUMBER", "INTEGER_NAME", "REAL_NAME", "BOOL_NAME", 
		"STRING_NAME", "NUMBER_NAME", "ID", "ADD", "SUB", "MUL", "DIV", "COMMENT", 
		"WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "KermitLang.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static KermitLangLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,27,223,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,1,0,1,0,1,0,1,0,
		1,0,1,0,1,0,1,0,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,
		3,1,3,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,7,
		1,7,1,7,1,7,1,8,1,8,1,9,1,9,1,10,4,10,103,8,10,11,10,12,10,104,1,11,4,
		11,108,8,11,11,11,12,11,109,1,11,1,11,4,11,114,8,11,11,11,12,11,115,1,
		12,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,12,3,12,127,8,12,1,13,1,13,1,13,
		1,13,5,13,133,8,13,10,13,12,13,136,9,13,1,13,1,13,1,14,4,14,141,8,14,11,
		14,12,14,142,1,14,1,14,4,14,147,8,14,11,14,12,14,148,3,14,151,8,14,1,14,
		1,14,3,14,155,8,14,1,14,4,14,158,8,14,11,14,12,14,159,3,14,162,8,14,1,
		15,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,16,1,16,1,16,1,16,1,16,1,17,1,
		17,1,17,1,17,1,17,1,18,1,18,1,18,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,
		19,1,19,1,19,1,19,1,20,4,20,197,8,20,11,20,12,20,198,1,21,1,21,1,22,1,
		22,1,23,1,23,1,24,1,24,1,25,1,25,1,25,1,25,5,25,213,8,25,10,25,12,25,216,
		9,25,1,25,1,25,1,26,1,26,1,26,1,26,0,0,27,1,1,3,2,5,3,7,4,9,5,11,6,13,
		7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,
		39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,1,0,6,3,0,10,10,13,13,
		34,34,2,0,69,69,101,101,2,0,43,43,45,45,2,0,95,95,97,122,2,0,10,10,13,
		13,3,0,9,10,13,13,32,32,236,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,
		0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,
		0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,
		1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,
		0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,
		1,0,0,0,0,53,1,0,0,0,1,55,1,0,0,0,3,63,1,0,0,0,5,65,1,0,0,0,7,72,1,0,0,
		0,9,78,1,0,0,0,11,86,1,0,0,0,13,90,1,0,0,0,15,93,1,0,0,0,17,97,1,0,0,0,
		19,99,1,0,0,0,21,102,1,0,0,0,23,107,1,0,0,0,25,126,1,0,0,0,27,128,1,0,
		0,0,29,140,1,0,0,0,31,163,1,0,0,0,33,171,1,0,0,0,35,176,1,0,0,0,37,181,
		1,0,0,0,39,188,1,0,0,0,41,196,1,0,0,0,43,200,1,0,0,0,45,202,1,0,0,0,47,
		204,1,0,0,0,49,206,1,0,0,0,51,208,1,0,0,0,53,219,1,0,0,0,55,56,5,68,0,
		0,56,57,5,69,0,0,57,58,5,67,0,0,58,59,5,76,0,0,59,60,5,65,0,0,60,61,5,
		82,0,0,61,62,5,69,0,0,62,2,1,0,0,0,63,64,5,59,0,0,64,4,1,0,0,0,65,66,5,
		65,0,0,66,67,5,83,0,0,67,68,5,83,0,0,68,69,5,73,0,0,69,70,5,71,0,0,70,
		71,5,78,0,0,71,6,1,0,0,0,72,73,5,80,0,0,73,74,5,82,0,0,74,75,5,73,0,0,
		75,76,5,78,0,0,76,77,5,84,0,0,77,8,1,0,0,0,78,79,5,82,0,0,79,80,5,69,0,
		0,80,81,5,65,0,0,81,82,5,68,0,0,82,83,5,95,0,0,83,84,5,84,0,0,84,85,5,
		79,0,0,85,10,1,0,0,0,86,87,5,65,0,0,87,88,5,78,0,0,88,89,5,68,0,0,89,12,
		1,0,0,0,90,91,5,79,0,0,91,92,5,82,0,0,92,14,1,0,0,0,93,94,5,88,0,0,94,
		95,5,79,0,0,95,96,5,82,0,0,96,16,1,0,0,0,97,98,5,40,0,0,98,18,1,0,0,0,
		99,100,5,41,0,0,100,20,1,0,0,0,101,103,2,48,57,0,102,101,1,0,0,0,103,104,
		1,0,0,0,104,102,1,0,0,0,104,105,1,0,0,0,105,22,1,0,0,0,106,108,2,48,57,
		0,107,106,1,0,0,0,108,109,1,0,0,0,109,107,1,0,0,0,109,110,1,0,0,0,110,
		111,1,0,0,0,111,113,5,46,0,0,112,114,2,48,57,0,113,112,1,0,0,0,114,115,
		1,0,0,0,115,113,1,0,0,0,115,116,1,0,0,0,116,24,1,0,0,0,117,118,5,116,0,
		0,118,119,5,114,0,0,119,120,5,117,0,0,120,127,5,101,0,0,121,122,5,102,
		0,0,122,123,5,97,0,0,123,124,5,108,0,0,124,125,5,115,0,0,125,127,5,101,
		0,0,126,117,1,0,0,0,126,121,1,0,0,0,127,26,1,0,0,0,128,134,5,34,0,0,129,
		133,8,0,0,0,130,131,5,34,0,0,131,133,5,34,0,0,132,129,1,0,0,0,132,130,
		1,0,0,0,133,136,1,0,0,0,134,132,1,0,0,0,134,135,1,0,0,0,135,137,1,0,0,
		0,136,134,1,0,0,0,137,138,5,34,0,0,138,28,1,0,0,0,139,141,2,48,57,0,140,
		139,1,0,0,0,141,142,1,0,0,0,142,140,1,0,0,0,142,143,1,0,0,0,143,150,1,
		0,0,0,144,146,5,46,0,0,145,147,2,48,57,0,146,145,1,0,0,0,147,148,1,0,0,
		0,148,146,1,0,0,0,148,149,1,0,0,0,149,151,1,0,0,0,150,144,1,0,0,0,150,
		151,1,0,0,0,151,161,1,0,0,0,152,154,7,1,0,0,153,155,7,2,0,0,154,153,1,
		0,0,0,154,155,1,0,0,0,155,157,1,0,0,0,156,158,2,48,57,0,157,156,1,0,0,
		0,158,159,1,0,0,0,159,157,1,0,0,0,159,160,1,0,0,0,160,162,1,0,0,0,161,
		152,1,0,0,0,161,162,1,0,0,0,162,30,1,0,0,0,163,164,5,73,0,0,164,165,5,
		78,0,0,165,166,5,84,0,0,166,167,5,69,0,0,167,168,5,71,0,0,168,169,5,69,
		0,0,169,170,5,82,0,0,170,32,1,0,0,0,171,172,5,82,0,0,172,173,5,69,0,0,
		173,174,5,65,0,0,174,175,5,76,0,0,175,34,1,0,0,0,176,177,5,66,0,0,177,
		178,5,79,0,0,178,179,5,79,0,0,179,180,5,76,0,0,180,36,1,0,0,0,181,182,
		5,83,0,0,182,183,5,84,0,0,183,184,5,82,0,0,184,185,5,73,0,0,185,186,5,
		78,0,0,186,187,5,71,0,0,187,38,1,0,0,0,188,189,5,78,0,0,189,190,5,85,0,
		0,190,191,5,77,0,0,191,192,5,66,0,0,192,193,5,69,0,0,193,194,5,82,0,0,
		194,40,1,0,0,0,195,197,7,3,0,0,196,195,1,0,0,0,197,198,1,0,0,0,198,196,
		1,0,0,0,198,199,1,0,0,0,199,42,1,0,0,0,200,201,5,43,0,0,201,44,1,0,0,0,
		202,203,5,45,0,0,203,46,1,0,0,0,204,205,5,42,0,0,205,48,1,0,0,0,206,207,
		5,47,0,0,207,50,1,0,0,0,208,209,5,47,0,0,209,210,5,47,0,0,210,214,1,0,
		0,0,211,213,8,4,0,0,212,211,1,0,0,0,213,216,1,0,0,0,214,212,1,0,0,0,214,
		215,1,0,0,0,215,217,1,0,0,0,216,214,1,0,0,0,217,218,6,25,0,0,218,52,1,
		0,0,0,219,220,7,5,0,0,220,221,1,0,0,0,221,222,6,26,0,0,222,54,1,0,0,0,
		15,0,104,109,115,126,132,134,142,148,150,154,159,161,198,214,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
