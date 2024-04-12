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
@str.0 = private unnamed_addr constant [ 6 x i8 ] c"Hello\00"
@str.1 = private unnamed_addr constant [ 7 x i8 ] c" World\00"
@str.2 = private unnamed_addr constant [ 6 x i8 ] c"SHORT\00"
@str.3 = private unnamed_addr constant [ 8 x i8 ] c"INTEGER\00"
@str.4 = private unnamed_addr constant [ 5 x i8 ] c"LONG\00"
@str.5 = private unnamed_addr constant [ 6 x i8 ] c"FLOAT\00"
@str.6 = private unnamed_addr constant [ 7 x i8 ] c"DOUBLE\00"
define i32 @main() nounwind{
%c = alloca i8*
%1 = call i8* @malloc(i64 5)
store i8* %1, i8** %c
%2 = load i8*, i8** %c
%3 = call i8* @strcpy(i8* noundef %2, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.0, i64 0, i64 0))
%4= load i8*, i8** %c
%5 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %4)
%6= load i8*, i8** %c
%7 = alloca i8*
%8 = call i8* @malloc(i64 12)
store i8* %8, i8** %7
%9 = call i8* @strcat(i8* %8, i8* %6)
%10 = call i8* @strcat(i8* %9, i8* getelementptr inbounds ([7 x i8], [7 x i8]* @str.1, i64 0, i64 0))
%11 = call i8* @malloc(i64 12)
store i8* %11, i8** %c
%12 = load i8*, i8** %c
%13 = call i8* @strcpy(i8* noundef %12, i8* noundef %10)
%14= load i8*, i8** %c
%15 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %14)
%16 = call i8* @malloc(i64 256)
store i8* %16, i8** %c
%17= load i8*, i8** %c
%18 = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %17)
%19= load i8*, i8** %c
%20 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %19)
%21 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.2, i64 0, i64 0))
%s = alloca i16
store i16 5, i16* %s
%22= load i16, i16* %s
%23 = sext i16 %22 to i32
%24 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %23)
store i16 10, i16* %s
%25= load i16, i16* %s
%26 = sext i16 %25 to i32
%27 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %26)
%28 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strshd, i64 0, i64 0), i16* %s)
%29= load i16, i16* %s
%30 = sext i16 %29 to i32
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %30)
%32= load i16, i16* %s
%33 = sext i16 %32 to i32
%34 = alloca i16
%35 = add i32 %33, 3
%36 = trunc i32 %35 to i16
store i16 %36, i16* %34
%37= load i16, i16* %34
%38 = sext i16 %37 to i32
%39 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %38)
%40= load i16, i16* %s
%41 = sext i16 %40 to i32
%42 = alloca i16
%43 = sub i32 %41, 3
%44 = trunc i32 %43 to i16
store i16 %44, i16* %42
%45= load i16, i16* %42
%46 = sext i16 %45 to i32
%47 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %46)
%48= load i16, i16* %s
%49 = sext i16 %48 to i32
%50 = alloca i16
%51 = mul i32 %49, 3
%52 = trunc i32 %51 to i16
store i16 %52, i16* %50
%53= load i16, i16* %50
%54 = sext i16 %53 to i32
%55 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %54)
%56= load i16, i16* %s
%57 = sext i16 %56 to i32
%58 = alloca i16
%59 = sdiv i32 %57, 3
%60 = trunc i32 %59 to i16
store i16 %60, i16* %58
%61= load i16, i16* %58
%62 = sext i16 %61 to i32
%63 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %62)
%64 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([8 x i8], [8 x i8]* @str.3, i64 0, i64 0))
%f = alloca i32
store i32 50, i32* %f
%65= load i32, i32* %f
%66 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %65)
store i32 100, i32* %f
%67= load i32, i32* %f
%68 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %67)
%69 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %f)
%70= load i32, i32* %f
%71 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %70)
%72= load i32, i32* %f
%73 = add i32 %72, 30
%74 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %73)
%75= load i32, i32* %f
%76 = sub i32 %75, 30
%77 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %76)
%78= load i32, i32* %f
%79 = mul i32 %78, 3
%80 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %79)
%81= load i32, i32* %f
%82 = sdiv i32 %81, 3
%83 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %82)
%84 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([5 x i8], [5 x i8]* @str.4, i64 0, i64 0))
%l = alloca i64
store i64 500, i64* %l
%85= load i64, i64* %l
%86 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %85)
store i64 1000, i64* %l
%87= load i64, i64* %l
%88 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %87)
%89 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %l)
%90= load i64, i64* %l
%91 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %90)
%92= load i64, i64* %l
%93 = add i64 %92, 300
%94 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %93)
%95= load i64, i64* %l
%96 = sub i64 %95, 300
%97 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %96)
%98= load i64, i64* %l
%99 = mul i64 %98, 3
%100 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %99)
%101= load i64, i64* %l
%102 = sdiv i64 %101, 3
%103 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %102)
%104 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.5, i64 0, i64 0))
%d = alloca float
store float 5.5, float* %d
%105= load float, float* %d
%106 = fpext float %105 to double
%107 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %106)
store float 10.5, float* %d
%108= load float, float* %d
%109 = fpext float %108 to double
%110 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %109)
%111 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %d)
%112= load float, float* %d
%113 = fpext float %112 to double
%114 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %113)
%115= load float, float* %d
%116 = fadd float %115, 5.5
%117 = fpext float %116 to double
%118 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %117)
%119= load float, float* %d
%120 = fsub float %119, 5.5
%121 = fpext float %120 to double
%122 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %121)
%123= load float, float* %d
%124 = fmul float %123, 5.5
%125 = fpext float %124 to double
%126 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %125)
%127= load float, float* %d
%128 = fdiv float %127, 5.5
%129 = fpext float %128 to double
%130 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %129)
%131 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([7 x i8], [7 x i8]* @str.6, i64 0, i64 0))
%e = alloca double
store double 67.5, double* %e
store double 100.5, double* %e
%132= load double, double* %e
%133 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %132)
%134 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %e)
%135= load double, double* %e
%136 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %135)
%137= load double, double* %e
%138 = fadd double %137, 10.5
%139 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %138)
%140= load double, double* %e
%141 = fsub double %140, 10.5
%142 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %141)
%143= load double, double* %e
%144 = fmul double %143, 10.5
%145 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %144)
%146= load double, double* %e
%147 = fdiv double %146, 10.5
%148 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %147)
ret i32 0 }
