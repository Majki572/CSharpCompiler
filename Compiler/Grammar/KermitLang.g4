grammar KermitLang;

start: base_statement*;

base_statement: statement;

statement:
	'DECLARE' (
		INTEGER_NAME
		| SHORT_NAME
		| LONG_NAME
		| BOOL_NAME
		| DOUBLE_NAME
		| FLOAT_NAME
		| STRING_NAME
		| NUMBER_NAME
	) ID (expression) ';' # declare
	| 'ASSIGN' ID (
		expression 
	) ';' #assign
	| 'PRINT' (expression) ';' #print 
	| 'READ' ID ';'  #read
	;


expression:
	expression1 ADD expression		# expression_base_add
	| expression1 SUB expression	# expression_base_sub
	| expression1 # expression1Empty;
expression1:
	expression2 MUL expression1		# expression_base_mul
	| expression2 DIV expression1	# expression_base_div
	| expression2					# expression2Empty;
expression2:
	expression3 'AND' expression2	# and
	| expression3 'OR' expression2	# or
	| expression3 'XOR' expression2	# xor
	| expression3 'NEG' expression2	# neg
	| expression3					# expression4Empty;
expression3:
	 ID					# id
	| BOOL					# bool
	| NUMBER				# number
	| STRING                # string	
	| '(' expression ')'	# expressionInParens;

NUMBER: ('0' ..'9')+ ('.' ('0' ..'9')+)?;

BOOL: ('true' | 'false');

STRING: '"' (~["\r\n] | '""')* '"'; 

SHORT_NAME: 'SHORT';
INTEGER_NAME: 'INTEGER';
LONG_NAME: 'LONG';
FLOAT_NAME: 'FLOAT';
DOUBLE_NAME: 'DOUBLE';
REAL_NAME: 'REAL';
BOOL_NAME: 'BOOL';

STRING_NAME: 'STRING'; // Marked for string type handling

NUMBER_NAME:
	'NUMBER'; // Marked for float32, float64, double, and decimal

ID: ('a' ..'z' | '_')+;

ADD: '+';

SUB: '-';

MUL: '*';

DIV: '/';

COMMENT: '//' ~ [\r\n]* -> skip;

WS: [ \t\r\n] -> skip;