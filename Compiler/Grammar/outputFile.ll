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
@str.1 = private unnamed_addr constant [ 6 x i8 ] c"rzopa\00"
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
%rzopa = alloca i8*
%9 = call i8* @malloc(i64 5)
store i8* %9, i8** %rzopa
%10 = load i8*, i8** %rzopa
%11 = call i8* @strcpy(i8* noundef %10, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.1, i64 0, i64 0))
br label %false1
false1:
%12= load i32, i32* %a
%13= load i32, i32* %b
%14 = icmp ne i32 %12, %13
br i1 %14, label %true2, label %false2
true2:
%15= load i8*, i8** %success
%16 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %15)
br label %false2
false2:
%17= load i32, i32* %a
%18= load i32, i32* %b
%19 = icmp slt i32 %17, %18
br i1 %19, label %true3, label %false3
true3:
%20= load i8*, i8** %success
%21 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %20)
br label %false3
false3:
%22= load i32, i32* %a
%23= load i32, i32* %b
%24 = icmp sgt i32 %22, %23
br i1 %24, label %true4, label %false4
true4:
%25= load i8*, i8** %success
%26 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %25)
br label %false4
false4:
%27= load i32, i32* %a
%28= load i32, i32* %b
%29 = icmp sle i32 %27, %28
br i1 %29, label %true5, label %false5
true5:
%30= load i8*, i8** %success
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %30)
br label %false5
false5:
%32= load i32, i32* %a
%33= load i32, i32* %b
%34 = icmp sge i32 %32, %33
br i1 %34, label %true6, label %false6
true6:
%35= load i8*, i8** %success
%36 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %35)
br label %false6
false6:
ret i32 0 }
