declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
declare noalias i8* @malloc(i64 noundef)
declare i8* @strcpy(i8* noundef, i8* noundef)
@strpi = constant [4 x i8] c"%d\0A\00"
@strpd = constant [4 x i8] c"%f\0A\00"
@strsi = constant [3 x i8] c"%d\00"
@strsd = constant [4 x i8] c"%lf\00"
@strss = constant [3 x i8] c"%s\00"
@strps = constant [4 x i8] c"%s\0A\00"
@a = private unnamed_addr constant [ 2 x i8 ] c"a\00"
define i32 @main() nounwind{
%a = alloca i8*
%1 = call i8* @malloc(i64 1)
store i8* %1, i8** %a
%2 = load i8*, i8** %a
%3 = call i8* @strcpy(i8* noundef %2, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @a, i64 0, i64 0))
%4 = call i8* @malloc(i64 256)
store i8* %4, i8** %a
%5= load i8*, i8** %a
%6 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %5)
%7= load i8*, i8** %a
%8 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %7)
ret i32 0 }
