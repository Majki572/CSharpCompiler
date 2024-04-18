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
@str.0 = private unnamed_addr constant [6 x i8] c"Hello\00"
@str.1 = private unnamed_addr constant [6 x i8] c"World\00"
@str.2 = private unnamed_addr constant [2 x i8] c" \00"
define i32 @main() {
%b = alloca i16
store i16 1, i16* %b
%1 = load i16, i16* %b
%2 = sext i16 %1 to i32
%3 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %2)
store i16 2, i16* %b
%4 = load i16, i16* %b
%5 = sext i16 %4 to i32
%6 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %5)
%7 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i16* %b)
%8 = load i16, i16* %b
%9 = sext i16 %8 to i32
%10 = load i16, i16* %b
%11 = sext i16 %10 to i32
%12 = add i32 %9, %11
%13 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %12)
%14 = load i16, i16* %b
%15 = sext i16 %14 to i32
%16 = load i16, i16* %b
%17 = sext i16 %16 to i32
%18 = sub i32 %15, %17
%19 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %18)
%20 = load i16, i16* %b
%21 = sext i16 %20 to i32
%22 = load i16, i16* %b
%23 = sext i16 %22 to i32
%24 = sdiv i32 %21, %23
%25 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %24)
%26 = load i16, i16* %b
%27 = sext i16 %26 to i32
%28 = load i16, i16* %b
%29 = sext i16 %28 to i32
%30 = mul i32 %27, %29
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %30)
%a = alloca i32
store i32 5, i32* %a
%32 = load i32, i32* %a
%33 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %32)
store i32 16, i32* %a
%34 = load i32, i32* %a
%35 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %34)
%36 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %a)
%37 = load i32, i32* %a
%38 = load i32, i32* %a
%39 = add i32 %37, %38
%40 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %39)
%41 = load i32, i32* %a
%42 = load i32, i32* %a
%43 = sub i32 %41, %42
%44 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %43)
%45 = load i32, i32* %a
%46 = load i32, i32* %a
%47 = sdiv i32 %45, %46
%48 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %47)
%49 = load i32, i32* %a
%50 = load i32, i32* %a
%51 = mul i32 %49, %50
%52 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %51)
%c = alloca i64
store i64 10000000, i64* %c
%53 = load i64, i64* %c
%54 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %53)
store i64 200000000, i64* %c
%55 = load i64, i64* %c
%56 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %55)
%57 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %c)
%58 = load i64, i64* %c
%59 = load i64, i64* %c
%60 = add i64 %58, %59
%61 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %60)
%62 = load i64, i64* %c
%63 = load i64, i64* %c
%64 = sub i64 %62, %63
%65 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %64)
%66 = load i64, i64* %c
%67 = load i64, i64* %c
%68 = sdiv i64 %66, %67
%69 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %68)
%70 = load i64, i64* %c
%71 = load i64, i64* %c
%72 = mul i64 %70, %71
%73 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %72)
%d = alloca float
store float 1.5, float* %d
%74 = load float, float* %d
%75 = fpext float %74 to double
%76 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %75)
store float 2.5, float* %d
%77 = load float, float* %d
%78 = fpext float %77 to double
%79 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %78)
%80 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %d)
%81 = load float, float* %d
%82 = load float, float* %d
%83 = fadd float %81, %82
%84 = fpext float %83 to double
%85 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %84)
%86 = load float, float* %d
%87 = load float, float* %d
%88 = fsub float %86, %87
%89 = fpext float %88 to double
%90 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %89)
%91 = load float, float* %d
%92 = load float, float* %d
%93 = fdiv float %91, %92
%94 = fpext float %93 to double
%95 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %94)
%96 = load float, float* %d
%97 = load float, float* %d
%98 = fmul float %96, %97
%99 = fpext float %98 to double
%100 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %99)
%e = alloca double
store double 1.5, double* %e
%101 = load double, double* %e
%102 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %101)
store double 2.5, double* %e
%103 = load double, double* %e
%104 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %103)
%105 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %e)
%106 = load double, double* %e
%107 = load double, double* %e
%108 = fadd double %106, %107
%109 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %108)
%110 = load double, double* %e
%111 = load double, double* %e
%112 = fsub double %110, %111
%113 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %112)
%114 = load double, double* %e
%115 = load double, double* %e
%116 = fdiv double %114, %115
%117 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %116)
%118 = load double, double* %e
%119 = load double, double* %e
%120 = fmul double %118, %119
%121 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %120)
%f = alloca i8*
%122 = call i8* @malloc(i64 6)
store i8* %122, i8** %f
%123 = load i8*, i8** %f
%124 = call i8* @strcpy(i8* %123, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.0, i64 0, i64 0))
%125 = load i8*, i8** %f
%126 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %125)
%127 = call i8* @malloc(i64 6)
store i8* %127, i8** %f
%128 = load i8*, i8** %f
%129 = call i8* @strcpy(i8* %128, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.1, i64 0, i64 0))
%130 = load i8*, i8** %f
%131 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %130)
%132 = load i8*, i8** %f
%133 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %132)
%134 = load i8*, i8** %f
%135 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %134)
%136 = load i8*, i8** %f
%137 = load i8*, i8** %f
%138 = alloca i8*
%139 = call i8* @malloc(i64 11)
store i8* %139, i8** %138
%140 = call i8* @strcat(i8* %139, i8* %136)
%141 = call i8* @strcat(i8* %140, i8* %137)
%142 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %141)
%143 = load i8*, i8** %f
%144 = load i8*, i8** %f
%145 = alloca i8*
%146 = call i8* @malloc(i64 7)
store i8* %146, i8** %145
%147 = call i8* @strcat(i8* %146, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.2, i64 0, i64 0))
%148 = call i8* @strcat(i8* %147, i8* %144)
%149 = alloca i8*
%150 = call i8* @malloc(i64 12)
store i8* %150, i8** %149
%151 = call i8* @strcat(i8* %150, i8* %143)
%152 = call i8* @strcat(i8* %151, i8* %148)
%153 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %152)
%154 = load i8*, i8** %f
%155 = load i8*, i8** %f
%156 = load i8*, i8** %f
%157 = alloca i8*
%158 = call i8* @malloc(i64 7)
store i8* %158, i8** %157
%159 = call i8* @strcat(i8* %158, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.2, i64 0, i64 0))
%160 = call i8* @strcat(i8* %159, i8* %156)
%161 = alloca i8*
%162 = call i8* @malloc(i64 12)
store i8* %162, i8** %161
%163 = call i8* @strcat(i8* %162, i8* %155)
%164 = call i8* @strcat(i8* %163, i8* %160)
%165 = alloca i8*
%166 = call i8* @malloc(i64 13)
store i8* %166, i8** %165
%167 = call i8* @strcat(i8* %166, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.2, i64 0, i64 0))
%168 = call i8* @strcat(i8* %167, i8* %164)
%169 = alloca i8*
%170 = call i8* @malloc(i64 18)
store i8* %170, i8** %169
%171 = call i8* @strcat(i8* %170, i8* %154)
%172 = call i8* @strcat(i8* %171, i8* %168)
%173 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %172)
ret i32 0 }
