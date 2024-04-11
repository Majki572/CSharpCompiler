declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
declare noalias i8* @malloc(i64 noundef)
declare i8* @strcpy(i8* noundef, i8* noundef)
declare i8* @strcat(i8* noundef, i8* noundef)
@strpi = constant [4 x i8] c"%d\0A\00"
@strpd = constant [4 x i8] c"%f\0A\00"
@strsi = constant [3 x i8] c"%d\00"
@strsd = constant [4 x i8] c"%lf\00"
@strss = constant [3 x i8] c"%s\00"
@strps = constant [4 x i8] c"%s\0A\00"
@str.0 = private unnamed_addr constant [ 14 x i8 ] c"Hello, World!\00"
@str.1 = private unnamed_addr constant [ 4 x i8 ] c"awd\00"
define i32 @main() nounwind{
%a = alloca i8*
%1 = call i8* @malloc(i64 13)
store i8* %1, i8** %a
%2 = load i8*, i8** %a
%3 = call i8* @strcpy(i8* noundef %2, i8* getelementptr inbounds ([14 x i8], [14 x i8]* @str.0, i64 0, i64 0))
%b = alloca i8*
%4 = call i8* @malloc(i64 13)
store i8* %4, i8** %b
%5 = load i8*, i8** %b
%6 = call i8* @strcpy(i8* noundef %5, i8* getelementptr inbounds ([14 x i8], [14 x i8]* @str.0, i64 0, i64 0))
%c = alloca i8*
%7 = call i8* @malloc(i64 13)
store i8* %7, i8** %c
%8 = load i8*, i8** %c
%9 = call i8* @strcpy(i8* noundef %8, i8* getelementptr inbounds ([14 x i8], [14 x i8]* @str.0, i64 0, i64 0))
%10= load i8*, i8** %a
%11= load i8*, i8** %b
%12 = alloca i8*
%13 = call i8* @malloc(i64 27)
store i8* %13, i8** %12
%14 = call i8* @strcat(i8* %13, i8* %10)
%15 = call i8* @strcat(i8* %14, i8* %11)
%16 = alloca i8*
%17 = call i8* @malloc(i64 31)
store i8* %17, i8** %16
%18 = call i8* @strcat(i8* %17, i8* %15)
%19 = call i8* @strcat(i8* %18, i8* getelementptr inbounds ([4 x i8], [4 x i8]* @str.1, i64 0, i64 0))
%20= load i8*, i8** %c
%21 = alloca i8*
%22 = call i8* @malloc(i64 45)
store i8* %22, i8** %21
%23 = call i8* @strcat(i8* %22, i8* %19)
%24 = call i8* @strcat(i8* %23, i8* %20)
%25 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %24)
ret i32 0 }
