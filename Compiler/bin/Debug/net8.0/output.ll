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
%1 = add i32 5, 3
%a = alloca i32, align 4
store i32 %1, i32* %a, align 4
ret i32 0
}
