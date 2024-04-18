declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
declare noalias i8* @malloc(i64)
declare i8* @strcpy(i8*, i8*)
declare i8* @strcat(i8*, i8*)
@strpd = constant [4 x i8] c"%d\0A\00"
@strplld = constant [6 x i8] c"%lld\0A\00"
@strpf = constant [4 x i8] c"%f\0A\00"
@strplf = constant [5 x i8] c"%lf\0A\00"
@strshd = constant [4 x i8] c"%hd\00"
@strsd = constant [3 x i8] c"%d\00"
@strslld = constant [5 x i8] c"%lld\00"
@strsf = constant [3 x i8] c"%f\00"
@strslf = constant [4 x i8] c"%lf\00"
@strss = constant [3 x i8] c"%s\00"
@strps = constant [4 x i8] c"%s\0A\00"
@str.0 = private unnamed_addr constant [5 x i8] c"mama\00"
define double @main() {
%a = alloca i32
store i32 0, i32* %a
%b = alloca i32
store i32 8, i32* %b
br label %whileCondition1
whileCondition1:
%1 = load i32, i32* %a
%2 = load i32, i32* %b
%3 = icmp slt i32 %1, %2
br i1 %3, label %whileTrue1, label %whileFalse1
whileTrue1:
%4 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([5 x i8], [5 x i8]* @str.0, i64 0, i64 0))
%5 = load i32, i32* %a
%6 = add i32 %5, 1
store i32 %6, i32* %a
br label %whileCondition1
whileFalse1:
ret double 0.0
}
