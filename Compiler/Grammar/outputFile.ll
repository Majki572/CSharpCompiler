declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
declare noalias i8* @malloc(i64 noundef)
declare i8* @strcpy(i8* noundef, i8* noundef)
declare i8* @strcat(i8* noundef, i8* noundef)
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
@str.0 = private unnamed_addr constant [ 8 x i8 ] c"SUCCESS\00"
define i32 @main() nounwind{
%success = alloca i8*
%1 = call i8* @malloc(i64 7)
store i8* %1, i8** %success
%2 = load i8*, i8** %success
%3 = call i8* @strcpy(i8* noundef %2, i8* getelementptr inbounds ([8 x i8], [8 x i8]* @str.0, i64 0, i64 0))
%a = alloca i32
store i32 7, i32* %a
%b = alloca i32
store i32 8, i32* %b
%4= load i32, i32* %a
%5= load i32, i32* %b
%6 = icmp eq i32 %4, %5
br i1 %6, label %true1, label %false1
true1:
%7= load i8*, i8** %success
%8 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %7)
br label %false1
false1:
%9= load i32, i32* %a
%10= load i32, i32* %b
%11 = icmp ne i32 %9, %10
br i1 %11, label %true2, label %false2
true2:
%12= load i8*, i8** %success
%13 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %12)
br label %false2
false2:
%14= load i32, i32* %a
%15= load i32, i32* %b
%16 = icmp slt i32 %14, %15
br i1 %16, label %true3, label %false3
true3:
%17= load i8*, i8** %success
%18 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %17)
br label %false3
false3:
%19= load i32, i32* %a
%20= load i32, i32* %b
%21 = icmp sgt i32 %19, %20
br i1 %21, label %true4, label %false4
true4:
%22= load i8*, i8** %success
%23 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %22)
br label %false4
false4:
%24= load i32, i32* %a
%25= load i32, i32* %b
%26 = icmp sle i32 %24, %25
br i1 %26, label %true5, label %false5
true5:
%27= load i8*, i8** %success
%28 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %27)
br label %false5
false5:
%29= load i32, i32* %a
%30= load i32, i32* %b
%31 = icmp sge i32 %29, %30
br i1 %31, label %true6, label %false6
true6:
%32= load i8*, i8** %success
%33 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %32)
br label %false6
false6:
ret i32 0 }
