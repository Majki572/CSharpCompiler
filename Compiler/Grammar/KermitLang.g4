grammar KermitLang;

start: base_statement*;

base_statement: statement;

statement:
	'DECLARE' (
		INTEGER_NAME
		| REAL_NAME
		| BOOL_NAME
		| STRING_NAME
		| NUMBER_NAME
	) ID (expression | expressionString) ';' # declare
	// Added STRING_NAME and NUMBER_NAME for string and number types
	| 'ASSIGN' ID (
		expression | expressionString
	) ';' #assign // Added handling for STRING and NUMBER types 
	| 'PRINT' (expression) ';' #print // Added STRING and NUMBER types
	| 'PRINT' STRING ';' #print_string
	| 'READ_TO' ID ';'  #read
	//| 'IF' (ID | BOOL) block ';' #if
	//| 'CALL' ID '(' parameter* ')' ';' #call
	;

//parameter: ID '|';

//function_def: ID '(' parameter_def* ')' block ';';

//parameter_def: ( INTEGER_NAME | REAL_NAME | BOOL_NAME | STRING_NAME | NUMBER_NAME ) ID '|'; //
// Added STRING_NAME and NUMBER_NAME

//block: '[' statement* ']';
expression:
	expression1 ADD expression		# expression_base_add
	| expression1 SUB expression	# expression_base_sub
	// ? | STRING (ADD STRING)*          # string
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
	INTEGER					# int
	| REAL					# float
	| ID					# id
	| BOOL					# bool
	| NUMBER				# number
	| '(' expression ')'	# expressionInParens;

//expression_base1: (ID | INTEGER | REAL | STRING | NUMBER) MUL ( ID | INTEGER | REAL | STRING |
// NUMBER | expression_base1 ) # expression_base_mul // Added STRING and NUMBER types | (ID |
// INTEGER | REAL | STRING | NUMBER) DIV ( ID | INTEGER | REAL | STRING | NUMBER | expression_base1
// ) # expression_base_div; // Added STRING and NUMBER types
expressionString: STRING			            # string
    | ID                                        # stringId
    |   expressionString ADD expressionString   # string_add
    ;
    

//expression_base1: (ID | INTEGER | REAL | STRING | NUMBER) MUL (
//		ID
//		| INTEGER
//		| REAL
//		| STRING
//		| NUMBER
//		| expression_base1
//	) # expression_base_mul // Added STRING and NUMBER types
//	| (ID | INTEGER | REAL | STRING | NUMBER) DIV (
//		ID
//		| INTEGER
//		| REAL
//		| STRING
//		| NUMBER
//		| expression_base1
//	) # expression_base_div; // Added STRING and NUMBER types

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