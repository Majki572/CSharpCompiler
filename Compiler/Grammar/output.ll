declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
@strsi = constant [3 x i8] c"%d\00", align 1
@strsf = constant [3 x i8] c"%f\00", align 1
@strpi = constant [4 x i8] c"%d\0A\00", align 1
@strpf = constant [4 x i8] c"%f\0A\00", align 1
@strps = constant [4 x i8] c"%s\0A\00", align 1
@str.s = constant [6 x i8] c"Hello\00"
define dso_local i32 @main() #0 {
%s = alloca [6 x i8]
%1 = bitcast [6 x i8]* %s to i8*
call void @llvm.memcpy.p0i8.p0i8.i64(i8* align 1 %1, i8* align 1 getelementptr inbounds ([6 x i8], [6 x i8]* @str.s, i32 0, i32 0), i64 6, i1 false)
ret i32 0
}
