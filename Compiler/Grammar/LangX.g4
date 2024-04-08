grammar LangX;

start: ( stat? ';' NEWLINE)*;

stat: assign | write | read;

assign:
	TYPE WS ID '=' expr0 # expr ; // nie używamy bo jest ogarnięte z automatu

reassign: ID '=' expr0;

write: WRITE WS expr0;

read: READ WS ID;

// dodawanie i odejmowanie
expr0: expr1 | expr1 op1*;

op1: ADD expr1 # add | SUB expr1 # sub;

// mnożenie i dzielenie
expr1: expr2 | expr2 op2*;

op2: MUL expr2 # mul | DIV expr2 # div;

expr2:
	INT				# int
	| FLOAT			# float
	| ID			# id
	| STRING		# string
	| '(' expr0 ')'	# exprInParens;

// Wyrażenia
TYPE: 'int' | 'float' | 'string';
ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';
STRING: '"' ('a' ..'z' | 'A' ..'Z' | '0' ..'9' | ' ')* '"';

WRITE: 'write';

READ: 'read';

ID: ('a' ..'z' | 'A' ..'Z')+;

INT: '0' ..'9'+;

FLOAT: '0' ..'9'+ '.' '0' ..'9'+;

NEWLINE: '\r'? '\n';

WS: (' ' | '\t')+;