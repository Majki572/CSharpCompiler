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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="KermitLangParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IKermitLangVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] KermitLangParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.base_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBase_statement([NotNull] KermitLangParser.Base_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>declare</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclare([NotNull] KermitLangParser.DeclareContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assign</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssign([NotNull] KermitLangParser.AssignContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>print</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint([NotNull] KermitLangParser.PrintContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>read</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRead([NotNull] KermitLangParser.ReadContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>stringId</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringId([NotNull] KermitLangParser.StringIdContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>string_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString_add([NotNull] KermitLangParser.String_addContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="KermitLangParser.expressionString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] KermitLangParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression_base_add</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_base_add([NotNull] KermitLangParser.Expression_base_addContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression_base_sub</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_base_sub([NotNull] KermitLangParser.Expression_base_subContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression1Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression1Empty([NotNull] KermitLangParser.Expression1EmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression_base_mul</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_base_mul([NotNull] KermitLangParser.Expression_base_mulContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression_base_div</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_base_div([NotNull] KermitLangParser.Expression_base_divContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression2Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression2Empty([NotNull] KermitLangParser.Expression2EmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnd([NotNull] KermitLangParser.AndContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>or</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOr([NotNull] KermitLangParser.OrContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>xor</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitXor([NotNull] KermitLangParser.XorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>neg</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNeg([NotNull] KermitLangParser.NegContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression4Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression4Empty([NotNull] KermitLangParser.Expression4EmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt([NotNull] KermitLangParser.IntContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloat([NotNull] KermitLangParser.FloatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] KermitLangParser.IdContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bool</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] KermitLangParser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>number</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] KermitLangParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionInParens</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context);
}
