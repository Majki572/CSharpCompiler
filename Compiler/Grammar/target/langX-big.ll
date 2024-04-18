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
@str.0 = private unnamed_addr constant [10 x i8] c"patola ma\00"
@str.1 = private unnamed_addr constant [12 x i8] c"TRUE INDEED\00"
@str.2 = private unnamed_addr constant [6 x i8] c"Hello\00"
@str.3 = private unnamed_addr constant [6 x i8] c"World\00"
@str.4 = private unnamed_addr constant [2 x i8] c" \00"
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
%ele = alloca %struct.temp*
%8 = call i8* @malloc(i64 16)
%9 = bitcast i8* %8 to %struct.temp*
store %struct.temp* %9, %struct.temp** %ele
%10 = load %struct.temp*, %struct.temp** %ele
%11 = getelementptr inbounds %struct.temp, %struct.temp* %10, i32 0, i32 0
store i32 123, i32* %11
%12 = load %struct.temp*, %struct.temp** %ele
%13 = getelementptr inbounds %struct.temp, %struct.temp* %12, i32 0, i32 1
store i32 456, i32* %13
%14 = load %struct.temp*, %struct.temp** %ele
%15 = getelementptr inbounds %struct.temp, %struct.temp* %14, i32 0, i32 2
store double 789.123, double* %15
%16 = load %struct.temp*, %struct.temp** %ele
%17 = getelementptr inbounds %struct.temp, %struct.temp* %16, i32 0, i32 0
%18 = load i32, i32* %17
%19 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %18)
%20 = load %struct.temp*, %struct.temp** %ele
%21 = getelementptr inbounds %struct.temp, %struct.temp* %20, i32 0, i32 1
%22 = load i32, i32* %21
%23 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %22)
%24 = load %struct.temp*, %struct.temp** %ele
%25 = getelementptr inbounds %struct.temp, %struct.temp* %24, i32 0, i32 1
%26 = load i32, i32* %25
%27 = load %struct.temp*, %struct.temp** %ele
%28 = getelementptr inbounds %struct.temp, %struct.temp* %27, i32 0, i32 0
%29 = load i32, i32* %28
%30 = add i32 %26, %29
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %30)
%32 = load i32, i32* %c
ret i32 %32
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
%dddd = alloca i32
store i32 5, i32* %dddd
%1 = load i32, i32* %dddd
%2 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %1)
%3 = load i32, i32* %dddd
%4 = call i32 @mama(i32 %3, i32 100)
%eeee = alloca i32
store i32 %4, i32* %eeee
%5 = call double @ma(double 4.4, double 5.5)
%ffff = alloca double
store double %5, double* %ffff
%6 = load i32, i32* %eeee
%7 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %6)
%8 = load double, double* %ffff
%9 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %8)
%aaaa = alloca i32
store i32 999, i32* %aaaa
%10 = load i32, i32* %aaaa
%11 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %10)
%12 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %aaaa)
%13 = load i32, i32* %aaaa
%14 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %13)
%ala = alloca i8*
%15 = call i8* @malloc(i64 10)
store i8* %2, i8** %ala
%16 = load i8*, i8** %ala
%17 = call i8* @strcpy(i8* %16, i8* getelementptr inbounds ([10 x i8], [10 x i8]* @str.0, i64 0, i64 0))
%18 = load i8*, i8** %ala
%19 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %18)
%20 = load i8*, i8** %ala
%21 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %20)
%22 = load i8*, i8** %ala
%23 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %22)
%trulizna = alloca i1
store ii true, ii* %trulizna
br i1 %2, label %true1, label %false1
true1:
%24 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* @str.1)
%b = alloca i16
store i16 1, i16* %b
%25 = load i16, i16* %b
%26 = sext i16 %25 to i32
%27 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %26)
store i16 2, i16* %b
%28 = load i16, i16* %b
%29 = sext i16 %28 to i32
%30 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %29)
%31 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i16* %b)
%32 = load i16, i16* %b
%33 = sext i16 %32 to i32
%34 = load i16, i16* %b
%35 = sext i16 %34 to i32
%36 = add i32 %33, %35
%37 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %36)
%38 = load i16, i16* %b
%39 = sext i16 %38 to i32
%40 = load i16, i16* %b
%41 = sext i16 %40 to i32
%42 = sub i32 %39, %41
%43 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %42)
%44 = load i16, i16* %b
%45 = sext i16 %44 to i32
%46 = load i16, i16* %b
%47 = sext i16 %46 to i32
%48 = sdiv i32 %45, %47
%49 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %48)
%50 = load i16, i16* %b
%51 = sext i16 %50 to i32
%52 = load i16, i16* %b
%53 = sext i16 %52 to i32
%54 = mul i32 %51, %53
%55 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %54)
%a = alloca i32
store i32 5, i32* %a
%56 = load i32, i32* %a
%57 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %56)
store i32 16, i32* %a
%58 = load i32, i32* %a
%59 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %58)
%60 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %a)
%61 = load i32, i32* %a
%62 = load i32, i32* %a
%63 = add i32 %61, %62
%64 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %63)
%65 = load i32, i32* %a
%66 = load i32, i32* %a
%67 = sub i32 %65, %66
%68 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %67)
%69 = load i32, i32* %a
%70 = load i32, i32* %a
%71 = sdiv i32 %69, %70
%72 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %71)
%73 = load i32, i32* %a
%74 = load i32, i32* %a
%75 = mul i32 %73, %74
%76 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %75)
%c = alloca i64
store i64 10000000, i64* %c
%77 = load i64, i64* %c
%78 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %77)
store i64 200000000, i64* %c
%79 = load i64, i64* %c
%80 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %79)
%81 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %c)
%82 = load i64, i64* %c
%83 = load i64, i64* %c
%84 = add i64 %82, %83
%85 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %84)
%86 = load i64, i64* %c
%87 = load i64, i64* %c
%88 = sub i64 %86, %87
%89 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %88)
%90 = load i64, i64* %c
%91 = load i64, i64* %c
%92 = sdiv i64 %90, %91
%93 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %92)
%94 = load i64, i64* %c
%95 = load i64, i64* %c
%96 = mul i64 %94, %95
%97 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %96)
%d = alloca float
store float 1,500000e+00, float* %d
%98 = load float, float* %d
%99 = fpext float %98 to double
%100 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %99)
store float 2,500000e+00, float* %d
%101 = load float, float* %d
%102 = fpext float %101 to double
%103 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %102)
%104 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %d)
%105 = load float, float* %d
%106 = load float, float* %d
%107 = fadd float %105, %106
%108 = fpext float %107 to double
%109 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %108)
%110 = load float, float* %d
%111 = load float, float* %d
%112 = fsub float %110, %111
%113 = fpext float %112 to double
%114 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %113)
%115 = load float, float* %d
%116 = load float, float* %d
%117 = fdiv float %115, %116
%118 = fpext float %117 to double
%119 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %118)
%120 = load float, float* %d
%121 = load float, float* %d
%122 = fmul float %120, %121
%123 = fpext float %122 to double
%124 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %123)
%e = alloca double
store double 1.5, double* %e
%125 = load double, double* %e
%126 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %125)
store double 2.5, double* %e
%127 = load double, double* %e
%128 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %127)
%129 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %e)
%130 = load double, double* %e
%131 = load double, double* %e
%132 = fadd double %130, %131
%133 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %132)
%134 = load double, double* %e
%135 = load double, double* %e
%136 = fsub double %134, %135
%137 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %136)
%138 = load double, double* %e
%139 = load double, double* %e
%140 = fdiv double %138, %139
%141 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %140)
%142 = load double, double* %e
%143 = load double, double* %e
%144 = fmul double %142, %143
%145 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %144)
%f = alloca i8*
%146 = call i8* @malloc(i64 6)
store i8* %2, i8** %f
%147 = load i8*, i8** %f
%148 = call i8* @strcpy(i8* %147, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.2, i64 0, i64 0))
%149 = load i8*, i8** %f
%150 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %149)
%151 = call i8* @malloc(i64 6)
store i8* %2, i8** %f
%152 = load i8*, i8** %f
%153 = call i8* @strcpy(i8* %152, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.3, i64 0, i64 0))
%154 = load i8*, i8** %f
%155 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %154)
%156 = load i8*, i8** %f
%157 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %156)
%158 = load i8*, i8** %f
%159 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %158)
%160 = load i8*, i8** %f
%161 = load i8*, i8** %f
%162 = alloca i8*
%162 = call i8* @malloc(i64 11)
store i8* %3, i8** %161
%163 = call i8* @strcat(i8* %162, i8* %160)
%164 = call i8* @strcat(i8* %163, i8* %161)
%165 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %164)
%166 = load i8*, i8** %f
%167 = load i8*, i8** %f
%168 = alloca i8*
%168 = call i8* @malloc(i64 7)
store i8* %4, i8** %167
%169 = call i8* @strcat(i8* %168, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.4, i64 0, i64 0))
%170 = call i8* @strcat(i8* %169, i8* %167)
%171 = alloca i8*
%171 = call i8* @malloc(i64 12)
store i8* %5, i8** %170
%172 = call i8* @strcat(i8* %171, i8* %166)
%173 = call i8* @strcat(i8* %172, i8* %170)
%174 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %173)
%175 = load i8*, i8** %f
%176 = load i8*, i8** %f
%177 = load i8*, i8** %f
%178 = alloca i8*
%178 = call i8* @malloc(i64 7)
store i8* %6, i8** %177
%179 = call i8* @strcat(i8* %178, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.4, i64 0, i64 0))
%180 = call i8* @strcat(i8* %179, i8* %177)
%181 = alloca i8*
%181 = call i8* @malloc(i64 12)
store i8* %7, i8** %180
%182 = call i8* @strcat(i8* %181, i8* %176)
%183 = call i8* @strcat(i8* %182, i8* %180)
%184 = alloca i8*
%184 = call i8* @malloc(i64 13)
store i8* %8, i8** %183
%185 = call i8* @strcat(i8* %184, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.4, i64 0, i64 0))
%186 = call i8* @strcat(i8* %185, i8* %183)
%187 = alloca i8*
%187 = call i8* @malloc(i64 18)
store i8* %9, i8** %186
%188 = call i8* @strcat(i8* %187, i8* %175)
%189 = call i8* @strcat(i8* %188, i8* %186)
%190 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %189)
br label %false1
false1:
%zyzz = alloca i32
store i32 10, i32* %zyzz
%xyxx = alloca i32
store i32 0, i32* %xyxx
br label %whileCondition2
whileCondition2:
%191 = load i32, i32* %xyxx
%192 = load i32, i32* %zyzz
%10 = icmp slt i32 %8, %9
br i1 %10, label %whileTrue2, label %whileFalse2
whileTrue2:
%193 = load i32, i32* %xyxx
%194 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %193)
%195 = load i32, i32* %xyxx
%196 = add i32 %195, 1
store i32 %196, i32* %xyxx
br label %whileCondition2
whileFalse2:
ret double 0.0
}
