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
	/// Visit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] KermitLangParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>if</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf([NotNull] KermitLangParser.IfContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>while</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile([NotNull] KermitLangParser.WhileContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction([NotNull] KermitLangParser.FunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>struct</c>
	/// labeled alternative in <see cref="KermitLangParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStruct([NotNull] KermitLangParser.StructContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] KermitLangParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionBaseAdd</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionBaseAdd([NotNull] KermitLangParser.ExpressionBaseAddContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionBaseSub</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionBaseSub([NotNull] KermitLangParser.ExpressionBaseSubContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expression1Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression1Empty([NotNull] KermitLangParser.Expression1EmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionBaseMul</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionBaseMul([NotNull] KermitLangParser.ExpressionBaseMulContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionBaseDiv</c>
	/// labeled alternative in <see cref="KermitLangParser.expression1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionBaseDiv([NotNull] KermitLangParser.ExpressionBaseDivContext context);
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
	/// Visit a parse tree produced by the <c>expression3Empty</c>
	/// labeled alternative in <see cref="KermitLangParser.expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression3Empty([NotNull] KermitLangParser.Expression3EmptyContext context);
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
	/// Visit a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] KermitLangParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionInParens</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionCall</c>
	/// labeled alternative in <see cref="KermitLangParser.expression3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] KermitLangParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ifStatement</c>
	/// labeled alternative in <see cref="KermitLangParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] KermitLangParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>equal</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqual([NotNull] KermitLangParser.EqualContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notEqual</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotEqual([NotNull] KermitLangParser.NotEqualContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lessThan</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLessThan([NotNull] KermitLangParser.LessThanContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>greaterThan</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreaterThan([NotNull] KermitLangParser.GreaterThanContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lessThanEqual</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLessThanEqual([NotNull] KermitLangParser.LessThanEqualContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>greaterThanEqual</c>
	/// labeled alternative in <see cref="KermitLangParser.compareStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreaterThanEqual([NotNull] KermitLangParser.GreaterThanEqualContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>whileStatement</c>
	/// labeled alternative in <see cref="KermitLangParser.while_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] KermitLangParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>whileCondition</c>
	/// labeled alternative in <see cref="KermitLangParser.while_condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileCondition([NotNull] KermitLangParser.WhileConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionDef</c>
	/// labeled alternative in <see cref="KermitLangParser.function_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDef([NotNull] KermitLangParser.FunctionDefContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>noParameters</c>
	/// labeled alternative in <see cref="KermitLangParser.parameter_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNoParameters([NotNull] KermitLangParser.NoParametersContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parameterList</c>
	/// labeled alternative in <see cref="KermitLangParser.parameter_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] KermitLangParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] KermitLangParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionInvoke</c>
	/// labeled alternative in <see cref="KermitLangParser.function_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionInvoke([NotNull] KermitLangParser.FunctionInvokeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.argument_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument_list([NotNull] KermitLangParser.Argument_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KermitLangParser.statement_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement_block([NotNull] KermitLangParser.Statement_blockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ifStatementBlock</c>
	/// labeled alternative in <see cref="KermitLangParser.statement_block_if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatementBlock([NotNull] KermitLangParser.IfStatementBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>whileStatementBlock</c>
	/// labeled alternative in <see cref="KermitLangParser.statement_block_while"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatementBlock([NotNull] KermitLangParser.WhileStatementBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionStatementBlock</c>
	/// labeled alternative in <see cref="KermitLangParser.statement_block_function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionStatementBlock([NotNull] KermitLangParser.FunctionStatementBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionReturnStatement</c>
	/// labeled alternative in <see cref="KermitLangParser.function_return_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionReturnStatement([NotNull] KermitLangParser.FunctionReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>structDef</c>
	/// labeled alternative in <see cref="KermitLangParser.struct_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDef([NotNull] KermitLangParser.StructDefContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>structMembers</c>
	/// labeled alternative in <see cref="KermitLangParser.struct_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructMembers([NotNull] KermitLangParser.StructMembersContext context);
}