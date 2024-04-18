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
define i32 @mama(i32 %0, i32 %1) {
%a = alloca i32
store i32 %0, i32* %a
%b = alloca i32
store i32 %1, i32* %b
%3 = load i32, i32* %a
%4 = load i32, i32* %b
%5 = add i32 %3, %4
%c = alloca i32
store i32 %5, i32* %c
%6 = load i32, i32* %c
%7 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %6)
%8 = load i32, i32* %c
ret i32 %8
}
define double @ma(double %0, double %1) {
%a = alloca double
store double %0, double* %a
%b = alloca double
store double %1, double* %b
%3 = load double, double* %a
%4 = load double, double* %b
%5 = fadd double %3, %4
%c = alloca double
store double %5, double* %c
%6 = load double, double* %c
ret double %6
}
define double @main() {
%d = alloca i32
store i32 5, i32* %d
%1 = load i32, i32* %d
%2 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %1)
%3 = load i32, i32* %d
%4 = call i32 @mama(i32 %3, i32 100)
%e = alloca i32
store i32 %4, i32* %e
%5 = call double @ma(double 4.4, double 5.5)
%f = alloca double
store double %5, double* %f
%6 = load i32, i32* %e
%7 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %6)
%8 = load double, double* %f
%9 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %8)
ret double 0.0
}
