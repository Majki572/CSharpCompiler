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
define i32 @main() nounwind{
%picka = alloca i1, align 1
store i1 1, i1* %picka, align 1
%1= load i1, i1* %picka
%2 = zext i1 %1 to i32
%3 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %2)
ret i32 0 }
