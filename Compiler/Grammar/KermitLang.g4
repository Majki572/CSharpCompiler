grammar KermitLang;

prog: base_statement*;

base_statement: statement | function_def;

statement:
	'DECLARE' (
		INTEGER_NAME
		| REAL_NAME
		| BOOL_NAME
		| STRING_NAME
		| NUMBER_NAME
	) ID (INTEGER | REAL | BOOL | STRING | NUMBER) ';'
	// Added STRING_NAME and NUMBER_NAME for string and number types
	| 'ASSIGN' ID (
		INTEGER
		| REAL
		| BOOL
		| ID
		| STRING
		| NUMBER
		| expression
	) ';' // Added handling for STRING and NUMBER types
	| 'SELECT' (INTEGER | REAL | BOOL | ID | STRING | NUMBER) ';' // Added STRING and NUMBER types
	| 'READ_TO' ID ';'
	| 'IF' (ID | BOOL) block ';'
	| 'CALL' ID '(' parameter* ')' ';';

parameter: ID '|';

function_def: ID '(' parameter_def* ')' block ';';

parameter_def: (
		INTEGER_NAME
		| REAL_NAME
		| BOOL_NAME
		| STRING_NAME
		| NUMBER_NAME
	) ID '|'; // Added STRING_NAME and NUMBER_NAME

block: '[' statement* ']';

expression:
	expression_base					# expression_base_wrap // Wrap base expressions
	| expression 'AND' expression	# logic_and // Added AND operation (consider short-circuit)
	| expression 'OR' expression	# logic_or // Added OR operation (consider short-circuit)
	| expression 'XOR' expression	# logic_xor // Added XOR operation
	| 'NEG' expression				# logic_neg; // Added NEG operation

expression_base: (ID | INTEGER | REAL | STRING | NUMBER) ADD (
		ID
		| INTEGER
		| REAL
		| STRING
		| NUMBER
	) # expression_base_add // Added STRING and NUMBER types
	| (ID | INTEGER | REAL | STRING | NUMBER) MUL (
		ID
		| INTEGER
		| REAL
		| STRING
		| NUMBER
	) # expression_base_mul // Added STRING and NUMBER types
	| (ID | INTEGER | REAL | STRING | NUMBER) SUB (
		ID
		| INTEGER
		| REAL
		| STRING
		| NUMBER
	) # expression_base_sub // Added STRING and NUMBER types
	| (ID | INTEGER | REAL | STRING | NUMBER) DIV (
		ID
		| INTEGER
		| REAL
		| STRING
		| NUMBER
	) # expression_base_div; // Added STRING and NUMBER types

INTEGER: ('0' ..'9')+;

REAL: ('0' ..'9')+ '.' ('0' ..'9')+;

BOOL: ('true' | 'false');

STRING: '"' (~["\r\n] | '""')* '"'; // Added STRING type

NUMBER: ('0' ..'9')+ ('.' ('0' ..'9')+)? (
		('e' | 'E') ('+' | '-')? ('0' ..'9')+
	)?; // Added for different precision numbers

INTEGER_NAME: 'INTEGER';

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