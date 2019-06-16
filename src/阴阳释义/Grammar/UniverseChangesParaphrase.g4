grammar UniverseChangesParaphrase;

// ------------------------------------------------------------
// Parser Rules �﷨����
// ------------------------------------------------------------

 program
	:	expression
	;

expression 
	:	'(' expression ')'							# Parenthesis
	|	expression 'Ϊ' expression					# As
	|	expression '��Ӧ' expression				# Map
	|	TwelveGrowthProcess							# TwelveGrowthProcess
	|	SexagesimalSkyTrunkAndEarthBranch			# SexagesimalSkyTrunkAndEarthBranch
	|	EarthBranch									# EarthBranch
	|	SkyTrunk									# SkyTrunk
	|	FiveAttribute								# FiveAttribute
	|	DarkAndLight								# DarkAndLight
	|	TheInitialDigit								# TheInitialDigit
	;

compileUnit
	:	EOF
	;

// ------------------------------------------------------------
// Lexer Rules �ʷ�����
// ------------------------------------------------------------

// ------------------------------
// �����
// ------------------------------
MAP			:		'��Ӧ';		// һ��ԭ����ӳ��Ϊ��һ��ԭ����
AS			:		'Ϊ';		// ȡ�ô�ԭ�����ڲ����ԣ����磺��Ϊľ����Ϊ������Ϊ�׼���������ľ����������
AT			:		'��';		// 
ASSIGN		:		'��';		// Ϊ����ԭ������ϳ�һ���ϲ�ԭ����

// ------------------------------
// ԭ����
// ------------------------------

Name
	: (NameStart) (NameChar)*
	;

TwelveGrowthProcess
	:	('����'|'��ԡ'|'�ڴ�'|'�ٹ�'|'����'|'˥'|'��'|'��'|'Ĺ'|'��'|'̥'|'��')
	;

SexagesimalSkyTrunkAndEarthBranch
	:	'��'('��'|'��'|'��'|'��'|'��'|'��')
	|	'��'('��'|'��'|'��'|'δ'|'��'|'î')
	|	'��'('��'|'��'|'��'|'��'|'��'|'��')
	|	'��'('î'|'��'|'��'|'��'|'δ'|'��')
	|	'��'('��'|'��'|'��'|'��'|'��'|'��')
	|	'��'('��'|'î'|'��'|'��'|'��'|'δ')
	|	'��'('��'|'��'|'��'|'��'|'��'|'��')
	|	'��'('δ'|'��'|'î'|'��'|'��'|'��')
	|	'��'('��'|'��'|'��'|'��'|'��'|'��')
	|	'��'('��'|'δ'|'��'|'î'|'��'|'��')
	;

EarthBranch
	:	('��'|'��'|'��'|'î'|'��'|'��'|'��'|'δ'|'��'|'��'|'��'|'��')
	;

SkyTrunk
	:	('��'|'��'|'��'|'��'|'��'|'��'|'��'|'��'|'��'|'��')
	;

FiveAttribute
	:	('��'|'ľ'|'ˮ'|'��'|'��')
	;

DarkAndLight
	:	('��'|'��')
	;

TheInitialDigit
	:	Digit
	;

// ����
WS	:	[ \t\r\n]+ -> skip
	; 

// ����ע��
COMMENT
	:	'/*' .*? '*/' -> channel(HIDDEN)
	;

// ����ע��
LINE_COMMENT
	:	'//' ~[\r\n]* -> skip
    ;

// ------------------------------
// Ƭ��
// ------------------------------

// ���Ƶ���
fragment NameChar
	: (NameStart)
	| Digit
	;

// ��������
fragment NameStart
	: '_'
	| Character
	// | UniversalAlpha
	;

// ����
fragment Digit
	: '0'..'9'
	;

// ����
fragment Character
	:	'a'..'z'
	|	'A'..'Z'
	|	'\u4E00'..'\u9FA5'
	|	'\uF900'..'\uFA2D'
	;
