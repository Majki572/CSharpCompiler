grammar KermitLang;

start: base_statement*;

base_statement: statement;

statement:
	type ID (expression) ';'				# declare
	| ID '=' (expression) ';'				# assign
	| PRINT L_PAR (expression) P_PAR ';'	# print
	| READ L_PAR ID P_PAR ';'				# read
	| if_statement ';'						# ifBlock
	| while_statement ';'					# whileBlock
	| struct_definition ';'					# structDefinition;

type:
	INTEGER_NAME
	| SHORT_NAME
	| LONG_NAME
	| BOOL_NAME
	| DOUBLE_NAME
	| FLOAT_NAME
	| STRING_NAME
	| NUMBER_NAME;

expression:
	expression1 ADD expression		# expressionBaseAdd
	| expression1 SUB expression	# expressionBaseSub
	| expression1					# expression1Empty;
expression1:
	expression2 MUL expression1		# expressionBaseMul
	| expression2 DIV expression1	# expressionBaseDiv
	| expression2					# expression2Empty;
expression2:
	expression3 'AND' expression2	# and
	| expression3 'OR' expression2	# or
	| expression3 'XOR' expression2	# xor
	| expression3 'NEG' expression2	# neg
	| expression3					# expression4Empty;
expression3:
	ID							# id
	| BOOL						# bool
	| NUMBER					# number
	| STRING					# string
	| L_PAR expression P_PAR	# expressionInParens;

if_statement:
	IF L_PAR (ID | BOOL | (expression2)) P_PAR L_CURL statement_block P_CURL (
		ELSE L_CURL statement_block P_CURL
	)?;

while_statement:
	WHILE L_PAR (expression) P_PAR L_CURL statement_block P_CURL # whileLoop;

function_definition:
	type ID L_PAR parameter_list P_PAR L_CURL statement_block P_CURL # functionDef;

parameter_list:
									# noParameters
	| parameter (',' parameter)*	# parameterList;

parameter: type ID # parameterDeclare;

function_call: ID L_PAR argument_list? P_PAR # functionInvoke;

argument_list: expression (',' expression)* # argumentList;

statement_block: L_CURL base_statement* P_CURL;

struct_definition:
	'struct' ID L_CURL (struct_body) P_CURL # structDef;

struct_body: type ID ';' (type ID ';')* # structMembers;

NUMBER: ('0' ..'9')+ ('.' ('0' ..'9')+)?;

BOOL: ('true' | 'false');

STRING: '"' (~["\r\n] | '""')* '"';

SHORT_NAME: 'short';
INTEGER_NAME: 'int';
LONG_NAME: 'long';
FLOAT_NAME: 'float';
DOUBLE_NAME: 'double';
REAL_NAME: 'real';
BOOL_NAME: 'bool';

PRINT: 'print';
READ: 'read';

IF: 'if';
ELSE: 'else';
WHILE: 'while';
STRUCT: 'struct';

STRING_NAME: 'STRING'; // Marked for string type handling

NUMBER_NAME:
	'NUMBER'; // Marked for float32, float64, double, and decimal

ID: ('a' ..'z' | '_')+;

ADD: '+';

SUB: '-';

MUL: '*';

DIV: '/';

L_PAR: '(';
P_PAR: ')';

L_CURL: '{';
P_CURL: '}';

COMMENT: '//' ~ [\r\n]* -> skip;

WS: [ \t\r\n] -> skip;