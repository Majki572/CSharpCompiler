grammar MergedX;

// Start
start: (stat? ';' NEWLINE)* | (statement? NEWLINE)* EOF;

// Twierdzenia
stat: assignStat | write | readStat;
statement: assign | read | write;

// Wczytywanie
read: READ ID;
readStat: READ ID;

// Wypisywanie
write: WRITE expr0 | WRITE expression;

// Przypisania
assignStat: TYPE ID '=' expr0 | 'string' ID '=' STRING;
assign: (INT_TYPE | FLOAT_TYPE) ID '=' expression
	| BOOL_TYPE ID '=' expressionBool
	| STRING_TYPE ID '=' stringExpression;

// Wyrażenia arytmetyczne
expr0: expr1 | expr1 op1*;
op1: ADD expr1 # add | SUB expr1 # sub;
expr1: expr2 | expr2 op2*;
op2: MUL expr2 # mul | DIV expr2 # div;
expr2:
	INT				# int
	| FLOAT			# float
	| ID			# id
	| '(' expr0 ')'	# exprInParens;

// Fragment AraAra
expression: expression1 (ADD | SUB) expression1;
expression1: expression2 (MUL | DIV) expression2;
expression2:
	expression3 (LT | GT | LE | GE | EQ | NE) expression3;
expression3: expression4 (AND | OR) expression4;
expression4: INT | FLOAT | ID | '(' expression ')';

// Boole
expressionBool: expressionBool1 (AND | OR) expressionBool1;
expressionBool1: expressionBool2 (EQ | NE) expressionBool2;
expressionBool2: BOOL | ID | '(' expressionBool ')';

// Stringi
stringExpression: stringExpression1 (ADD) stringExpression1;
stringExpression1: STRING | ID | '(' stringExpression ')';

// Typy i wartości
TYPE: INT_TYPE | FLOAT_TYPE | BOOL_TYPE | STRING_TYPE;
INT_TYPE: 'int';
FLOAT_TYPE: 'float';
BOOL_TYPE: 'bool';
STRING_TYPE: 'string';
ARRAY: 'array';
ID: [a-zA-Z_][a-zA-Z0-9_]*;
INT: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
STRING: '"' ('a' ..'z' | 'A' ..'Z' | '0' ..'9' | ' ')* '"';
VALUE: INT | FLOAT | STRING | BOOL;

// Operatory
AND: '&&';
OR: '||';
ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';
LT: '<';
GT: '>';
LE: '<=';
GE: '>=';
EQ: '==';
NE: '!=';

// I/O i białe znaki
READ: 'read';
WRITE: 'write';
NEWLINE: '\r'? '\n' | '\r';
WS: [ \t\r\n]+ -> skip;