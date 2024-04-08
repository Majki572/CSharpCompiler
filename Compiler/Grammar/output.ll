source_filename = "main.c"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-linux-gnu"
declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
@strsi = constant [3 x i8] c"%d\00", align 1
@strsf = constant [3 x i8] c"%f\00", align 1
@strpi = constant [4 x i8] c"%d\0A\00", align 1
@strpf = constant [4 x i8] c"%f\0A\00", align 1
define dso_local i32 @main() #0 {
%a = alloca i32, align 4
store i32 2, i32* %a, align 4
%b = alloca i32, align 4
store i32 3, i32* %b, align 4
%1 = add i32 2, 3
%2 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %1)
%3 = sub i32 2, 3
%4 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %3)
%5 = mul i32 2, 3
%6 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %5)
%7 = sdiv i32 2, 3
%8 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %7)
%9 = sdiv i32 2, 3
%c = alloca i32, align 4
store i32 %9, i32* %c, align 4
%10 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %9)
ret i32 0
}
