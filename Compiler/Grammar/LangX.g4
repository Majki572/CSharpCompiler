grammar LangX;

start: (statement)* EOF;

// Twierdzenia
statement: (assign | read | write) ';' NEWLINE
	| (assign | read | write) ';' EOF;

// Wczytywanie
read: READ ID;

// Wypisywanie
write: WRITE (expression | stringExpression);

// Przypisania
assign: (INT_TYPE | FLOAT_TYPE) ID '=' expression	# assignIntFloat
	| STRING_TYPE ID '=' stringExpression			# assignString
	| ID '=' (expression | stringExpression)		# assignVar;

// wyrażenia a ara ara
expression:
	expression1 ADD expression		# addIntFloat
	| expression1 SUB expression	# subIntFloat
	| expression1					# expression1Empty;
expression1:
	expression2 MUL expression1		# mulIntFloat
	| expression2 DIV expression1	# divIntFloat
	| expression2					# expression2Empty;
expression2:
	expression3 AND expression2		# andIntFloat
	| expression3 OR expression2	# orIntFloat
	| expression3 XOR expression2	# xorIntFloat
	| expression3 NEG expression2	# negIntFloat
	| expression3					# expression4Empty;
expression3:
	INT						# int
	| FLOAT					# float
	| ID					# idIntFloat
	| '(' expression ')'	# expressionInParens;

// Stringi
stringExpression:
	stringExpression1 ADD stringExpression	# addString
	| stringExpression1						# stringExpression1Empty;
stringExpression1:
	STRING						# string
	| ID						# idString
	| '(' stringExpression ')'	# stringExpressionInParens;

// Typy i wartości
INT_TYPE: 'int';
FLOAT_TYPE: 'float';
DOUBLE_TYPE: 'double';
STRING_TYPE: 'string';
READ: 'read';
WRITE: 'write';
STRING: '"' ( ~('\\' | '"'))* '"';
ID: [a-zA-Z_][a-zA-Z0-9_]*;
INT: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;

// Operatory
AND: '&&';
OR: '||';
XOR: '^';
NEG: '!';

ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';

// I/O i białe znaki
NEWLINE: '\r'? '\n' | '\r';
WS: [ \t\r\n]+ -> skip;