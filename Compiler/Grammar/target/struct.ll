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
%struct.temp = type { i32, i32, double }
define i32 @main() {
%ele = alloca %struct.temp*
%1 = call i8* @malloc(i64 16)
%2 = bitcast i8* %1 to %struct.temp*
store %struct.temp* %2, %struct.temp** %ele
%3 = load %struct.temp*, %struct.temp** %ele
%4 = getelementptr inbounds %struct.temp, %struct.temp* %3, i32 0, i32 0
store i32 123, i32* %4
%5 = load %struct.temp*, %struct.temp** %ele
%6 = getelementptr inbounds %struct.temp, %struct.temp* %5, i32 0, i32 1
store i32 456, i32* %6
%7 = load %struct.temp*, %struct.temp** %ele
%8 = getelementptr inbounds %struct.temp, %struct.temp* %7, i32 0, i32 2
store double 789.123, double* %8
%9 = load %struct.temp*, %struct.temp** %ele
%10 = getelementptr inbounds %struct.temp, %struct.temp* %9, i32 0, i32 0
%11 = load i32, i32* %10
%12 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %11)
%13 = load %struct.temp*, %struct.temp** %ele
%14 = getelementptr inbounds %struct.temp, %struct.temp* %13, i32 0, i32 1
%15 = load i32, i32* %14
%16 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %15)
%17 = load %struct.temp*, %struct.temp** %ele
%18 = getelementptr inbounds %struct.temp, %struct.temp* %17, i32 0, i32 1
%19 = load i32, i32* %18
%20 = load %struct.temp*, %struct.temp** %ele
%21 = getelementptr inbounds %struct.temp, %struct.temp* %20, i32 0, i32 0
%22 = load i32, i32* %21
%23 = add i32 %19, %22
%24 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %23)
ret i32 0
}
