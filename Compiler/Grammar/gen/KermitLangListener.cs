//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/jakub/Documents/CSharpCompiler/Compiler/Grammar/KermitLang.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="KermitLangParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IKermitLangListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KermitLangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] KermitLangParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KermitLangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] KermitLangParser.StartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KermitLangParser.base_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBase_statement([NotNull] KermitLangParser.Base_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KermitLangParser.base_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBase_statement([NotNull] KermitLangParser.Base_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>declare</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclare([NotNull] KermitLangParser.DeclareContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>declare</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclare([NotNull] KermitLangParser.DeclareContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssign([NotNull] KermitLangParser.AssignContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssign([NotNull] KermitLangParser.AssignContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrint([NotNull] KermitLangParser.PrintContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrint([NotNull] KermitLangParser.PrintContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>print_string</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrint_string([NotNull] KermitLangParser.Print_stringContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>print_string</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrint_string([NotNull] KermitLangParser.Print_stringContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRead([NotNull] KermitLangParser.ReadContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRead([NotNull] KermitLangParser.ReadContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression_base_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression_base_add([NotNull] KermitLangParser.Expression_base_addContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression_base_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression_base_add([NotNull] KermitLangParser.Expression_base_addContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression_base_sub</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression_base_sub([NotNull] KermitLangParser.Expression_base_subContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression_base_sub</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression_base_sub([NotNull] KermitLangParser.Expression_base_subContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression1Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression1Empty([NotNull] KermitLangParser.Expression1EmptyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression1Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression1Empty([NotNull] KermitLangParser.Expression1EmptyContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression_base_mul</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression_base_mul([NotNull] KermitLangParser.Expression_base_mulContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression_base_mul</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression_base_mul([NotNull] KermitLangParser.Expression_base_mulContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression_base_div</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression_base_div([NotNull] KermitLangParser.Expression_base_divContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression_base_div</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression_base_div([NotNull] KermitLangParser.Expression_base_divContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression2Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression2Empty([NotNull] KermitLangParser.Expression2EmptyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression2Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression2Empty([NotNull] KermitLangParser.Expression2EmptyContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnd([NotNull] KermitLangParser.AndContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnd([NotNull] KermitLangParser.AndContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>or</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOr([NotNull] KermitLangParser.OrContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>or</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOr([NotNull] KermitLangParser.OrContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>xor</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterXor([NotNull] KermitLangParser.XorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>xor</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitXor([NotNull] KermitLangParser.XorContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>neg</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNeg([NotNull] KermitLangParser.NegContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>neg</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNeg([NotNull] KermitLangParser.NegContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expression4Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression4Empty([NotNull] KermitLangParser.Expression4EmptyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expression4Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression4Empty([NotNull] KermitLangParser.Expression4EmptyContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt([NotNull] KermitLangParser.IntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt([NotNull] KermitLangParser.IntContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFloat([NotNull] KermitLangParser.FloatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFloat([NotNull] KermitLangParser.FloatContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterId([NotNull] KermitLangParser.IdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitId([NotNull] KermitLangParser.IdContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>bool</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBool([NotNull] KermitLangParser.BoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>bool</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBool([NotNull] KermitLangParser.BoolContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>number</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] KermitLangParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>number</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] KermitLangParser.NumberContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expressionInParens</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expressionInParens</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>stringId</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringId([NotNull] KermitLangParser.StringIdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringId</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringId([NotNull] KermitLangParser.StringIdContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>string_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString_add([NotNull] KermitLangParser.String_addContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>string_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString_add([NotNull] KermitLangParser.String_addContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] KermitLangParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] KermitLangParser.StringContext context);
}
