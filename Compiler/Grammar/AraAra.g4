grammar AraAra;

start: ( statement? NEWLINE )* EOF;

statement: assign
         | read
         | write
         ;

// wczytanie 
read : READ ID;

// wypisanie
write : WRITE expression;

// przypisanie
assign : (INT_TYPE | FLOAT_TYPE) ID '=' expression
    | BOOL_TYPE ID '=' expressionBool
    | STRING_TYPE ID '=' stringExpression
;

// działania na liczbach 
expression: expression1 (ADD|SUB) expression1;
expression1: expression2 (MUL|DIV) expression2;
expression2: expression3 (LT|GT|LE|GE|EQ|NE) expression3;
expression3: expression4 (AND|OR) expression4;
expression4: INT | FLOAT | ID | '(' expression ')';

// działania na boolach
expressionBool: expressionBool1 (AND|OR) expressionBool1;
expressionBool1: expressionBool2 (EQ|NE) expressionBool2;
expressionBool2: BOOL | ID | '(' expressionBool ')';

// dzoałania na stringach
stringExpression: stringExpression1 (ADD) stringExpression1;
stringExpression1: STRING | ID | '(' stringExpression ')';

// tablice
array:  ARRAY '<' TYPE '>' ID '[' INT ']'
    | ARRAY '<' TYPE '>' ID '[' INT ']' '=' '{' (VALUE (',' VALUE)*)? '}' 
    ;

// macierze
matrix:  ARRAY '<' TYPE '>' ID '[' INT ']' '[' INT ']'
    | ARRAY '<' TYPE '>' ID '[' INT ']' '[' INT ']' '=' '{' (INT (',' INT)*)? '}' 
    ;

// logiczne

// wartości
READ: 'read';
WRITE: 'write';
INT_TYPE: 'int';
FLOAT_TYPE: 'float';
BOOL_TYPE: 'bool';
STRING_TYPE: 'string';
TYPE: INT_TYPE | FLOAT_TYPE | BOOL_TYPE | STRING_TYPE;

ARRAY: 'array';


ID: [a-zA-Z_][a-zA-Z0-9_]*;
INT: [0-9]+;
FLOAT: [0-9]+'.'[0-9]+;
BOOL: 'true' | 'false';
STRING: '"' ('a' ..'z' | 'A' ..'Z' | '0' ..'9' | ' ')* '"';
VALUE: INT | FLOAT | STRING | BOOL;

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

NEWLINE: '\r'? '\n' | '\r';
WS: [ \t]+ -> skip;